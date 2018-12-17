import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AdminDashboardComponent } from './admin-dashboard/admin-dashboard.component';
import { RequestsManagerComponent } from './requests-manager/requests-manager.component';

@NgModule({
  declarations: [AdminDashboardComponent, RequestsManagerComponent],
  imports: [
    CommonModule
  ]
})
export class AdministratorModule { }
