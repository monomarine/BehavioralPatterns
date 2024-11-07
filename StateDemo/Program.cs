namespace StateDemo
{
    /*
     реализация паттерна Состояние (https://refactoringguru.cn/ru/design-patterns/state)
     */
    internal class Program
    {
        static void Main(string[] args)
        {
            //создание объекта с активным состоянием
            User user1 = new User("Luka","12345678", new ActiveState());
            User user = new User("petrov", "654656", new ActiveState());
            user.SendMessage("hello!");

            //смена состояния на ожидающее
            user.ChangeState(new  SuspendedState());
            user.SendMessage("Hello!");

            //смена состояния на заблокированное
            user.ChangeState(new BannedState());
            user.SendMessage("Hello!");
        }
    }
}
