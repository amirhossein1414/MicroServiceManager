using System.Windows;
using System.Windows.Controls;

namespace MicroserviceManager.Views.TabContents.WebTabContent
{
    /// <summary>
    /// Interaction logic for WebTabContent.xaml
    /// </summary>
    public partial class WebTabContent : UserControl
    {
        public static string TabHeader { get; set; } = "Web Repo";
        public WebTabContent()
        {
            InitializeComponent();
        }

        private void CloseW3ProcessesBtn_Click(object sender, RoutedEventArgs e)
        {
            ProcesseView.CloseW3s();
        }

        private void ClearNugetsBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
