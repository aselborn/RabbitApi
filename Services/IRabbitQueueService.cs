using RabbitApi.Models;
using RabbitMQ.Client;

namespace RabbitApi.Services
{
    public interface IRabbitQueueService
    {
        IConnection CreateChannel();
       
    }
}
