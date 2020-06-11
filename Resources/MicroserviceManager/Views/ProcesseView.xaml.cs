using System.Runtime.CompilerServices;
using System.Windows.Controls;

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
            RefreshGrid();
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
