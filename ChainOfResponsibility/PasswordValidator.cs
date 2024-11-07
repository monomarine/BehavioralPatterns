using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility
{
    internal class PasswordValidator : IValidator
    {
        private IValidator _validator;
        public void SetNext(IValidator validator)
        {
            _validator = validator;
        }

        public bool Validate(User user)
        {
            if(String.IsNullOrEmpty(user.Password) || user.Password.Length <= 6)
            {
                Console.WriteLine("пароль не соответствует требуемой длине");
                return false;
            }
            if(!user.Password.Any(Char.IsDigit))
            {
                Console.WriteLine("в пароле отсутствуют цифры");
                return false ;
            }
            if(!user.Password.Any(Char.IsUpper))
            {
                Console.WriteLine("в пароле нет символов в верхнем регистре");
                return false;
            }
            return _validator?.Validate(user) ?? true;
            if (!user.Password.Any(Char.IsLetter))
            {
                Console.WriteLine("в пароле нет букв");
                return false;
            }
        }
    }
}
