namespace AzureHealth.Models
{
    public class FunctionAppDto
    {
        public string Name { get; set; } = string.Empty;
        public string ResourceGroup { get; set; } = string.Empty;
        public string Region { get; set; } = string.Empty;
        public string? ServerFarmId { get; set; } // Nullable (?) allows this to be empty for stopped apps
        public string Status { get; set; } = "Unknown";

        // Metrics are nullable (?) because stopped apps don't have these values
        public double? AvgResponseTime { get; set; }
        public string MemoryUsed { get; set; } = "0 MiB";
        public int HealthCheck { get; set; } = 0;
    }
}
