using RabbitApi.Models;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace RabbitApi.Services
{
    public class ConsumeService : IConsumeService
    {
        private readonly IModel _model;
        private readonly IConnection _connection;
        private readonly string _queueName = "SELBORN";
        public ConsumeService(IRabbitQueueService rabbitQueueService)
        {
            _connection = rabbitQueueService.CreateChannel();
            _model = _connection.CreateModel();
            _model.QueueDeclare(_queueName, true, false, false, null);
            _model.ExchangeDeclare("Exchange", ExchangeType.Fanout, true, false);
            //_model.QueueBind(_queueName, "UserExchange", string.Empty);

        }
        public async Task<List<SimpleMessage>> ReadMessages()
        {
            var messages = new List<SimpleMessage>();
            var consumer = new AsyncEventingBasicConsumer(_model);
            consumer.Received += async (ch, ea) =>
            {
                var body = ea.Body.ToArray();
                var text = System.Text.Encoding.UTF8.GetString(body);
                Console.WriteLine(text);
                await Task.CompletedTask;
                _model.BasicAck(ea.DeliveryTag, false);
            };
            _model.BasicConsume(_queueName, false, consumer);
            await Task.CompletedTask;
            return messages;
        }
    }
}
