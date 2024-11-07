using Accessibility;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CommandDemo
{
    /*
     пример реализации паттерна команда (https://refactoringguru.cn/ru/design-patterns/command)
    в простом текстовом поле по мере вводу осуществляется возможность отмены ввода и восстановления
    предыдущего состояния путем хранения команд в стеке
     */
    public partial class MainWindow : Window
    {
        // подключение менеджера команд для управления операциями
        private readonly CommandManager _commandManager = new CommandManager();
        public MainWindow()
        {
            InitializeComponent();
        }
        /// <summary>
        /// обрабатывается событие предварительного просмотра введеного текста в текстовое поле
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">вводимый текст</param>
        private void textBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var command = new AddTextCommand((TextBox)sender, e.Text);
            _commandManager.ExecuteCommand(command);
        }

        private void undoButton_Click(object sender, RoutedEventArgs e)
        {
            _commandManager.Undo();
        }

        private void redoButton_Click(object sender, RoutedEventArgs e)
        {
            _commandManager.Redo();
        }

        private void cleaner_Click(object sender, RoutedEventArgs e)
        {
            AddTextCommand a = new AddTextCommand(textBox, "");
            a.Clean();
            _commandManager.Clean();
        }
    }
}