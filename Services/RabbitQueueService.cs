using Microsoft.Extensions.Options;
using RabbitApi.Models;
using RabbitMQ.Client;
using System.Text;

namespace RabbitApi.Services
{
    public class RabbitQueueService : IRabbitQueueService
    {
       
        private readonly RabbitMqConfiguration _rabbitMqConfiguration = null!;
        

        public RabbitQueueService(IOptions<RabbitMqConfiguration> options)
        {
            _rabbitMqConfiguration = options.Value;
        }

       

        public IConnection CreateChannel()
        {
            var connectionFactory = new ConnectionFactory
            {
                HostName = _rabbitMqConfiguration.host,
                Password = _rabbitMqConfiguration.password,
                UserName = _rabbitMqConfiguration.username
            };


            connectionFactory.DispatchConsumersAsync = true;
            var channel = connectionFactory.CreateConnection();
            return channel;
        }

        

        

        public List<SimpleMessage> GetMessages()
        {
            //var result = new List<SimpleMessage>();

            //var consumer = new EventingBasicConsumer(channel);
            //consumer.Received += (model, ea) =>
            //{
            //    var body = ea.Body.ToArray();
            //    var message = Encoding.UTF8.GetString(body);

            //    result.Add(new SimpleMessage { id = Guid.NewGuid(), Message = message });

            //    Console.WriteLine($" [x] Received {message}");
            //};

            //channel.BasicConsume(queue: "selborn_queue",
            //                     autoAck: true,
            //                     consumer: consumer);


            //return result;
            return null;
        }
    }
}
