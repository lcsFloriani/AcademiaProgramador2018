import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { ProdutoListComponent } from './produto-list/produto-list.component';
import { ProdutoResolveService } from './shared/produto.service';

const produtoRoutes: Routes = [
    {
        path: '',
        component: ProdutoListComponent,
    },
    {
       /* path: 'create',
        component: ProdutoCreateComponent,
        data: {
            breadcrumbOptions: {
                breadcrumbLabel: 'Cadastrar Produto',
            },
        },*/
    },
    {
        path: ':produtoId',
        resolve: {
            produto: ProdutoResolveService,
        },
        data: {
            breadcrumbOptions: {
                breadcrumbLabel: 'Produto',
            },
        },
        /*children: [
            {
                path: '',
                component: ProdutoViewComponent,
                children: [
                    {
                        path: '',
                        redirectTo: 'info',
                        pathMatch: 'full',
                    },
                    {
                       /* path: 'info',
                        children: [
                            {
                                path: '',
                                component: ProdutoDetailComponent,
                            },
                            {
                                path: 'edit',
                                component: ProdutoEditComponent,
                                data: {
                                    breadcrumbOptions: {
                                        breadcrumbLabel: 'Editar Produto',
                                    },
                                },
                            },
                        ],
                    },
                ],
            },
        ],*/
    },
];

@NgModule({
    imports: [RouterModule.forChild(produtoRoutes)],
    exports: [RouterModule],
    declarations: [],
    providers: [],
})

export class ProdutoRoutingModule {

}
