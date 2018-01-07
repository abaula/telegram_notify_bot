using TelegramNotifyBot.WebApi.Model;

namespace TelegramNotifyBot.WebApi.Services.Abstractions
{
    public interface ISettings
    {
        string ApiKey { get; }
        int ChatId { get; }
        string DefaultEmaji { get; }
        ValidSenderDto[] ValidSenders { get; }
    }
}
