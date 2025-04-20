using SystemMonitoringApp.Core.Models;

namespace SystemMonitoringApp.Core.Interfaces
{
    public interface IMonitorPlugin
    {
        void OnSystemStatsReceived(SystemStats stats);
    }

}
