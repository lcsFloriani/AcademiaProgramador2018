import { NgModule } from '@angular/core';
import { PageForbiddenComponent } from './page-forbidden.component';
import { RouterModule, Routes } from '@angular/router';

const pageForbiddenRoutes: Routes = [
    {
        path: '',
        component: PageForbiddenComponent,
    },
];
@NgModule({
    imports: [RouterModule.forChild(pageForbiddenRoutes)],
    exports: [RouterModule],
})
export class PageForbiddenRoutingModule { }
