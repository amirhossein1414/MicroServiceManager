using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MicroserviceManager.Views
{
    /// <summary>
    /// Interaction logic for ProcesseView.xaml
    /// </summary>
    public partial class ProcesseView : UserControl
    {
        private ProcessManager processManager = new ProcessManager();
        public ProcesseView()
        {
            InitializeComponent();
            processManager.OnNewProcessStart((obj, e) => RefreshGrid());
            processManager.OnNewProcessStop((obj, e) => RefreshGrid());
        }

        public void CloseW3s()
        {
            processManager.CloseW3Processes();
        }

        private void RefreshGrid([CallerMemberName] string callerName = "")
        {
            dataGrid.Dispatcher.Invoke(() =>
            {
                dataGrid.ItemsSource = processManager.GetNeededProcesses();
            });
        }
    }
}
