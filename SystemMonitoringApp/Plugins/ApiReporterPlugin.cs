using System.Text;
using System.Text.Json;
using SystemMonitoringApp.Core.Interfaces;
using SystemMonitoringApp.Core.Models;

namespace SystemMonitoringApp.Plugins
{
    public class ApiReporterPlugin : IMonitorPlugin
    {
        private readonly string _url;

        public ApiReporterPlugin(string url)
        {
            _url = url;
        }

        public void OnSystemStatsReceived(SystemStats stats)
        {
            var payload = new
            {
                cpu = stats.CpuUsage,
                ram_used = stats.RamUsedMB,
                disk_used = stats.DiskUsedMB
            };

            using var client = new HttpClient();
            var content = new StringContent(JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json");
            client.PostAsync(_url, content).Wait();
        }
    }

}
