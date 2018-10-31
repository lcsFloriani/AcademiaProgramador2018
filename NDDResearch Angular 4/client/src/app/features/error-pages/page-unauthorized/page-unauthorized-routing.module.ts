import { NgModule } from '@angular/core';
import { PageUnauthorizedComponent } from './page-unauthorized.component';
import { RouterModule, Routes } from '@angular/router';

const pageUnauthorizedRoutes: Routes = [
    {
        path: '',
        component: PageUnauthorizedComponent,
    },
];
@NgModule({
    imports: [RouterModule.forChild(pageUnauthorizedRoutes)],
    exports: [RouterModule],
})
export class PageUnauthorizedRoutingModule { }
