using Newtonsoft.Json;
using System;

namespace MicroserviceManager.Views.TabContents.NodeJsProxyContent.Models
{
    public class NodeProxy
    {
        public Guid Id { get; set; }
        [JsonIgnore]
        public bool IsSelected { get; set; }
        public bool IsActive { get; set; }
        public string Title { get; set; }
        public string Source { get; set; }
        public string Target { get; set; }
    }
}
