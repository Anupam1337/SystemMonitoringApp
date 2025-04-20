using System.Diagnostics;
using SystemMonitoringApp.Core.Interfaces;
using SystemMonitoringApp.Core.Models;

namespace SystemMonitoringApp.Services
{
    public class DefaultSystemMonitor : ISystemMonitor
    {
        private readonly PerformanceCounter _cpuCounter = new("Processor", "% Processor Time", "_Total");

        public SystemStats GetSystemStats()
        {
            _cpuCounter.NextValue(); // First value is 0
            Thread.Sleep(500); // Wait a bit

            float cpu = _cpuCounter.NextValue();
            float ram = Environment.WorkingSet / (1024f * 1024f);
            float diskUsed = GetDiskUsed();

            return new SystemStats { CpuUsage = cpu, RamUsedMB = ram, DiskUsedMB = diskUsed };
        }

        private float GetDiskUsed()
        {
            var drive = DriveInfo.GetDrives().FirstOrDefault(d => d.IsReady && d.Name == "C:\\");
            if (drive == null) return 0;

            long used = drive.TotalSize - drive.TotalFreeSpace;
            return used / (1024f * 1024f);
        }
    }

}
