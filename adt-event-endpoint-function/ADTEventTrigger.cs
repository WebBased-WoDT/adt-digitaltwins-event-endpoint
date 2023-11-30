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

namespace Unibo.Wodt
{
    public static class ADTEventTrigger
    {
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
        /// to which it is subscribed in order to receive Azure Digital Twins events.</summary>
        /// <param name="eventGridEvent">the trigger of the function. It is an event from the Event Grid. The specification used is CloudEvent v1.</param>
        /// <param name="signalRConnection">the output binding to the SignalR connection used to send the events.</param>
        [FunctionName("broadcaster")]
        public static Task Run(
            [EventGridTrigger] CloudEvent eventGridEvent,
            [SignalR(HubName = "dteventendpointhub", ConnectionStringSetting = "AzureSignalRConnectionString")] IAsyncCollector<SignalRMessage> signalRConnection,
            ILogger log)
        {
            // Obtain event data and construct the event object to send via SignalR
            JObject eventToClients = (JObject)JsonConvert.DeserializeObject(eventGridEvent.Data.ToString());
            // Add metadata to the event object
            eventToClients.Add("id", eventGridEvent.Subject);
            eventToClients.Add("eventType", eventGridEvent.Type);
            eventToClients.Add("eventDateTime", eventGridEvent.Time);
            log.LogInformation(eventGridEvent.Data.ToString());

            log.LogInformation($"New event:\n {eventToClients.ToString()}");

            // Send the event via SignalR
            return signalRConnection.AddAsync(
                new SignalRMessage
                {
                    Target = "newMessage",
                    Arguments = new[] { JsonConvert.SerializeObject(eventToClients) }
                });
        }
    }
}
