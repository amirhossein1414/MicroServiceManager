using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace MicroserviceManager
{
    public class ProcessManager
    {
        public List<Process> GetAll()
        {
            var all = Process.GetProcesses()?.ToList();
            //var names = all.Select(x => new { x.ProcessName, x.Id }).OrderBy(x=>x.ProcessName).ToList();
            return all;
        }

        public void CloseW3Processes()
        {
            var w3s = GetAll().Where(x => x.ProcessName.Contains("w3")).ToList();
            foreach(var process in w3s ?? Enumerable.Empty<Process>())
            {
                process.Close();
            }
        }
    }
}
