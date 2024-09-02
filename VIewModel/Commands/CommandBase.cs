using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ViewModel.Commands
{
    public abstract class CommandBase : ICommand
    {
        internal IUiService uiService;

        public event EventHandler? CanExecuteChanged;

        public CommandBase(IUiService service)
        {
            uiService = service;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        abstract public void Execute(object? parameter);
    }
}
