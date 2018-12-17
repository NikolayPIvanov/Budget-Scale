import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AdminDashboardComponent } from './admin-dashboard/admin-dashboard.component';
import { RequestsManagerComponent } from './requests-manager/requests-manager.component';
import { MessagesComponent } from './messages/messages.component';
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { MDBBootstrapModule } from 'angular-bootstrap-md';

@NgModule({
  declarations: [AdminDashboardComponent, RequestsManagerComponent, MessagesComponent],
  imports: [
    CommonModule,
    RouterModule,
    FormsModule,
    MDBBootstrapModule.forRoot()
  ]
})
export class AdministratorModule { }
