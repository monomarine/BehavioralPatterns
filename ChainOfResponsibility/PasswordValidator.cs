using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility
{
    internal class PasswordValidator : IValidator
    {
        private IValidator? _validator;
        public void SetNext(IValidator validator)
        {
            _validator = validator;
        }

        public bool Validate(User user)
        {
            string? password = user.Password;
            if(String.IsNullOrEmpty(password) || password.Length <= 6)
            {
                Console.WriteLine("пароль не соответствует требуемой длине");
                return false;
            }
            if(!password.Any(Char.IsDigit))
            {
                Console.WriteLine("в пароле отсутствуют цифры");
                return false ;
            }
            if(!password.Any(Char.IsUpper))
            {
                Console.WriteLine("в пароле нет символов в верхнем регистре");
                return false;
            }
            if (password.Any(Char.IsWhiteSpace))
            {
                Console.WriteLine("В пароле не может присутствовать пробел");
            }
            return _validator?.Validate(user) ?? true;
        }
    }
}
