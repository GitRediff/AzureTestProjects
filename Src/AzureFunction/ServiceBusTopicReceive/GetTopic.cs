using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace ServiceBusTopicReceive
{
    public class GetTopic
    {
        private readonly ILogger<GetTopic> _logger;

        public GetTopic(ILogger<GetTopic> log)
        {
            _logger = log;
        }

        [FunctionName("GetTopic")]
        public void Run([ServiceBusTrigger("prabhotopic", "PraBhoSubscription1", Connection = "servicebus-conn")]string mySbMsg)
        {
            _logger.LogInformation($"C# ServiceBus topic trigger function processed message: {mySbMsg}");
        }
    }
}
 