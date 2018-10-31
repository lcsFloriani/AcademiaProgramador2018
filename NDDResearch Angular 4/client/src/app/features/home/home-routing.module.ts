import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { HomeComponent } from './home.component';

const homeRoutes: Routes = [
    {
        path: '',
        component: HomeComponent,
    },
];
@NgModule({
    imports: [RouterModule.forChild(homeRoutes)],
    exports: [RouterModule],
    declarations: [],
    providers: [],
})
export class HomeRoutingModule { }
