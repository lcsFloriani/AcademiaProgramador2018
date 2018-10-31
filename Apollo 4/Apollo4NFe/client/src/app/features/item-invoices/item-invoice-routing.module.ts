import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { ItemInvoiceComponent } from './item-invoice/item-invoice.component';

const itemInvoiceRoutes: Routes = [
    {
        path: '',
        component: ItemInvoiceComponent,
    },
];
@NgModule({
    imports: [RouterModule.forChild(itemInvoiceRoutes)],
    exports: [RouterModule],
    declarations: [],
    providers: [],
})
export class ItemInvoiceRoutingModule {

}
