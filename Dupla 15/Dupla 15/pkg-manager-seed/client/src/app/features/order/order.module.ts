import { OrderEditComponent } from './order-view/order-edit/order-edit.component';
import { OrderDetailComponent } from './order-view/order-detail/order-detail.component';
import { OrderViewComponent } from './order-view/order-view.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HttpClientJsonpModule } from '@angular/common/http';
import { DropDownsModule } from '@progress/kendo-angular-dropdowns';

import { GridModule } from '@progress/kendo-angular-grid';
import { OrderListComponent } from './order-list/order-list.component';
import { OrderService, OrderGridService, OrderResolveService } from './shared/order-service';
import { NDDTabsbarModule } from '../../shared/ndd-ng-tabsbar/component';
import { NDDTitlebarModule } from '../../shared/ndd-ng-titlebar/component';
import { NDDBreadcrumbModule } from '../../shared/ndd-ng-breadcrumb';
import { OrderRoutingModule } from './order-routing.module';
import { OrderCreateComponent } from './order-create/order-create.component';
import { ProductSharedService } from '../product/shared/product.service';

@NgModule({
    imports: [
        CommonModule,
        ReactiveFormsModule,
        GridModule,
        HttpClientModule,
        NDDTabsbarModule,
        NDDBreadcrumbModule,
        NDDTitlebarModule,
        OrderRoutingModule,
        DropDownsModule,
        HttpClientJsonpModule,
    ],
    exports: [],
    declarations: [
        OrderListComponent,
        OrderViewComponent,
        OrderDetailComponent,
        OrderCreateComponent,
        OrderEditComponent,
    ],
    providers: [
        OrderService,
        OrderGridService,
        OrderResolveService,
        ProductSharedService,
    ],
})
export class OrderModule{
    //
}
