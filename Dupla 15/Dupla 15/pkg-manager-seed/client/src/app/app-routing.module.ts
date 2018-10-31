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
                redirectTo: 'produtos',
                pathMatch: 'full',
            },
            {
                path: 'produtos',
                loadChildren: './features/product/product.module#ProductModule',
                data: {
                    breadCrumbOptions: {
                        breadCrumbLabel: 'Produtos',
                    },
                },
            },
            {
                path: 'pedidos',
                loadChildren: './features/order/order.module#OrderModule',
                data: {
                    breadCrumbOptions: {
                        breadCrumbLabel: 'Pedidos',
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
