import { Routes, RouterModule } from "@angular/router";
import { SiteLayoutComponent } from "./_layout/site-layout/site-layout.component";
import { HomeComponent } from "./home/home.component";
import { ContactUsComponent } from "./contact-us/contact-us.component";
import { AuthenticationComponent } from "./_layout/authentication/authentication.component";
import { LoginComponent } from "./authentication/login/login.component";
import { RegisterComponent } from "./authentication/register/register.component";
import { AppLayoutComponent } from "./_layout/app-layout/app-layout.component";
import { AdminLayoutComponent } from "./_layout/admin-layout/admin-layout.component";
import { DashboardComponent } from "./application/dashboard/dashboard.component";
import { AccountsComponent } from "./application/accounts/accounts.component";
import { PlansComponent } from "./application/plans/plans.component";
import { ReportsComponent } from "./application/reports/reports.component";
import { AccountOptionsComponent } from "./application/account-options/account-options.component";
import { AdminDashboardComponent } from "./administrator/admin-dashboard/admin-dashboard.component";
import { RequestsManagerComponent } from "./administrator/requests-manager/requests-manager.component";


const appRoutes: Routes = [
    {
        path: '',
        component: SiteLayoutComponent,
        children: [
            { path: '', component: HomeComponent, pathMatch: 'full' },
            { path: 'contact', component: ContactUsComponent },
        ]
    },

    {
        path: '',
        component: AuthenticationComponent,
        children: [
            { path: 'login', component: LoginComponent },
            { path: 'register', component: RegisterComponent }
        ]
    },

    {
        path: '',
        component: AppLayoutComponent,
        children: [
            { path: 'dashboard', component: DashboardComponent },
            { path: 'accounts', component: AccountsComponent },
            { path: 'reports', component: ReportsComponent },
            { path: 'plans', component: PlansComponent },
            { path: 'options', component: AccountOptionsComponent }
        ]
    },

    {
        path: 'admin/',
        component: AdminLayoutComponent,
        children: [
            { path: 'dashboard', component: AdminDashboardComponent },
            { path: 'requests', component: RequestsManagerComponent },
        ]
    },

    { path: '**', redirectTo: '' }
]

export const routing = RouterModule.forRoot(appRoutes); 