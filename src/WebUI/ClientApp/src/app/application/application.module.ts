import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AppLayoutComponent } from '../_layout/app-layout/app-layout.component';
import { RouterModule } from '@angular/router';
import { MainNavComponent } from './main-nav/main-nav.component';
import { SideNavComponent } from './side-nav/side-nav.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { FormsModule } from '@angular/forms';
import { MDBBootstrapModule } from 'angular-bootstrap-md';
import { DashboardWidgetComponent } from './dashboard-widget/dashboard-widget.component';
import { AccountsComponent } from './accounts/accounts.component';
import { AccountsWidgetComponent } from './accounts-widget/accounts-widget.component';
import { ReportsComponent } from './reports/reports.component';
import { PlansComponent } from './plans/plans.component';

@NgModule({
  imports: [
    CommonModule,
    RouterModule,
    FormsModule,
    MDBBootstrapModule.forRoot()
  ],
  declarations: [
    AppLayoutComponent,
    MainNavComponent,
    SideNavComponent,
    DashboardComponent,
    DashboardWidgetComponent,
    AccountsComponent,
    AccountsWidgetComponent,
    ReportsComponent,
    PlansComponent
  ]

})
export class WebAppModule { }
