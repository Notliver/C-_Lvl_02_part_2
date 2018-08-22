using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Lvl_2_part_2.CheckExeption
{
    /// <summary>
    /// Для большей информации https://metanit.com/sharp/wpf/22.3.php
    /// </summary>
    class RelayCommand : ICommand
    {
        private Action<object> execute;
        private Func<object, bool> canExecute;


        /// <summary>
        /// Прописываем команды
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        /// <summary>
        /// Этот объект в конструкторе принимает действие
        /// </summary>
        /// <param name="execute"></param>
        /// <param name="canExecute"></param>
        public RelayCommand(Action<object> execute, Func<object,bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        /// <summary>
        /// Определяет, может ли команда выполняться
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            return this.canExecute == null || this.canExecute(parameter);
        }

        /// <summary>
        /// Выполняет логику команды
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            this.execute(parameter);
        }
    }
}
