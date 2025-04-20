using Microsoft.Extensions.Configuration;
using SystemMonitoringApp.Configuration;
using SystemMonitoringApp.Core.Interfaces;
using SystemMonitoringApp.Plugins;
using SystemMonitoringApp.Services;

var config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: false)
    .Build();

var settings = config.Get<MonitorConfig>();
var monitor = new DefaultSystemMonitor();

List<IMonitorPlugin> plugins = new()
{
    new FileLoggerPlugin(),
    new ApiReporterPlugin(settings.ApiUrl)
};

Console.WriteLine("System Monitor Started. Press Ctrl+C to stop.");

while (true)
{
    var stats = monitor.GetSystemStats();

    Console.WriteLine($"CPU: {stats.CpuUsage:F2}% | RAM: {stats.RamUsedMB:F2} MB | DISK: {stats.DiskUsedMB:F2} MB");

    foreach (var plugin in plugins)
    {
        try { plugin.OnSystemStatsReceived(stats); }
        catch (Exception ex) { Console.WriteLine($"Plugin error: {ex.Message}"); }
    }

    Thread.Sleep(settings.IntervalSeconds * 1000);
}
