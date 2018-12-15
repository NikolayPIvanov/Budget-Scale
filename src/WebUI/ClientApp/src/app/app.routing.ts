import { Routes, RouterModule } from "@angular/router";
import { SiteLayoutComponent } from "./_layout/site-layout/site-layout.component";
import { HomeComponent } from "./home/home.component";
import { CounterComponent } from "./counter/counter.component";
import { ContactUsComponent } from "./contact-us/contact-us.component";
import { AuthenticationComponent } from "./_layout/authentication/authentication.component";
import { LoginComponent } from "./authentication/login/login.component";


const appRoutes: Routes = [
    {
        path: '',
        component: SiteLayoutComponent,
        children: [
            { path: '', component: HomeComponent, pathMatch: 'full' },
            { path: 'counter', component: CounterComponent },
            { path: 'contact', component: ContactUsComponent },
        ]
    },

    {
        path: '',
        component: AuthenticationComponent,
        children: [
            { path: 'login', component: LoginComponent }
        ]
    },

    { path: '**', redirectTo: '' }
]

export const routing = RouterModule.forRoot(appRoutes); 