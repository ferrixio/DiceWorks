using System.Windows.Input;

/// <summary>
/// Custom class to exectute di ICommand.
/// I don't really know how this class works, btw...
/// </summary>
namespace PasswordsManager.Commands
{
    public class RelayCommand(Action<object> executeMethod, Predicate<object> canExecuteMethod) : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return canExecuteMethod(parameter);
        }

        public void Execute(object parameter)
        {
            executeMethod(parameter);
        }
    }
}
