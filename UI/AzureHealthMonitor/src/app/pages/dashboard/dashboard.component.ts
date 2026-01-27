import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DashboardService } from '../../core/services/dashboard.service';
import { FunctionApp } from '../../core/models/function-app.model';
import { AppServicePlan } from '../../core/models/app-service-plan.model';
import { NgxChartsModule, Color, ScaleType } from '@swimlane/ngx-charts';

@Component({
  selector: 'app-dashboard',
  standalone: true,
  imports: [CommonModule, NgxChartsModule],
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {

  functionApps: FunctionApp[] = [];
  stoppedApps: FunctionApp[] = [];
  appServicePlans: AppServicePlan[] = [];
  isLoading = true;

  // Chart Data Holders
  healthData: any[] = [];
  osData: any[] = [];
  cpuData: any[] = [];

  // Chart Options
  showLegend = true;
  showLabels = true;
  isDoughnut = true;
  
  // Custom Color Schemes to match Azure Theme
  healthColorScheme: Color = {
    name: 'azureHealth',
    selectable: true,
    group: ScaleType.Ordinal,
    domain: ['#7fba00', '#e00b1c'] // Azure Green, Azure Red
  };

  osColorScheme: Color = {
    name: 'azureOS',
    selectable: true,
    group: ScaleType.Ordinal,
    domain: ['#0078d4', '#ffaa44', '#8764b8'] 
  };

  resourceColorScheme: Color = {
    name: 'azureResource',
    selectable: true,
    group: ScaleType.Ordinal,
    domain: ['#00bcf2'] // Light Blue for bars
  };

  constructor(private dashboardService: DashboardService) {}

  ngOnInit(): void {
    this.loadDashboard();
  }

  loadDashboard(): void {
    this.dashboardService.getDashboardData().subscribe({
      next: (data) => {
        this.functionApps = data.functionApps;
        this.stoppedApps = data.stoppedApps;
        this.appServicePlans = data.appServicePlans;
        
        // 1. Prepare Health Data (Running vs Stopped)
        this.healthData = [
          { name: 'Healthy', value: this.functionApps.length },
          { name: 'Stopped', value: this.stoppedApps.length }
        ];

        // 2. Prepare OS Distribution Data
        const osCounts: {[key: string]: number} = {};
        this.appServicePlans.forEach(plan => {
          const os = plan.operatingSystem || 'Unknown';
          osCounts[os] = (osCounts[os] || 0) + 1;
        });
        this.osData = Object.keys(osCounts).map(key => ({ name: key, value: osCounts[key] }));

        // 3. Prepare CPU Usage Data (Top 5 busiest plans)
        this.cpuData = this.appServicePlans
          .map(plan => ({ name: plan.name, value: plan.cpuUtilization }))
          .sort((a, b) => b.value - a.value)
          .slice(0, 5); // Show top 5

        this.isLoading = false;
      },
      error: () => {
        this.isLoading = false;
      }
    });
  }
}