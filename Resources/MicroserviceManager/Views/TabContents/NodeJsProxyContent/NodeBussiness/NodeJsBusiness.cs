using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroserviceManager.Views.TabContents.NodeJsProxyContent.NodeBussiness
{
    public class NodeJsBusiness
    {
        public static bool IsNodeInstalled()
        {
            var result = ExistsOnPath("node.exe");
            return result;
        }
        private static bool ExistsOnPath(string fileName)
        {
            return GetFullPath(fileName) != null;
        }

        private static string GetFullPath(string fileName)
        {
            if (File.Exists(fileName))
                return Path.GetFullPath(fileName);

            var values = Environment.GetEnvironmentVariable("PATH");
            foreach (var path in values.Split(Path.PathSeparator))
            {
                var fullPath = Path.Combine(path, fileName);
                if (File.Exists(fullPath))
                    return fullPath;
            }
            return null;
        }
    }
}
