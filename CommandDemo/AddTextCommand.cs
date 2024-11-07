using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CommandDemo
{
    /// <summary>
    /// конкретная реализация команды добавления текста
    /// </summary>
    class AddTextCommand : ICommand
    {
        private readonly TextBox _textBox;
        private readonly string _text;

        public AddTextCommand(TextBox textBox, string text)
        {
            _textBox=textBox;
            _text=text;
        }

        /// <summary>
        /// при выполнении команды текст просто дозаписывается в текстовое поле
        /// </summary>
        public void Execute()
        {
            _textBox.AppendText(_text);
        }

        /// <summary>
        /// при выполнении операции отметы проверяется оканчивается ли текст на значение в 
        /// переменной _text и оставляет только тот текст, из которого исключается _text
        /// </summary>
        public void Undo()
        {
            var currentText = _textBox.Text;    
            if (currentText.EndsWith(_text))
            {
                _textBox.Text = currentText.Substring(0, currentText.Length - _text.Length);       
            }

        }

        ///<summary>
        ///Стирает весь текст
        ///</summary>
        public void Clean()
        {
            _textBox.Text = null;
        }
    }
}
