﻿using MicroserviceManager.Views.TabContents.NodeJsProxyContent.Models;
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
            GlobalStaticNodeJsConfig.LoadConfig();
        }
    }
}
