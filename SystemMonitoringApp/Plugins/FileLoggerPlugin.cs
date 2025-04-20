using SystemMonitoringApp.Core.Interfaces;
using SystemMonitoringApp.Core.Models;

namespace SystemMonitoringApp.Plugins
{
    public class FileLoggerPlugin : IMonitorPlugin
    {
        private readonly string _filePath = "system_log.txt";

        public void OnSystemStatsReceived(SystemStats stats)
        {
            string log = $"[{DateTime.Now}] CPU: {stats.CpuUsage:F2}% | RAM: {stats.RamUsedMB:F2}MB | DISK: {stats.DiskUsedMB:F2}MB";
            File.AppendAllText(_filePath, log + Environment.NewLine);
        }
    }

}
