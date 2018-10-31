import { ProductSharedModule } from './../product/shared/product-shared.module';
import { OrderViewComponent } from './order-view/order-view.component';
import { NgModule } from '@angular/core';
import { SharedModule } from '../../shared/shared.module';
import { GridModule } from '@progress/kendo-angular-grid';
import { NDDTabsbarModule } from '../../shared/ndd-ng-tabsbar/component';
import { NDDTitlebarModule } from '../../shared/ndd-ng-titlebar/component';
import { OrderRoutingModule } from './order-routing.module';
import { OrderGridService, OrderService, OrderResolveService } from './shared/order.service';
import { OrderListComponent } from './order-list/order-list.component';
import { OrderDetailComponent } from './order-view/order-detail/order-detail.component';
import { OrderAddComponent } from './order-add/order-add.component';
import { DropDownsModule } from '@progress/kendo-angular-dropdowns';

@NgModule({
    imports:[
        SharedModule,
        GridModule,
        NDDTabsbarModule,
        NDDTitlebarModule,
        OrderRoutingModule,
        ProductSharedModule,
        DropDownsModule,
    ],
    declarations: [
        OrderListComponent,
        OrderViewComponent,
        OrderDetailComponent,
        OrderAddComponent,
    ],
    exports: [],
    providers: [
        OrderGridService,
        OrderService,
        OrderResolveService,
    ],
})

export class OrderModule{

}
