using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace ServiceBusQueueReceive
{
    public static class GetMessages
    {
        [FunctionName("GetMessages")]
        public static void Run([ServiceBusTrigger("prabhoqueue", Connection = "servicebus-conn")]string myQueueItem, ILogger log)
        {
            log.LogInformation($"C# ServiceBus queue trigger function processed message: {myQueueItem}");
        }
    }
}
