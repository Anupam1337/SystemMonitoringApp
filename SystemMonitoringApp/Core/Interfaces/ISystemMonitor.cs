using SystemMonitoringApp.Core.Models;

namespace SystemMonitoringApp.Core.Interfaces
{
    public interface ISystemMonitor
    {
        SystemStats GetSystemStats();
    }

}
