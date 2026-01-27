export interface FunctionApp {
  name: string;
  resourceGroup: string;
  region: string;
  serverFarmId?: string; // Optional because stopped apps might not list it
  status: 'Running' | 'Stopped';
  avgResponseTime?: number; // In ms (nullable)
  memoryUsed: string;       // e.g., "584 MiB"
  healthCheck: number;      // 0-100 score
}