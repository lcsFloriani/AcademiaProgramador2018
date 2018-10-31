import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { OrderListComponent } from './order-list/order-list.component';
import { OrderResolveService } from './shared/order.service';
import { OrderViewComponent } from './order-view/order-view.component';
import { OrderDetailComponent } from './order-view/order-detail/order-detail.component';
import { OrderAddComponent } from './order-add/order-add.component';

const orderRoutes: Routes = [
    {
        path: 'adicionar',
        component: OrderAddComponent,
        data: {
            breadcrumbOptions: {
                breadcrumbLabel: 'Adicionar',
            },
        },
    },
    {
        path: '',
        component: OrderListComponent,
    },
    {
        path: ':orderId',
        resolve: {
            order: OrderResolveService,
        },
        data: {
            breadcrumbOptions: {
                breadcrumbId: 'order',
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
                          /*  {
                                path: 'editar',
                                component: OrderEditComponent,
                            },*/
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
