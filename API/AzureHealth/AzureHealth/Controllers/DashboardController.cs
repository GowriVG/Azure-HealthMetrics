using AzureHealth.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AzureHealth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetDashboardData()
        {
            // --- 1. Data for "Stopped Function Apps" Section ---
            var stoppedApps = new List<FunctionAppDto>
            {
                new FunctionAppDto { Name = "eep-availabilitytracker-iepc", Status = "Stopped" },
                new FunctionAppDto { Name = "eep-beslods-publisher-iepc", Status = "Stopped" },
                new FunctionAppDto { Name = "eep-listener-iepc-bot", Status = "Stopped" },
                new FunctionAppDto { Name = "eep-listener-iepc-cids", Status = "Stopped" }
            };

            // --- 2. Data for "App Service Plans" Section ---
            var plans = new List<AppServicePlanDto>
            {
                new AppServicePlanDto {
                    Name = "a3iepceepasp02t", ResourceGroup = "a3iepceeprgs01t", Region = "centralus",
                    OperatingSystem = "windows", PlanTier = "isolatedv2", PlanSize = "i2v2",
                    CpuUtilization = 10.81, MemoryPercent = 44.8, Instances = 9, AppCount = 11
                },
                new AppServicePlanDto {
                    Name = "a3iepceepasp01t", ResourceGroup = "a3iepceeprgs01t", Region = "centralus",
                    OperatingSystem = "windows", PlanTier = "isolatedv2", PlanSize = "i2v2",
                    CpuUtilization = 9.40, MemoryPercent = 51.4, Instances = 9, AppCount = 11
                },
                new AppServicePlanDto {
                    Name = "a3iepceepasp06t", ResourceGroup = "a3iepceeprgs01t", Region = "centralus",
                    OperatingSystem = "windows", PlanTier = "isolatedv2", PlanSize = "i2v2",
                    CpuUtilization = 9.07, MemoryPercent = 41.2, Instances = 9, AppCount = 9
                },
                new AppServicePlanDto {
                    Name = "a3iepceepasp03t", ResourceGroup = "a3iepceeprgs01t", Region = "centralus",
                    OperatingSystem = "windows", PlanTier = "isolatedv2", PlanSize = "i2v2",
                    CpuUtilization = 10.11, MemoryPercent = 41.4, Instances = 9, AppCount = 8
                },
                // High load example
                new AppServicePlanDto {
                    Name = "a3iepceepasp101t", ResourceGroup = "a3iepceeprgs01t", Region = "centralus",
                    OperatingSystem = "windows", PlanTier = "isolatedv2", PlanSize = "i1v2",
                    CpuUtilization = 88.3, MemoryPercent = 59.9, Instances = 3, AppCount = 8
                }
            };

            // --- 3. Data for "Function App Details" (Running) Section ---
            var runningApps = new List<FunctionAppDto>
            {
                new FunctionAppDto {
                    Name = "eep-listener-iepc-apm", ResourceGroup = "a3iepceeprgs01t", Region = "centralus",
                    ServerFarmId = "a3iepceepasp04t", Status = "Running",
                    AvgResponseTime = 10.9, MemoryUsed = "584 MiB", HealthCheck = 100
                },
                new FunctionAppDto {
                    Name = "eep-listener-iepc-bac", ResourceGroup = "a3iepceeprgs01t", Region = "centralus",
                    ServerFarmId = "a3iepceepasp02t", Status = "Running",
                    AvgResponseTime = 14.8, MemoryUsed = "373 MiB", HealthCheck = 100
                },
                new FunctionAppDto {
                    Name = "eep-listener-iepc-bkops", ResourceGroup = "a3iepceeprgs01t", Region = "centralus",
                    ServerFarmId = "a3iepceepasp04t", Status = "Running",
                    AvgResponseTime = 11.1, MemoryUsed = "547 MiB", HealthCheck = 100
                },
                new FunctionAppDto {
                    Name = "eep-listener-iepc-bpp", ResourceGroup = "a3iepceeprgs01t", Region = "centralus",
                    ServerFarmId = "a3iepceepasp03t", Status = "Running",
                    AvgResponseTime = 13.0, MemoryUsed = "594 MiB", HealthCheck = 100
                },
                new FunctionAppDto {
                    Name = "eep-listener-iepc-bridge", ResourceGroup = "a3iepceeprgs01t", Region = "centralus",
                    ServerFarmId = "a3iepceepasp02t", Status = "Running",
                    AvgResponseTime = 14.7, MemoryUsed = "281 MiB", HealthCheck = 100
                }
            };

            // Combine into the single response object
            var response = new DashboardResponseDto
            {
                FunctionApps = runningApps,
                StoppedApps = stoppedApps,
                AppServicePlans = plans
            };

            return Ok(response);
        }
    }
}
