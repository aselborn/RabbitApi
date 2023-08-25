using RabbitApi.Models;
using System.Text;

namespace RabbitApi.Services
{
    public class AddMessageService : IAddmessageService
    {
        private readonly IRabbitQueueService _rabbitQueueService;
        public AddMessageService(IRabbitQueueService rabbitQueueService) 
        {
            _rabbitQueueService = rabbitQueueService;
        }
        public void Addmessage(SimpleMessage message)
        {
            var cn = _rabbitQueueService.CreateChannel();
            using var model = cn.CreateModel();
            var body = Encoding.UTF8.GetBytes(message.Message);
            model.BasicPublish("UserExchange", string.Empty, true, null, body);
        }
    }
}
