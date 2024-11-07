namespace ChainOfResponsibility
{
    internal class Program
    {
        static void Main(string[] args)
        {
            User user = new User
            {
                Login = "login98475",
                Password = "kjfghK6dd",
                Email = "example@mail.com"

            };

            LoginValidator loginValidator = new LoginValidator();    
            PasswordValidator passwordValidator = new PasswordValidator();

            loginValidator.SetNext(passwordValidator);

            bool resulr = loginValidator.Validate(user);

            Console.WriteLine($"Успешность регистрации:\n {resulr}");
        }
    }
}
