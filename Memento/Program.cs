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
            user.Email = "sasafsdfd@gmail.com";
            Console.WriteLine(user.Role);
            user.SaveState(); //сохранение текущего состояния пользователя (внутри закрытого поля _caretacker)

            user.ChangeRole(UserRole.Admin); //смена роли пользователя
            Console.WriteLine(user.Role);
            

            user.ChangeRole(UserRole.User);
            Console.WriteLine(user.Email);


            user.LoadState(); //восстановление сохраненного состояния
            Console.WriteLine(user.Role);
        }
    }
}
