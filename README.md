# Cross-Platform System Monitor (C# Console App)

## Overview

This is a cross-platform system monitoring console application developed in C# (.NET 6+) that tracks CPU, RAM, and Disk usage in real-time. The application is designed with a plugin architecture for easy extensibility, allowing plugins such as local file loggers or REST API integrations. The core logic is abstracted and platform-independent, making it adaptable to Windows, Linux, and macOS.

---

## Features

- ✅ Real-time monitoring of:
  - CPU usage (%)
  - Private RAM usage (used/total)
  - Disk usage (used/total)
- ✅ Console output at configurable intervals
- ✅ Plugin architecture using `IMonitorPlugin`
- ✅ Sample plugin: logs data to a local file
- ✅ Sample plugin: posts data to a REST API (JSON payload)
- ✅ Configurable API endpoint in `appsettings.json`
- ✅ Dependency Injection and Clean Architecture
- ✅ Exception handling with robust logging

---

## Architecture

- **Clean Architecture Pattern**
  - Separation into Core, Infrastructure, Plugins, and Console App layers
  - Strategy pattern used for platform-specific system monitoring
- **Dependency Injection**
  - Services are registered via .NET's `HostBuilder`
  - Plugins and monitor services injected for loose coupling
- **Cross-Platform Support**
  - Windows implementation using PerformanceCounters
  - Abstraction allows for Linux/macOS implementations later

---

## How to Build and Run

### Prerequisites

- Visual Studio 2022 (or later)
- .NET 6 SDK (or later)

### Steps

1. Clone or download the repository.
2. Open the solution file (`SystemMonitor.sln`) in Visual Studio.
3. Configure `appsettings.json` as needed:

```json
{
  "Monitoring": {
    "IntervalSeconds": 5
  },
  "ApiSettings": {
    "EndpointUrl": "http://localhost:5054/api/systemmonitoring"
  }
}
```

4. Start your API project if testing API integration.
5. Run the console application.
6. Observe real-time output in the console.

---

## Example `.http` Test File

```http
@SystemMonitoringApi_HostAddress = http://localhost:5054

### POST system stats to API
POST {{SystemMonitoringApi_HostAddress}}/api/systemmonitoring
Content-Type: application/json
Accept: application/json

{
  "cpu": 32.5,
  "ram_used": 4096.5,
  "disk_used": 102400.2
}
```

---

## Design Decisions and Challenges

- Chose a **single project architecture** to reduce overhead and improve cohesion for a console utility.
- Plugin system ensures extensibility without modifying core logic.
- Used **PerformanceCounter** (Windows) and encapsulated logic behind interfaces for future Linux/macOS support.
- Challenge: Reliable cross-platform memory/disk stats required abstraction for future extensibility.
- Logging and exception handling ensure maintainability and debuggability.

---

## Limitations and Future Enhancements

- Current platform support is limited to Windows.
- No GUI; console only (as per requirement).
- Plugins could be further enhanced for Slack/Webhooks/etc.
- File logger is simple; structured logging or log rotation can be added.

---

## Demo Preparation Checklist

- ✅ Run console app to show real-time stats
- ✅ Show `appsettings.json` for interval/API
- ✅ Show local file log updates
- ✅ Send sample data via plugin to REST API
- ✅ Use `.http` file to simulate/test
- ✅ Open source code and explain architecture & DI

---

## License

MIT License

---

## Author

Anupam Mishra [anupmis20@gmail.com](mailto\:anupmis20@gmail.com)

