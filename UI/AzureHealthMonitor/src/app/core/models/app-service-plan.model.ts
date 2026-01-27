export interface AppServicePlan {
  name: string;
  resourceGroup: string;
  region: string;
  operatingSystem: string;
  planTier: string;
  planSize: string;
  cpuUtilization: number;   // 0-100
  memoryPercent: number;    // 0-100
  instances: number;
  appCount: number;
}