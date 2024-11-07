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
            if(String.IsNullOrEmpty(user.Password) || user.Password.Length <= 10)
            {
                Console.WriteLine("парольчик не соответствует требуемой длине:(");
                return false;
            }
            if(!user.Password.Any(Char.IsDigit))
            {
                Console.WriteLine("в парольчике отсутствуют цифры:(");
                return false ;
            }
            if(!user.Password.Any(Char.IsUpper))
            {
                Console.WriteLine("в парольчике нет символов в верхнем регистре:(");
                return false;
            }
            return _validator?.Validate(user) ?? true;
        }
    }
}
