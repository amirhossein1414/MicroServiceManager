using System.Collections.Generic;

namespace MicroserviceManager.Views.TabContents.NodeJsProxyContent.Models
{
    public class NodeJsConfig
    {
        public bool IsNodeInstalled { get; set; }
        public List<NodeProxy> NodeProxyList { get; set; }

        public NodeJsConfig()
        {
            NodeProxyList = new List<NodeProxy>();
        }
    }
}
