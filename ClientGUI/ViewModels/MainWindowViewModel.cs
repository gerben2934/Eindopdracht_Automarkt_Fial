using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ClientGUI.ViewModels
{
    class MainWindowViewModel
    {
        public static MainWindowViewModel Instance { get;  } = new MainWindowViewModel();

        public TextBox TextMessage { get; set; }

        private MainWindowViewModel()
        {
            TextMessage.AppendText("test");
        }

    }
}
