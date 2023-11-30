using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.EventGrid;
using Microsoft.Extensions.Logging;
using Azure.Messaging;

namespace AdtEventEndpoint
{
    public static class AdtEventEndpoint
    {
        [FunctionName("broadcast")]
        public static void Run([EventGridTrigger] CloudEvent eventGridEvent, ILogger log)
        {
            log.LogInformation(eventGridEvent.Data.ToString());
        }
    }
}