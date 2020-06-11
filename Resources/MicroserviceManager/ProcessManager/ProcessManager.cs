using MicroserviceManager.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management;

namespace MicroserviceManager
{
    public class ProcessManager
    {
        private ManagementEventWatcher processStartWatcher;
        private ManagementEventWatcher processStopWatcher;
        public List<Process> GetAll()
        {
            var all = Process.GetProcesses()?.ToList();
            return all;
        }

        public void CloseW3Processes()
        {
            var w3s = GetAll().Where(x => x.ProcessName.Contains("w3")).ToList();
            foreach (var process in w3s ?? Enumerable.Empty<Process>())
            {
                process.Kill();
            }
        }

        public List<Process> GetW3Processes()
        {
            var w3s = GetAll().Where(x => x.ProcessName.Contains("w3")).ToList();
            return w3s;
        }

        public IEnumerable<ShowingProcess> GetNeededProcesses()
        {
            var result = GetW3Processes().Select(x => new ShowingProcess() { Name = x.ProcessName, UserName = GetProcessOwner(x.Id) });
            return result;
        }

        private string GetProcessOwner(int processId)
        {
            try
            {
                string query = "Select * From Win32_Process Where ProcessID = " + processId;
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);
                ManagementObjectCollection processList = searcher.Get();

                foreach (ManagementObject obj in processList)
                {
                    string[] argList = new string[] { string.Empty, string.Empty };
                    int returnVal = Convert.ToInt32(obj?.InvokeMethod("GetOwner", argList));
                    if (returnVal == 0)
                    {
                        // return DOMAIN\user
                        return argList[1] + "\\" + argList[0];
                    }
                }

                return "";
            }
            catch
            {
                return "";
            }
        }

        public void OnNewProcessStart(Action<object, EventArrivedEventArgs> onProcessChange)
        {
            if (processStartWatcher == null)
            {
                processStartWatcher = new ManagementEventWatcher(
                 new WqlEventQuery("SELECT * FROM Win32_ProcessStartTrace"));
                processStartWatcher.Start();

                //Console.WriteLine("Process started: {0}", e.NewEvent.Properties["ProcessName"].Value);
            }

            processStartWatcher.EventArrived += new EventArrivedEventHandler(onProcessChange);
        }

        public void OnNewProcessStop(Action<object, EventArrivedEventArgs> onProcessChange)
        {
            if (processStopWatcher == null)
            {
                processStopWatcher = new ManagementEventWatcher(
                 new WqlEventQuery("SELECT * FROM Win32_ProcessStopTrace"));
                processStopWatcher.Start();

                //Console.WriteLine("Process started: {0}", e.NewEvent.Properties["ProcessName"].Value);
            }

            processStopWatcher.EventArrived += new EventArrivedEventHandler(onProcessChange);
        }
    }
}
