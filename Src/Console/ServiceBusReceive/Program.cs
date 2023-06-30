using Azure.Messaging.ServiceBus;

namespace ServiceBusReceive
{
    internal class Program
    {
        private static string conn = "Endpoint=sb://prabhonsservicebus.servicebus.windows.net/;" +
            "SharedAccessKeyName=listen;" +
            "SharedAccessKey=1oyLfganjRMStkd3IOiVWJvj7IUMQbR/C+ASbKz1gnA=;EntityPath=prabhoqueue";
        
        private static string queue_name = "prabhoqueue";

        static void Main(string[] args)
        {
            ServiceBusClient _client = new ServiceBusClient(conn);

            //ServiceBusReceiver _receiver = _client.CreateReceiver(queue_name, 
            //            new ServiceBusReceiverOptions() { ReceiveMode = ServiceBusReceiveMode.PeekLock});

            ServiceBusReceiver _receiver = _client.CreateReceiver(queue_name,
                        new ServiceBusReceiverOptions() { ReceiveMode = ServiceBusReceiveMode.ReceiveAndDelete});
            //ServiceBusReceivedMessage _message = _receiver.ReceiveMessageAsync().GetAwaiter().GetResult();

            var _messages = _receiver.ReceiveMessagesAsync(3).GetAwaiter().GetResult();

            foreach (var _message in _messages)
            {
                Console.WriteLine(_message.SequenceNumber);
                Console.WriteLine(_message.Body.ToString());
                Console.Beep();
            }

            Console.ReadKey();
        }
    }
}