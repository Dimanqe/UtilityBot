using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using UtilityBot.Services;

namespace UtilityBot.Utilities
{
    public class SymbolCounter :IFunction
    {
        
        public string Count(Message message)
        {
            return ($"Длина сообщения: {message.Text.Length} знаков");     
        }

    }
}
