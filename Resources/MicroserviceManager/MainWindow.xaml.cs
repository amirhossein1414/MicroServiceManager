using System;
using System.Windows;

namespace MicroserviceManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            try
            {
                InitializeComponent();
                var manager = new ProcessManager();
                manager.GetAll();
            }
            catch (Exception ex)
            {

            }
        }
    }
}
