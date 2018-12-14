import { Routes, RouterModule } from "@angular/router";
import { SiteLayoutComponent } from "./_layout/site-layout/site-layout.component";
import { HomeComponent } from "./home/home.component";
import { CounterComponent } from "./counter/counter.component";
import { FetchDataComponent } from "./fetch-data/fetch-data.component";
import { ContactUsComponent } from "./contact-us/contact-us.component";


const appRoutes: Routes = [
    {
        path: '',
        component: SiteLayoutComponent,
        children: [
            { path: '', component: HomeComponent, pathMatch: 'full' },
            { path: 'counter', component: CounterComponent },
            { path: 'contact', component: ContactUsComponent },
            { path: 'fetch-data', component: FetchDataComponent }
        ]
    },

    { path: '**', redirectTo: '' }
]

export const routing = RouterModule.forRoot(appRoutes);