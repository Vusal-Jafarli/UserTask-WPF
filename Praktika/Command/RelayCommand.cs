using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Praktika.Command
{
    public class RelayCommand:ICommand
    {


        public Action<object?>? _execute { get; set; }
        public Predicate<object?>? _canexecute { get; set; }


        public RelayCommand(Action<object?>? execute,Predicate<object?>? canexecute=null)
        {
            _execute = execute;
            _canexecute = canexecute;
        }
        

        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object? parameter)
        {
            if (_canexecute == null) return true;
            else return _canexecute(parameter);
        }

        public void Execute(object? parameter)
        {
            _execute?.Invoke(parameter);
        }




    }
}
