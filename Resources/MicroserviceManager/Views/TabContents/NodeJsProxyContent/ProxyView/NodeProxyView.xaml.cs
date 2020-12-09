using MicroserviceManager.Views.TabContents.NodeJsProxyContent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Subjects;
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

namespace MicroserviceManager.Views.TabContents.NodeJsProxyContent.ProxyView
{
    /// <summary>
    /// Interaction logic for NodeProxyView.xaml
    /// </summary>
    public partial class NodeProxyView : UserControl
    {
        private NodeProxy Proxy { get; set; }
        public delegate void ProxyChanged(NodeProxy proxy, string propertyName);
        public event ProxyChanged Changed;
        public NodeProxyView(NodeProxy newProxy = null)
        {
            if (Proxy == null)
            {
                Proxy = new NodeProxy();
                GlobalStaticNodeJsConfig.AppGlobalConfig.NodeJsConfig.NodeProxyList.Add(Proxy);
            }

            InitializeComponent();


            if (newProxy != null)
            {
                Proxy = newProxy;
                isSelected.IsChecked = Proxy.IsSelected;
                title.Text = Proxy.Title;
                source.Text = Proxy.Source;
                target.Text = Proxy.Target;
                isActive.IsChecked = Proxy.IsActive;
            }
        }

        private void onIsSelectedChanged(object sender, RoutedEventArgs e)
        {
            var chbx = sender as CheckBox;
            this.Proxy.IsSelected = chbx.IsChecked == true;
            this.Changed?.Invoke(Proxy, "IsChecked");
        }

        private void isSelected_Checked(object sender, RoutedEventArgs e)
        {
            onIsSelectedChanged(sender, e);
        }

        private void isSelected_Unchecked(object sender, RoutedEventArgs e)
        {
            onIsSelectedChanged(sender, e);
        }

        private void title_TextChanged(object sender, TextChangedEventArgs e)
        {
            var element = sender as TextBox;
            this.Proxy.Title = element.Text;
            this.Changed?.Invoke(Proxy, "Title");
        }

        private void source_TextChanged(object sender, TextChangedEventArgs e)
        {
            var element = sender as TextBox;
            this.Proxy.Source = element.Text;
            this.Changed?.Invoke(Proxy, "Source");
        }

        private void target_TextChanged(object sender, TextChangedEventArgs e)
        {
            var element = sender as TextBox;
            this.Proxy.Target = element.Text;
            this.Changed?.Invoke(Proxy, "Target");
        }

        private void active_Checked(object sender, RoutedEventArgs e)
        {
            var element = sender as CheckBox;
            this.Proxy.IsActive = element.IsChecked == true;
            this.Changed?.Invoke(Proxy, "IsActive");
        }

        private void active_Unchecked(object sender, RoutedEventArgs e)
        {
            var element = sender as CheckBox;
            this.Proxy.IsActive = element.IsChecked == true;
            this.Changed?.Invoke(Proxy, "IsActive");
        }
    }
}
