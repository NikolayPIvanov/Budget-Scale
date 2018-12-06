import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GroupsListComponent } from './groups-list/groups-list.component';
import { OverviewComponent } from './overview/overview.component';

@NgModule({
  imports: [
    CommonModule
  ],
  declarations: [GroupsListComponent, OverviewComponent]
})
export class DashboardModule { }
