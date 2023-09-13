using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using UtilityBot.Models;

namespace UtilityBot.Services
{
    public interface IFunction
    {
        /// <summary>
        /// Методы функций
        /// </summary>
        string  Count(Message message, string param);
    }
}