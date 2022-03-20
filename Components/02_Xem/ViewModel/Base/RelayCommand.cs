using System;
using System.Windows.Input;

namespace Xem
{
    internal class RelayCommand : ICommand
    {
        #region Private Members

        /// <summary>
        /// Private action member
        /// </summary>
        private Action action;
        #endregion


        /// <summary>
        /// Event that is fired when the <see cref="CanExecute(object)"/> value changes
        /// </summary>
        public event EventHandler CanExecuteChanged = (sender, e) => { };


        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="a"></param>
        public RelayCommand(Action a)
        {
            action = a;
        }

        /// <summary>
        /// Relay command can always execute
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            return true;
        }

        /// <summary>
        /// Executes command action
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            action();
        }
    }
}