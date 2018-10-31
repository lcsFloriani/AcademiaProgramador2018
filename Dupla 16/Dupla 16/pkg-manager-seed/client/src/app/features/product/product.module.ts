import { ProductSharedModule } from './shared/product-shared.module';
import { ProductViewComponent } from './product-view/product-view.component';
import { ProductGridService, ProductService, ProductResolveService } from './shared/product.service';
import { ProductRoutingModule } from './product-routing.module';
import { NgModule } from '@angular/core';
import { ProductListComponent } from './product-list/product-list.component';
import { SharedModule } from '../../shared/shared.module';
import { GridModule } from '@progress/kendo-angular-grid';
import { ProductDetailComponent } from './product-view/product-detail/product-detail.component';
import { NDDTitlebarModule } from '../../shared/ndd-ng-titlebar/component';
import { NDDTabsbarModule } from '../../shared/ndd-ng-tabsbar/component';
import { ProductEditComponent } from './product-edit/product-edit.component';
import { ProductAddComponent } from './product-add/product-add.component';
import { UiSwitchModule } from 'angular2-ui-switch';

@NgModule({

    imports: [
        ProductRoutingModule,
        SharedModule,
        GridModule,
        NDDTabsbarModule,
        NDDTitlebarModule,
        UiSwitchModule,
        ProductSharedModule,
    ],
    exports: [],
    declarations: [
        ProductListComponent,
        ProductViewComponent,
        ProductDetailComponent,
        ProductEditComponent,
        ProductAddComponent,
    ],
    providers: [
    ],
})

export class ProductModule {

}
