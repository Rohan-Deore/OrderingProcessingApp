using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Commands
{
    public class RemoveProductCommand : CommandBase
    {
        internal OrderDetailsVM ViewModelBase { get; }
        public RemoveProductCommand(OrderDetailsVM vmBase, IUiService service) : base(service)
        { 
            ViewModelBase = vmBase;
        }

        public override void Execute(object? parameter)
        {
            if (parameter != null && parameter is Order)
            {
                ViewModelBase.Orders.Remove(parameter as Order);
            }
        }
    }
}
