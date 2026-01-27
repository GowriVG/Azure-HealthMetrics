import { FunctionApp } from './function-app.model';
import { AppServicePlan } from './app-service-plan.model';

export interface DashboardData {
  functionApps: FunctionApp[];
  stoppedApps: FunctionApp[];
  appServicePlans: AppServicePlan[];
}
