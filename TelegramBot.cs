using Telegram.Bot;
using Telegram.Bot.Types;

class TelegramBot
{
    private TelegramBotClient botClient;
    CancellationTokenSource cts;


    public TelegramBot(string token)
    {
        botClient = new TelegramBotClient(token);
        cts = new CancellationTokenSource();
    }

    public async Task<Message> SendMessage(int chatId, string text)
    {
        var message = await botClient.SendTextMessageAsync(
            chatId: chatId,
            text: text
        );
        return message;
    }
}
