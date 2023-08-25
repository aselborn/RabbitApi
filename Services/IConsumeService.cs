using RabbitApi.Models;

namespace RabbitApi.Services
{
    public interface IConsumeService
    {
        Task<List<SimpleMessage>> ReadMessages();
    }
}
