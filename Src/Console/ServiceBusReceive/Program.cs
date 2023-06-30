using Azure.Messaging.ServiceBus;

namespace ServiceBusReceive
{
    internal class Program
    {
        private static string conn = "Endpoint=sb://prabhonsservicebus.servicebus.windows.net/;SharedAccessKeyName=Listen;SharedAccessKey=x9lf1HVQVcCa9GswDA1+8Z/pjZH8VSudK+ASbM5PLiE=;EntityPath=prabhoqueue";
        
        private static string queue_name = "prabhoqueue";

        static void Main(string[] args)
        {
            ServiceBusClient _client = new ServiceBusClient(conn);

            ServiceBusReceiver _receiver = _client.CreateReceiver(queue_name, 
                        new ServiceBusReceiverOptions() { ReceiveMode = ServiceBusReceiveMode.PeekLock});

            ServiceBusReceivedMessage _message = _receiver.ReceiveMessageAsync().GetAwaiter().GetResult();

            Console.Beep();
            Console.WriteLine(_message.Body.ToString());

            Console.ReadKey();
        }
    }
}