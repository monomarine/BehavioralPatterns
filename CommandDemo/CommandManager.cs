using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandDemo
{
    /// <summary>
    /// класс для управления всеми командами.. хранения их в стеке для отмены или восстановления
    /// </summary>
    class CommandManager
    {
        private readonly Stack<ICommand> _undoStack = new Stack<ICommand>();
        private readonly Stack<ICommand> _redoStack = new Stack<ICommand>();

        /// <summary>
        /// при выполнении любой команды, она выполняется предусмотренным для нее способом
        /// после чего помещается в стек
        /// </summary>
        /// <param name="command"></param>
        public void ExecuteCommand(ICommand command)
        {
            command.Execute();
            _undoStack.Push(command);
            _redoStack.Clear();
        }

        /// <summary>
        /// при отмене последней операции проверяется содержится для в стеке команды для отмены
        /// если да, то команда извлекается, вызывается ее стандартный метод отмены
        /// после чего она помещается в стек для восстановления действий
        /// </summary>
        public void Undo()
        {
            if(_undoStack.Count > 0)
            {
                var command = _undoStack.Pop();
                command.Undo();
                _redoStack.Push(command);
            }
        }

        /// <summary>
        /// аналогично Undo, только в обратном направлении
        /// </summary>
        public void Redo()
        {
            if (_redoStack.Count > 0) 
            {
                var command = _redoStack.Pop();
                command.Execute();
                _undoStack.Push(command);
            }
        }

        public void Clean()
        {
            _redoStack.Clear();
            _undoStack.Clear();
        }
    }
}
