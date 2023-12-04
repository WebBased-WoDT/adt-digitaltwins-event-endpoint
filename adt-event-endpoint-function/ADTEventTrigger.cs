using Azure.Core.Pipeline;
using Azure.Identity;
using Azure.Messaging;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.EventGrid;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Microsoft.Azure.WebJobs.Extensions.SignalRService;
using Azure.DigitalTwins.Core;
using System;
using System.Net.Http;

namespace Unibo.Wodt
{
    public static class ADTEventTrigger
    {
        /// <summary> Azure Digital Twin's relationships events type. </summary>
        private const string relationshipEventType = "Microsoft.DigitalTwins.Relationship";
        /// <summary> Azure Digital Twin's create Digital Twin event type. </summary>
        private const string createDigitalTwinEventType = "Microsoft.DigitalTwins.Twin.Create";
        /// <summary> Azure Digital Twin's delete Digital Twin event type. </summary>
        private const string deleteDigitalTwinEventType = "Microsoft.DigitalTwins.Twin.Delete";
        /// <summary> Azure Digital Twin's update Digital Twin event type. </summary>
        private const string updateDigitalTwinEventType = "Microsoft.DigitalTwins.Twin.Update";

        /// <summary> The ID of the interested Digital Twin. </summary>
        private const string digitalTwinId = "ambulance";

        /// <summary> The Azure Digital Twins client. </summary>
        private static DigitalTwinsClient digitalTwinsClient = new DigitalTwinsClient(
                new Uri(Environment.GetEnvironmentVariable("ADT_SERVICE_URL")),
                new DefaultAzureCredential(),
                new DigitalTwinsClientOptions{ Transport = new HttpClientTransport(new HttpClient()) });

         /// <summary>A HTTP trigger function. It is used by client to be able to connect to SignalR Service.
        /// It uses the SignalRConnectionInfo input binding
        /// to generate and return valid connection information.</summary>
        /// <param name="req">the trigger of the function. Client perform a post request on this function in order to obtain the token.</param>
        /// <param name="connectionInfo">the connection information returned to the client.</param>
        [FunctionName("negotiate")]
        public static SignalRConnectionInfo GetSignalRInfo(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post")] HttpRequest req,
            [SignalRConnectionInfo(HubName = "dteventendpointhub")] SignalRConnectionInfo connectionInfo)
        {
            return connectionInfo;
        }

        /// <summary>This Azure function handle the events from the Event Grid topic 
        /// to which it is subscribed in order to receive Azure Digital Twins events.
        /// <param name="eventGridEvent">the trigger of the function. It is an event from the Event Grid. The specification used is CloudEvent v1.</param>
        /// <param name="signalRConnection">the output binding to the SignalR connection used to send the events.</param>
        [FunctionName("broadcaster")]
        public static Task Run(
            [EventGridTrigger] CloudEvent eventGridEvent,
            [SignalR(HubName = "dteventendpointhub", ConnectionStringSetting = "AzureSignalRConnectionString")] IAsyncCollector<SignalRMessage> signalRConnection,
            ILogger log)
        {
            // Log received event
            log.LogInformation($"Received event: {eventGridEvent.Data}");

            // Filter out event that aren't of the Digital Twin of interest
            if (getDigitalTwinId(eventGridEvent.Type, eventGridEvent).Equals(digitalTwinId)){

                JObject eventToClients = handleEvent(eventGridEvent);
            
                // Log event sent via Signal R
                log.LogInformation($"New event:\n {eventToClients}");

                // Send the event via SignalR
                return signalRConnection.AddAsync(
                    new SignalRMessage
                    {
                        Target = "digitalTwinUpdate",
                        Arguments = new[] { JsonConvert.SerializeObject(eventToClients) }
                    });
            } else {
                return Task.CompletedTask;
            }
        }

        private static string getDigitalTwinId(string eventType, CloudEvent receivedEvent) {
            string result = "";
            switch(eventType) {
                case createDigitalTwinEventType: case deleteDigitalTwinEventType: case updateDigitalTwinEventType:
                    result = receivedEvent.Subject;
                break;
                case relationshipEventType:
                    result = ((JObject)JsonConvert.DeserializeObject(receivedEvent.Data.ToString()))["$sourceId"].ToString();
                break;
            }
            return result;
        }

        private static JObject handleEvent(CloudEvent receivedEvent) {
                JObject returnedEvent = new()
                {
                    // Add metadata to the event object
                    { "DtId", getDigitalTwinId(receivedEvent.Type, receivedEvent) },
                    { "eventType", receivedEvent.Type },
                    { "eventDateTime", receivedEvent.Time }
                };

                return returnedEvent;
        }
    }
}
