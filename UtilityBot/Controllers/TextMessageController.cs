using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using UtilityBot.Configuration;
using UtilityBot.Services;

namespace UtilityBot.Controllers
{
    public class TextMessageController
    {

        private readonly ITelegramBotClient _telegramClient;
        public TextMessageController(ITelegramBotClient telegramBotClient)
        {
            _telegramClient = telegramBotClient;
        }      

        public async Task Handle(Message message, CancellationToken ct)
        {

            switch (message.Text)
            {
                case "/start":

                    // Объект, представляющий кноки
                    var buttons = new List<InlineKeyboardButton[]>();
                    buttons.Add(new[]
                    {
                        InlineKeyboardButton.WithCallbackData($" Подсчёт количества символов" , $"symbolCount"),
                        InlineKeyboardButton.WithCallbackData($" Вычисление суммы чисел" , $"sumCount")
                    });

                    // передаем кнопки вместе с сообщением (параметр ReplyMarkup)
                    await _telegramClient.SendTextMessageAsync(message.Chat.Id, $"<b> Привет. Данный бот имеет две функции: подсчёт количества символов в тексте и вычисление суммы чисел, " +
                        $"которые вы ему отправляете. Напрмер, в ответ на условное сообщение «сова летит» вы получите «в вашем сообщении 10 символов». " +
                        $"А в ответ на сообщение «2 3 15» вы получите «сумма чисел: 20»...</b> {Environment.NewLine}" +
                        $"{Environment.NewLine}Можно записать сообщение и переслать другу, если лень печатать.{Environment.NewLine}", cancellationToken: ct, parseMode: ParseMode.Html, replyMarkup: new InlineKeyboardMarkup(buttons));

                    break;

                default:

                    var chosenFunction =
                    await _telegramClient.SendTextMessageAsync(message.Chat.Id, "Вы отправили сообщение", cancellationToken: ct);
                    return;
            }

        }
    }



}

