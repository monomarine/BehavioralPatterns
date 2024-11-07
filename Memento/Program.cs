namespace Memento
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
            Console.WriteLine("Сообщение лучшему преподавателю :3\n");

            User user = new User("ivan3", "54654321");

            if (user.Login.Any(char.IsDigit))
            {
                Console.WriteLine("Ошибка: логин не должен содержать цифры");
                Environment.Exit(0);
            }
            else
            {


                Console.WriteLine($"Здравствуйте, {user.Login}, ваша роль: {user.Role}\n");
                user.SaveState(); //сохранение текущего состояния пользователя (внутри закрытого поля _caretacker)

                user.ChangeRole(UserRole.Admin); //смена роли пользователя
                Console.WriteLine($"Ваша роль была изменена на {user.Role}\n");


                user.ChangeRole(UserRole.User);

                user.LoadState(); //восстановление сохраненного состояния
                Console.WriteLine($"Возвращены изменения вашей роли, теперь ваша роль {user.Role}");
            }
        }
    }
}
