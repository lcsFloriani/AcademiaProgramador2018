import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { SiteCreateComponent } from './site-create/site-create.component';
import { SiteViewComponent } from './site-view/site-view.component';
import { SiteInfoDetailComponent } from './site-view/detail/site-info-detail.component';
import { SiteInfoEditComponent } from './site-view/edit/site-info-edit.component';
import { SiteResolveService } from './shared/site-resolve.service';

const siteRoutes: Routes = [
    {
        path: 'create',
        component: SiteCreateComponent,
        data: {
            breadcrumbOptions: {
                breadcrumbLabel: 'NDDCreateSite',
            },
        },
    },
    {
        path: ':siteId',
        resolve: {
            site: SiteResolveService,
        },
        data: {
            breadcrumbOptions: {
              breadcrumbId: 'site',
            },
        },
        children: [
            {
                path: '',
                component: SiteViewComponent,
                children: [
                    {
                        path: '',
                        redirectTo: 'info',
                        pathMatch: 'full',
                    },
                    {
                        path: 'info',
                        children: [
                            {
                                path: '',
                                component: SiteInfoDetailComponent,
                            },
                            {
                                path: 'edit',
                                component: SiteInfoEditComponent,
                                data: {
                                    breadcrumbOptions: {
                                        breadcrumbLabel: 'NDDEditSite',
                                    },
                                },
                            },
                        ],
                    },
                ],
            },
        ],
    },
];

@NgModule({
    imports: [RouterModule.forChild(siteRoutes)],
    exports: [RouterModule],
    declarations: [],
    providers: [],
})
export class SiteRoutingModule { }
