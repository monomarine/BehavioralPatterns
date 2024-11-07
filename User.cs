using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Memento
{
    /// <summary>
    /// категории учеток пользователей: админская, обычная и гостевая
    /// </summary>
    enum UserRole { Admin, User, Guest}

    internal class User
    {
        private string _login;
        private string _password;  
        private UserRole _role;
       

        public string Login { get => _login; }
        public string Password
        {
            get => _password;
            set
            {
                if (value.Length > 5) _password = value;
                else throw new ArgumentException("длина пароля не соответствует");
            }
        }
        public UserRole Role { get => _role; set => _role = value; }

        public User(string login, string password)
        {
            _login = login;
            Password = password;
            Role = UserRole.Guest;
        }

        public void ChangeRole(UserRole role)
        {
            Role = role;
        }

        #region реализация паттерна

        private Caretaker _caretacker = new Caretaker(); //закрытое поле для управления доступом к снимку состояния
        /// <summary>
        /// сохранение текущего состояния пользователя (пароль и роль)
        /// </summary>
        public void SaveState()
        {
            _caretacker.Memento = new Memento(this._password, this._role);
        }
        /// <summary>
        /// восстановление ранее сохраненного состояния (пароль и роль)
        /// </summary>
        public void LoadState()
        {
            _password = _caretacker.Memento.GetSavedState(out _role);
        }
        #endregion

        /// <summary>
        /// Получает информацию о текущем пользователе (если требует администратор или сам пользователь - выводится вся информация. Если гость - доступ запрещён)
        /// </summary>
        /// <param name="user"> Пользователь, который получает данные </param>
        /// <returns></returns>
        public string ToString(User user)
        {
            if (user._role == UserRole.Admin || user._login == _login) return $"Login: {_login}\n" +
                                                     $"Password: {_password}\n" +
                                                     $"Role: {_role}";
            else if (user._role == UserRole.Guest) return "You don't have permission";

            else return $"Login: {_login}\n" +
                        $"Role: {_role.ToString()}";
        }

        public override string ToString() { return "ОШИБКА: используйте конструкцию с получающим пользователем (ToString(user))"; }
    }
}
