using System;
using System.Windows.Input;

namespace Xem
{
    internal class RelaySaveCommand : ICommand
    {
        #region Private Members

        /// <summary>
        /// Private action member
        /// </summary>
        private Action<object> action;
        private EditExportSettingsPageViewModel editPageViewModel;
        #endregion


        /// <summary>
        /// Event that is fired when the <see cref="CanExecute(object)"/> value changes
        /// </summary>
        public event EventHandler CanExecuteChanged = (sender, e) => { };

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="a"></param>
        public RelaySaveCommand(Action<object> a)
        {
            action = a;
        }

        // TODO: apply validation
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
            action(parameter);
        }
    }
}