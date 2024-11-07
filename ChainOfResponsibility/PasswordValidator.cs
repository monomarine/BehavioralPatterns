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
            // Проверка на пустой пароль или недостаточную длину
            if (String.IsNullOrEmpty(user.Password) || user.Password.Length <= 6)
            {
                Console.WriteLine("Ошибка: Пароль должен содержать более 6 символов.");
                return false;
            }

            // Проверка на наличие хотя бы одной цифры
            if (!user.Password.Any(Char.IsDigit))
            {
                Console.WriteLine("Ошибка: В пароле отсутствуют цифры.");
                return false;
            }

            // Проверка на наличие хотя бы одного символа в верхнем регистре
            if (!user.Password.Any(Char.IsUpper))
            {
                Console.WriteLine("Ошибка: В пароле должны быть символы в верхнем регистре.");
                return false;
            }

            // Проверка на наличие хотя бы одного специального символа
            if (!user.Password.Any(ch => !Char.IsLetterOrDigit(ch)))
            {
                Console.WriteLine("Ошибка: В пароле должен быть хотя бы один специальный символ (например, @, #, $, и т.д.).");
                return false;
            }

            // Передача проверки следующему валидатору, если он задан
            return _validator?.Validate(user) ?? true;
        }
    }
}
