import { BrowserModule } from '@angular/platform-browser';
import { NgModule, ApplicationModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { NgbPaginationModule, NgbAlertModule } from '@ng-bootstrap/ng-bootstrap';


import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { SiteLayoutComponent } from './_layout/site-layout/site-layout.component';

import { routing } from './app.routing';
import { ContactUsComponent } from './contact-us/contact-us.component';
import { AuthenticationModule } from './authentication/authentication.module';
import { AdminLayoutComponent } from './_layout/admin-layout/admin-layout.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { WebAppModule } from './application/application.module';
import { AdministratorModule } from './administrator/administrator.module';
import { MainNavComponent } from './application/main-nav/main-nav.component';
import { SideNavComponent } from './application/side-nav/side-nav.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    SiteLayoutComponent,
    ContactUsComponent,
    AdminLayoutComponent,

  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    NgbModule,
    NgbAlertModule,
    NgbPaginationModule,
    HttpClientModule,
    FormsModule,
    BrowserAnimationsModule,
    routing,
    AuthenticationModule,
    AdministratorModule,
    WebAppModule,
    RouterModule.forRoot([
    ]),
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
