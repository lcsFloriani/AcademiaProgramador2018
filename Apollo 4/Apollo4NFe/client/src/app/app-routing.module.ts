import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { LayoutComponent } from './core/layout/layout.component';

const appRoutes: Routes = [
    {
        path: 'page-not-found',
        loadChildren: './features/error-pages/page-not-found/page-not-found.module#PageNotFoundModule',
    },
    {
        path: '',
        component: LayoutComponent,
        children: [
            {
                path: '',
                redirectTo: 'emitters',
                pathMatch: 'full',
            },
            {
                path: 'emitters',
                loadChildren: './features/emitter/emitter.module#EmitterModule',
                data: {
                    breadcrumbOptions: {
                        breadcrumbLabel: 'Emitentes',
                    },
                },
            },
            {
                path: 'conveyors',
                loadChildren: './features/conveyor/conveyor.module#ConveyorModule',
                data: {
                    breadcrumbOptions: {
                        breadcrumbLabel: 'Transportadores',
                    },
                },
            },
            {
                path: 'products',
                loadChildren: './features/product/product.module#ProductModule',
                data: {
                    breadcrumbOptions: {
                        breadcrumbLabel: 'Produtos',
                    },
                },
            },
            {
                path: 'receivers',
                loadChildren: './features/receiver/receiver.module#ReceiverModule',
                data: {
                    breadcrumbOptions: {
                        breadcrumbLabel: 'Destinatários',
                    },
                },
            },
            {
                path: 'invoices',
                loadChildren: './features/invoice/invoice.module#InvoiceModule',
                data: {
                    breadcrumbOptions: {
                        breadcrumbLabel: 'Notas Fiscais',
                    },
                },
            },
        ],
    },
    { path: '**', redirectTo: 'page-not-found', pathMatch: 'full' },
];

@NgModule({
    imports: [RouterModule.forRoot(appRoutes, {
        paramsInheritanceStrategy: 'always',
    })],
    exports: [RouterModule],
})
export class AppRoutingModule { }
