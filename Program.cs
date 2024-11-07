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
            
            User user = new User("ivan", "54654321");
            Console.WriteLine(user.Role);
            user.SaveState(); //сохранение текущего состояния пользователя (внутри закрытого поля _caretacker)

            user.ChangeRole(UserRole.Admin); //смена роли пользователя
            Console.WriteLine(user.Role);
            

            user.ChangeRole(UserRole.User);

            user.LoadState(); //восстановление сохраненного состояния
            Console.WriteLine(user.Role);

            //Ошибка: неверная конструкция
            user.ToString();

            //Получение информации пользователя от самого пользователя
            Console.WriteLine($"\n{user.ToString(user)}");

            //Получение информации пользователя от лица другого пользователя
            User justUser = new User("justUser", "98374598");
            justUser.ChangeRole(UserRole.User);
            justUser.SaveState();
            Console.WriteLine($"\n{user.ToString(justUser)}");

            //Получение информации пользователя от лица гостя
            User guest = new User("guest", "873464");
            guest.ChangeRole(UserRole.Guest);
            guest.SaveState();
            Console.WriteLine($"\n{user.ToString(guest)}");

            //Получение информации пользователя от лица админа
            User adminUser = new User("adminUser", "4398272983");
            adminUser.ChangeRole(UserRole.Admin);
            adminUser.SaveState();
            Console.WriteLine($"\n{user.ToString(adminUser)}");
        }
    }
}
