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
       

        public string Login
        {
            get => _login;
            set
            {
                if (value.Length > 1) _login = value;
                else throw new ArgumentException("длина логина должна быть больше");
            }
        }
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
    }
}
