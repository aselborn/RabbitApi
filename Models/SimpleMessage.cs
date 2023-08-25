namespace RabbitApi.Models
{
    public class SimpleMessage
    {
        public Guid id { get; set; }
        public string Message { get; set; } = string.Empty;
        public int Count { get;set; }
    }
}
