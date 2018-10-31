import { Routes, RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';

import { OrderListComponent } from './order-list/order-list.component';
import { OrderResolveService } from './shared/order-service';
import { OrderViewComponent } from './order-view/order-view.component';
import { OrderDetailComponent } from './order-view/order-detail/order-detail.component';
import { OrderCreateComponent } from './order-create/order-create.component';
import { OrderEditComponent } from './order-view/order-edit/order-edit.component';

const orderRoutes: Routes = [
    {
        path: '',
        component: OrderListComponent,
    },
    {
        path: 'create',
        component: OrderCreateComponent,
        data: {
            breadcrumbOptions: {
                breadcrumbLabel: 'Cadastrar Pedido',
            },
        },
    },
    {
        path: ':orderId',
        resolve: {
            order: OrderResolveService,
        },
        data: {
            breadcrumbOptions: {
                breadcrumbLabel: 'Pedido',
            },
        },
        children: [
            {
                path: '',
                component: OrderViewComponent,
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
                                component: OrderDetailComponent,
                            },
                            {
                                path: 'edit',
                                component: OrderEditComponent,
                                data: {
                                    breadcrumbOptions: {
                                        breadcrumbLabel: 'Editar Pedido',
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
    imports: [RouterModule.forChild(orderRoutes)],
    exports: [RouterModule],
    declarations: [],
    providers: [],
})

export class OrderRoutingModule {
}
