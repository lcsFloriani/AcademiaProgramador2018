import { ProductAddComponent } from './product-add/product-add.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProductListComponent } from './product-list/product-list.component';
import { ProductViewComponent } from './product-view/product-view.component';
import { ProductDetailComponent } from './product-view/product-detail/product-detail.component';
import { ProductResolveService } from './shared/product.service';
import { ProductEditComponent } from './product-edit/product-edit.component';
import { Product } from './shared/product.model';

const productRoutes: Routes = [
    {
        path: 'adicionar',
        component: ProductAddComponent,
        data: {
            breadcrumbOptions: {
                breadcrumbLabel: 'Adicionar',
            },
        },
    },
    {
        path: '',
        component: ProductListComponent,
    },
    {
        path: ':productId',
        resolve: {
           product: ProductResolveService,
        },
        data: {
            breadcrumbOptions: {
                breadcrumbId: 'product',
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
                                path: 'editar',
                                component: ProductEditComponent,
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
