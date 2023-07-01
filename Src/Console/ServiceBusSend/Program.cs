using Azure.Messaging.ServiceBus;
using ServiceBusSend;

namespace ServiceBusSend
{
    public class Program
    {

        private static string conn = "Endpoint=sb://prabhonsservicebus.servicebus.windows.net/;SharedAccessKeyName=send;SharedAccessKey=YEZhfe437X8aWF6rf2O0TIQEJQSyG+kDD+ASbMZZJrY=;EntityPath=prabhoqueue";
        private static string queue_name = "prabhoqueue";

        public static void Main(string[] args)
        {


        List<Order> _orders = new List<Order>()
        {
            new Order() { OrderID="1", Quantity=10, UnitPrice=10.0m },
            new Order() { OrderID="2", Quantity=20, UnitPrice=20.0m },
            new Order() { OrderID="3", Quantity=30, UnitPrice=30.0m }
        };

            ServiceBusClient _client = new ServiceBusClient(conn);

            ServiceBusSender _sender = _client.CreateSender(queue_name);

            foreach(Order _order in _orders)
            {
                ServiceBusMessage _message = new ServiceBusMessage(_order.ToString());
                _message.TimeToLive = TimeSpan.FromMinutes(2);
                _sender.SendMessageAsync(_message).GetAwaiter().GetResult();
                Console.Beep();
            }
            Console.ReadKey();
        }
    }
}
