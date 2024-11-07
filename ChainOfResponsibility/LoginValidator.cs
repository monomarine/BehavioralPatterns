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

        // Список существующих логинов для примера проверки уникальности
        private List<string> existingLogins = new List<string> { "user1", "user2", "admin" };

        public void SetNext(IValidator validator)
        {
            _validator = validator;
        }

        public bool Validate(User user)
        {
            if (String.IsNullOrEmpty(user.Login) || user.Login.Length < 3)
            {
                Console.WriteLine("Ошибка: Длина имени пользователя не соответствует требованиям (минимум 3 символа).");
                return false;
            }

            if (existingLogins.Contains(user.Login))
            {
                Console.WriteLine("Ошибка: Логин уже занят. Пожалуйста, выберите другой логин.");
                return false;
            }

            return _validator?.Validate(user) ?? true;
        }
    }
}

