using System.Threading.Tasks;
using TelegramNotifyBot.WebApi.Model;

namespace TelegramNotifyBot.WebApi.Services.Abstractions
{
    public interface IMessagesService
    {
        Task Publish(MessageDto message);
    }
}
