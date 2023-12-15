using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GettingReal_Eydes
{
    // RelayCommand class implements ICommand interface for delegating commands
    class RelayCommand : ICommand
    {
        private Action execute; // Action to execute
        private Func<bool> canExecute; // Function to determine if the command can execute

        // Constructor for RelayCommand
        public RelayCommand(Action execute, Func<bool> canExecute = null)
        {
            // Set the action to execute, throw exception if execute action is null
            this.execute = execute ?? throw new ArgumentNullException(nameof(execute));
            this.canExecute = canExecute; // Set the function to determine command execution
        }

        // Event that notifies changes in the ability to execute the command
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; } // Register to the WPF CommandManager
            remove { CommandManager.RequerySuggested -= value; } // Unregister from the WPF CommandManager
        }

        // Method to check if the command can be executed
        public bool CanExecute(object parameter)
        {
            return canExecute == null || canExecute(); // Return true if canExecute is null or its function returns true
        }

        // Method to execute the command
        public void Execute(object parameter)
        {
            execute(); // Invoke the action associated with the command
        }
    }
}
