using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Commands
{
    public class AddProductCommand : CommandBase
    {
        internal OrderDetailsVM ViewModelBase { get; }
        public AddProductCommand(OrderDetailsVM vmBase, IUiService service) : base(service) 
        {
            ViewModelBase = vmBase;
        }

        public override void Execute(object? parameter)
        {
            ViewModelBase.Orders.Add(new Order());
        }
    }
}
