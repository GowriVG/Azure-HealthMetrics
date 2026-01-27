namespace AzureHealth.Models
{
    public class AppServicePlanDto
    {
        //This makes the Name property accessible from any other class or code that references this class (AppServicePlanDto).
        // get allows you to retrieve the value of the property.
        // set allows you to assign a value to the property.
        public string Name { get; set; } = string.Empty;
        public string ResourceGroup { get; set; } = string.Empty;
        public string Region { get; set; } = string.Empty;
        public string OperatingSystem { get; set; } = "Windows";
        public string PlanTier { get; set; } = "Standard";
        public string PlanSize { get; set; } = "S1";

        // Metrics
        public double CpuUtilization { get; set; }
        public double MemoryPercent { get; set; }
        public int Instances { get; set; }
        public int AppCount { get; set; }
    }
}
