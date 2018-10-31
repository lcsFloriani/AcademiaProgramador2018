import { Routes, RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';

import { InvoiceResolveService } from './shared/invoice.service';
import { InvoiceListComponent } from './invoice-list/invoice-list.component';
import { InvoiceViewComponent } from './invoice-view/invoice-view.component';
import { InvoiceEditComponent } from './invoice-view/invoice-edit/invoice-edit.component';
import { InvoiceCreatorComponent } from './invoice-creator/invoice-creator.component';
import { InvoiceDetailComponent } from './invoice-view/invoice-details/invoice-detail.component';
import { ItemInvoiceComponent } from '../item-invoices/item-invoice/item-invoice.component';

const invoiceIssuedRoutes: Routes = [
    {
        path: '',
        component: InvoiceListComponent,
    },
    {
        path: 'create',
        component: InvoiceCreatorComponent,
        data: {
            breadcrumbOptions: {
                breadcrumbLabel: 'Criar Nota Fiscal',
            },
        },
    },
    {
        path: ':invoiceId',
        resolve: {
            InvoiceResolveService,
        },
        data: {
            breadcrumbOptions: {
                breadcrumbLabel: 'Nota Fiscal',
            },
        },
        children: [
            {
                path: '',
                component: InvoiceViewComponent,
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
                                component: InvoiceDetailComponent,
                            },
                            {
                                path: 'edit',
                                component: InvoiceEditComponent,
                                data: {
                                    breadcrumbOptions: {
                                        breadcrumbLabel: 'Editar Nota Fiscal',
                                    },
                                },
                            },
                        ],
                    },
                    {
                        path: 'item',
                        children: [
                            {
                                path: '',
                                component: ItemInvoiceComponent,
                            },
                        ],
                    },
                ],
            },
        ],
    },
];

@NgModule({
    imports: [RouterModule.forChild(invoiceIssuedRoutes)],
    exports: [RouterModule],
    declarations: [],
    providers: [],
})
export class InvoiceRoutingModule {

}
