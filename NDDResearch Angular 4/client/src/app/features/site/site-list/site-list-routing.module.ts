import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { SiteListComponent } from './site-list.component';

const siteListRoutes: Routes = [
    {
        path: '',
        component: SiteListComponent,
    },
];

@NgModule({
    imports: [RouterModule.forChild(siteListRoutes)],
    exports: [RouterModule],
    declarations: [],
    providers: [],
})
export class SiteListRoutingModule { }
