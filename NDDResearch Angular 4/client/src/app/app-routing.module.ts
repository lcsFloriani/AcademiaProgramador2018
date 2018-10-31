import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { AuthGuardService } from './core/authentication/auth-guard.service';
import { LayoutComponent } from './core/layout/layout.component';

const appRoutes: Routes = [
    {
        path: 'login',
        loadChildren: './features/login/login.module#LoginModule',
    },
    {
        path: 'page-not-found',
        loadChildren: './features/error-pages/page-not-found/page-not-found.module#PageNotFoundModule',
    },
    {
        path: 'page-unauthorized',
        loadChildren: './features/error-pages/page-unauthorized/page-unauthorized.module#PageUnauthorizedModule',
    },
    {
        path: 'page-forbidden',
        loadChildren: './features/error-pages/page-forbidden/page-forbidden.module#PageForbiddenModule',
    },
    {
        path: '',
        component: LayoutComponent,
        canActivate: [AuthGuardService],
        children: [
            // Rota que redireciona para a home quando não tem rota na url
            {
                path: '',
                redirectTo: 'home',
                pathMatch: 'full',
            },
            // Rota inicial do app
            {
                path: 'home',
                loadChildren: './features/home/home.module#HomeModule',
                canLoad: [AuthGuardService],
            },
            {
                path: 'customers',
                loadChildren: './features/customer/customer.module#CustomerModule',
                canLoad: [AuthGuardService],
                data: {
                    breadcrumbOptions: {
                        breadcrumbLabel: 'NDDCustomers',
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
