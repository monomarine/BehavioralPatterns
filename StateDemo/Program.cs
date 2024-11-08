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
            User user = new User("petrov", "654656", new ActiveState());
            user.SendMessage("hello!");

            //смена состояния на ожидающее
            user.ChangeState(new  SuspendedState());
            user.SendMessage("Hello!");

            //смена состояния на заблокированное
            user.ChangeState(new BannedState());
            user.SendMessage("Hello!");

            user.ChangeState(new ActiveState());
            user.SendMessage("снова привет, я активен"); // возвращение состояния на активное, после тех что выше
        }
    }
}
