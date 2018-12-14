import { Routes, RouterModule } from "@angular/router";
import { SiteLayoutComponent } from "./_layout/site-layout/site-layout.component";
import { HomeComponent } from "./home/home.component";


const appRoutes: Routes = [
    {
        path: '',
        component: SiteLayoutComponent,
        children: [
            { path: '', component: HomeComponent, pathMatch: 'full' },
        ]
    },

    { path: '**', redirectTo: '' }
]

export const routing = RouterModule.forRoot(appRoutes);