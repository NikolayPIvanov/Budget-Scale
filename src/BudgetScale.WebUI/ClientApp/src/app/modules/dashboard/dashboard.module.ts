import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GroupsListComponent } from './groups-list/groups-list.component';
import { OverviewComponent } from './overview/overview.component';
import { DashboardPageComponent } from './dashboard-page/dashboard-page.component';

@NgModule({
  imports: [
    CommonModule
  ],
  declarations: [GroupsListComponent, OverviewComponent, DashboardPageComponent],
  providers: [GroupsListComponent]
})
export class DashboardModule { }
