import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AppLayoutComponent } from '../_layout/app-layout/app-layout.component';
import { RouterModule } from '@angular/router';
import { MainNavComponent } from './main-nav/main-nav.component';
import { SideNavComponent } from './side-nav/side-nav.component';
import { MatSidenavModule } from '@angular/material/sidenav';

@NgModule({
  imports: [
    CommonModule,
    RouterModule,
    MatSidenavModule
  ],
  declarations: [AppLayoutComponent, MainNavComponent, SideNavComponent]
})
export class ApplicationModule { }
