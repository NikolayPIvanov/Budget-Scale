import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HttpClientXsrfModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { HomeComponent } from './modules/home/home.component';
import { UsersModule } from './modules/users/users.module';
import { LoginFormComponent } from './modules/users/login-form/login-form.component';
import { AuthGuard } from './services/authentication/auth.guard';
import { RegisterFormComponent } from './modules/users/register-form/register-form.component';
import { GroupsListComponent } from './modules/dashboard/groups-list/groups-list.component';
import { DashboardModule } from './modules/dashboard/dashboard.module';
import { NavMenuComponent } from './modules/shared/nav-menu/nav-menu.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    HttpClientXsrfModule.withOptions({
      cookieName: 'Access_Token',
    }),
    FormsModule,
    UsersModule,
    DashboardModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'login', component: LoginFormComponent },
      { path: 'register', component: RegisterFormComponent },
      { path: 'groups', component: GroupsListComponent, canActivate: [AuthGuard] }
    ])
  ],
  providers: [AuthGuard],
  bootstrap: [AppComponent]
})
export class AppModule { }
