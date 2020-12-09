using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MicroserviceManager.Views.TabContents.NodeJsProxyContent.Models
{
    public static class GlobalStaticNodeJsConfig
    {
        public static AppGlobalConfig AppGlobalConfig = new AppGlobalConfig();

        public static void LoadConfig()
        {
            try
            {
                if (File.Exists("config.json"))
                {
                    var configJson = File.ReadAllText("config.json");
                    var configClass = JsonConvert.DeserializeObject<AppGlobalConfig>(configJson);
                    AppGlobalConfig = configClass;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public static void SaveConfig()
        {
            try
            {
                var configJson = JsonConvert.SerializeObject(AppGlobalConfig, Formatting.Indented);
                File.WriteAllText("config.json", configJson);
                MessageBox.Show("Saved !");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
