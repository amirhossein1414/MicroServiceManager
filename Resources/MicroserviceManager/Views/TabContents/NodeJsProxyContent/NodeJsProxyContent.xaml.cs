using MicroserviceManager.Views.TabContents.NodeJsProxyContent.Models;
using MicroserviceManager.Views.TabContents.NodeJsProxyContent.NodeBussiness;
using MicroserviceManager.Views.TabContents.NodeJsProxyContent.ProxyView;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace MicroserviceManager.Views.TabContents.NodeJsProxyContent
{
    /// <summary>
    /// Interaction logic for NodeJsProxyContent.xaml
    /// </summary>
    public partial class NodeJsProxyContent : UserControl
    {
        private ProxyState ProxyState { get; set; } = ProxyState.stopped;
        private List<NodeProxyView> nodeProxyViews = new List<NodeProxyView>();
        public NodeJsProxyContent()
        {
            InitializeComponent();
            this.DataContext = this;
            this.ProxyStateChanged();
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            if (!NodeJsBusiness.IsNodeInstalled())
            {
                MessageBox.Show("node js is not installed.");
                return;
            }

            AddNewProxyView();
        }

        private void AddNewProxyView()
        {
            proxyGrid.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });

            var newProxy = new NodeProxyView();
            newProxy.Margin = new Thickness(0, 10, 0, 0);
            Grid.SetRow(newProxy, 0);
            newProxy.Changed += ProxyChanged;

            proxyGrid.Children.Add(newProxy);
            ShiftOtherProxies(nodeProxyViews);


            nodeProxyViews.Add(newProxy);// run this after shifting
        }

        private void ShiftOtherProxies(List<NodeProxyView> proxyViews)
        {
            proxyViews.ForEach(proxyView =>
            {
                var oldRowNumber = Grid.GetRow(proxyView);
                Grid.SetRow(proxyView, oldRowNumber+1);
            });
        }

        private void ProxyChanged(NodeProxy proxy, string propertyName)
        {

        }

        private void ProxyStateChanged()
        {
            start.IsEnabled = this.ProxyState == ProxyState.stopped;
            stop.IsEnabled = this.ProxyState == ProxyState.running;
            reset.IsEnabled = this.ProxyState == ProxyState.running;
        }

        private void StopProxy()
        {
            this.ProxyState = ProxyState.stopped;
            ProxyStateChanged();
        }

        private void StartProxy()
        {
            this.ProxyState = ProxyState.running;
            ProxyStateChanged();
        }

        private void RestartProxy()
        {
            StopProxy();
            StartProxy();
        }

        private void start_Click(object sender, RoutedEventArgs e)
        {
            StartProxy();
        }

        private void stop_Click(object sender, RoutedEventArgs e)
        {
            StopProxy();
        }

        private void reset_Click(object sender, RoutedEventArgs e)
        {
            RestartProxy();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            GlobalStaticNodeJsConfig.SaveConfig();
        }
    }

    public enum ProxyState
    {
        running,
        stopped,
    }
}
