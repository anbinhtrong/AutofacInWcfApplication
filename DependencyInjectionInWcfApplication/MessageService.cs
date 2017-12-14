namespace DependencyInjectionInWcfApplication
{
    public class MessageService: IMessageService
    {
        public MessageService()
        {
            
        }

        public string GetHelloWorld()
        {
            return "Hello World";
        }
    }

    public interface IMessageService
    {
        string GetHelloWorld();
    }
}