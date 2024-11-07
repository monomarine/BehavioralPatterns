﻿namespace Memento
{
    /*
     * реализация паттерна хранитель (https://refactoringguru.cn/ru/design-patterns/memento)
     */
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             объект пользователя имеет внутренний механизм для сохранения данных своего состояния и
            последующему восстановлению

            снимок сохраняется в памяти так, что доступ других объектов к нему невозможен
             */
            Console.WriteLine("Проверка методов смены ролей пользователя:");
            User user = new User("ivan", "54654321");
            Console.WriteLine( $"{user.Role} - гость");
            user.SaveState(); //сохранение текущего состояния пользователя (внутри закрытого поля _caretacker)

            user.ChangeRole(UserRole.Admin); //смена роли пользователя
            Console.WriteLine($"{user.Role} - админ");
            

            user.ChangeRole(UserRole.User);

            user.LoadState(); //восстановление сохраненного состояния
            Console.WriteLine($"{user.Role} - гость");
        }
    }
}
