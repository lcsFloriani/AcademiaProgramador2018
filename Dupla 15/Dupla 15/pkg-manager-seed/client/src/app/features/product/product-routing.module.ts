import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { ProductListComponent } from './product-list/product-list.component';
import { ProductDetailComponent } from './product-view/product-detail/product-detail.component';
import { ProductViewComponent } from './product-view/product-view.component';
import { ProductResolveService } from './shared/product.service';
import { ProductCreateComponent } from './product-create/product-create.component';
import { ProductEditComponent } from './product-view/product-edit/product-edit.component';

const productRoutes: Routes = [
    {
        path: '',
        component: ProductListComponent,
    },
    {
        path: 'create',
        component: ProductCreateComponent,
        data: {
            breadcrumbOptions: {
                breadcrumbLabel: 'Cadastrar Produto',
            },
        },
    },
    {
        path: ':productId',
        resolve: {
            product: ProductResolveService,
        },
        data: {
            breadcrumbOptions: {
                breadcrumbLabel: 'Produto',
            },
        },
        children: [
            {
                path: '',
                component: ProductViewComponent,
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
                                component: ProductDetailComponent,
                            },
                            {
                                path: 'edit',
                                component: ProductEditComponent,
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
        ],
    },
];

@NgModule({
    imports: [RouterModule.forChild(productRoutes)],
    exports: [RouterModule],
    declarations: [],
    providers: [],
})

export class ProductRoutingModule {

}
