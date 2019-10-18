using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace Micro.Orchestrator.Utilities
{
    public class EventManager
    {
        public void Fire<T>(T eventData)
        {
            Task.Run(() => {
                var factory = new ConnectionFactory() { HostName = "micro.queue" };
                using(var connection = factory.CreateConnection())
                using(var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: "events",
                                        durable: false,
                                        exclusive: false,
                                        autoDelete: false,
                                        arguments: null);

                    string message = JsonConvert.SerializeObject(eventData);
                    var body = Encoding.UTF8.GetBytes(message);

                    channel.BasicPublish(exchange: "",
                                        routingKey: "events",
                                        basicProperties: null,
                                        body: body);
                }
            });
        }
    }
}