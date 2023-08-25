using RabbitApi.Models;

namespace RabbitApi.Services
{
    public interface IAddmessageService
    {
        void Addmessage(SimpleMessage message);
    }
}
