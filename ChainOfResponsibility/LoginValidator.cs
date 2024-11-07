using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility
{
    internal class LoginValidator : IValidator
    {
        private IValidator _validator;
        public void SetNext(IValidator validator)
        {
            _validator = validator;
        }

        public bool Validate(User user)
        {
            if(String.IsNullOrEmpty(user.Login) || user.Login.Length < 6)
            {
                Console.WriteLine("длина имени пользователя не соответствует требованиям(6)");
                return false;
            }

            return _validator?.Validate(user) ?? true;
        }
    }
}
