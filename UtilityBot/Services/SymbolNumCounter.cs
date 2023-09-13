using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using UtilityBot.Configuration;
using UtilityBot.Services;

namespace UtilityBot.Utilities
{
    public class SymbolNumCounter : IFunction
    {
        private readonly ITelegramBotClient _telegramBotClient;
        public SymbolNumCounter(ITelegramBotClient telegramBotClient)
        {
            _telegramBotClient = telegramBotClient;
        }
        public string Count(Message message, string chosenFunction)
        {
            var text = message.Text;

            if (chosenFunction == "symbolCount")
            {
                return $"Длина сообщения: {text.Length} знаков";
            }

            else if (chosenFunction == "numberCount")
            {
                int sum = 0;
                foreach (char character in text)
                {
                    if (char.IsDigit(character))
                    {
                        sum += int.Parse(character.ToString());
                    }
                    else
                    {
                        return "Введите число";
                    }
                }
                return sum.ToString(); 
            }
            return "Введено не число";
        }

    }
}
