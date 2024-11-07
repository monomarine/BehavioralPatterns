using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateDemo
{
    /// <summary>
    /// общий интерфейс для все возможных состояний, 
    /// которые обязуются иметь функционал передачи сообщений
    /// </summary>
    internal interface IState
    {
        void SendMessage(string message);
    }

    /// <summary>
    /// активное состояние
    /// </summary>
    public class ActiveState : IState
    {
        public void SendMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ForegroundColor= ConsoleColor.White;
        }
        public override string ToString()
        {
            return "активный";
        }
    }

    /// <summary>
    /// заблокированное состояние
    /// </summary>
    public class BannedState : IState
    {
        public void SendMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("пользователь не имеет прав");
            Console.ForegroundColor= ConsoleColor.White;
        }
        public override string ToString()
        {
            return "заблокированный";
        }
    }
    /// <summary>
    /// состояние ожидания
    /// </summary>
    public class SuspendedState : IState
    {
        public void SendMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("сообщение поставлено в очередь");
            Console.ForegroundColor= ConsoleColor.White;
        }
        public override string ToString()
        {
            return "ожидающий";
        }
    }

}
