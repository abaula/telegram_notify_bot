using TelegramNotifyBot.WebApi.Model;

namespace TelegramNotifyBot.WebApi.Services.Abstractions
{
    public interface ISettings
    {
        string ApiKey { get; }
        int ChatId { get; }
        ValidSenderDto[] ValidSenders { get; }
    }
}
