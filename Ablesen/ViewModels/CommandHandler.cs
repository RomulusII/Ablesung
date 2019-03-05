using System;
using System.Windows.Input;

namespace Ablesen.ViewModels
{
    public class CommandHandler : ICommand
    {
        private readonly Func<bool> canExecuteEvaluator;
        private readonly Action methodToExecute;

        public CommandHandler(Action methodToExecute, Func<bool> canExecuteEvaluator)
        {
            this.methodToExecute = methodToExecute;
            this.canExecuteEvaluator = canExecuteEvaluator;
        }

        public CommandHandler(Action methodToExecute)
            : this(methodToExecute, null)
        {
        }

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public bool CanExecute(object parameter)
        {
            if (canExecuteEvaluator == null)
            {
                return true;
            }

            var result = canExecuteEvaluator.Invoke();
            return result;
        }

        public void Execute(object parameter)
        {
            methodToExecute.Invoke();
        }
    }
}