# telegram_notify_bot
Бот для отправки уведомлений в группы Telegram.

## Формат REST сообщения
**POST** /messages
    {
      "senderId": "E70CBB51-A794-45AA-99C8-41502B2AB84E",
      "message": "Сообщение от бота...",
      "emoji": "U+1F680",
      "url": "yandex.ru"
    }

## Настройки appsettings.json

    "Settings": {
      "Telegram": {
        "ApiKey": "Your API key",
        "ChatId": -295999432,
        "DefaultEmaji": "U+1F47D",
        "ValidSenders": [
          {
            "Id": "E70CBB51-A794-45AA-99C8-41502B2AB84E",
            "Name": "CoolDevOpsBot"
          }
        ]
      }