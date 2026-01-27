// DashboardResponseDto defines the API contract for the dashboard endpoint, grouping all required data into a single, strongly typed response object
namespace AzureHealth.Models
{
    public class DashboardResponseDto
    {
        // This list holds the running function apps
        public List<FunctionAppDto> FunctionApps { get; set; } = new List<FunctionAppDto>();

        // This list holds the app service plans
        public List<AppServicePlanDto> AppServicePlans { get; set; } = new List<AppServicePlanDto>();

        // This list holds the stopped function apps
        public List<FunctionAppDto> StoppedApps { get; set; } = new List<FunctionAppDto>();
    }
}
