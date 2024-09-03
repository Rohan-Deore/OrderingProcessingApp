using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ViewModel;

namespace OrderProcessingWPF
{
    public class UIService : IUiService
    {
        public void ShowUserMessage(string msg)
        {
            MessageBox.Show(msg);
        }
    }
}
