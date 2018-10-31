import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { CustomerListComponent } from './customer-list/customer-list.component';
import { CustomerCreateComponent } from './customer-create/customer-create.component';
import { CustomerViewComponent } from './customer-view/customer-view.component';
import { CustomerInfoDetailComponent } from './customer-view/detail/customer-info-detail.component';
import { CustomerResolveService } from './shared/customer-resolve.service';
import { CustomerInfoEditComponent } from './customer-view/edit/customer-info-edit.component';
import { NDDFormGuardService } from 'ndd-ng-form';

const homeRoutes: Routes = [
    {
        path: '',
        component: CustomerListComponent,
    },
    {
        path: 'create',
        component: CustomerCreateComponent,
        canDeactivate: [NDDFormGuardService],
        data: {
            breadcrumbOptions: {
                breadcrumbLabel: 'NDDCreateCustomer',
            },
        },
    },
    {
        path: ':customerId',
        resolve: {
            customer: CustomerResolveService,
        },
        data: {
            breadcrumbOptions: {
              breadcrumbId: 'customer',
            },
        },
        children: [
            {
                path: '',
                component: CustomerViewComponent,
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
                                component: CustomerInfoDetailComponent,
                            },
                            {
                                path: 'edit',
                                component: CustomerInfoEditComponent,
                                canDeactivate: [NDDFormGuardService],
                                data: {
                                    breadcrumbOptions: {
                                        breadcrumbLabel: 'NDDEditCustomer',
                                    },
                                },
                            },
                        ],
                    },
                    {
                        path: 'sites',
                        loadChildren: '../site/site-list/site-list.module#SiteListModule',
                        data: {
                            breadcrumbOptions: {
                                breadcrumbLabel: 'NDDSites',
                            },
                        },
                    },
                ],
            },
            {
                path: 'sites',
                pathMatch: 'prefix',
                loadChildren: '../site/site.module#SiteModule',
                data: {
                    breadcrumbOptions: {
                        breadcrumbLabel: 'NDDSites',
                    },
                },
            },
        ],
    },
];

@NgModule({
    imports: [RouterModule.forChild(homeRoutes)],
    exports: [RouterModule],
    declarations: [],
    providers: [],
})
export class CustomerRoutingModule { }
