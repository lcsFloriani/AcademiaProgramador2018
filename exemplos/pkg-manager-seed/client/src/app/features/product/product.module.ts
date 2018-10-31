import { ReactiveFormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';
import { GridModule } from '@progress/kendo-angular-grid';
import { HttpClientModule } from '@angular/common/http';
import { CommonModule } from '@angular/common';

import { NDDBreadcrumbModule } from './../../shared/ndd-ng-breadcrumb/component/ndd-ng-breadcrumb.module';
import { ProductViewComponent } from './product-view/product-view.component';
import { ProductDetailComponent } from './product-view/product-detail/product-detail.component';
import { ProductListComponent } from './product-list/product-list.component';
import { ProductRoutingModule } from './product-routing.module';
import { ProductGridService, ProductResolveService, ProductSharedService, ProductService } from './shared/product.service';
import { NDDTabsbarModule } from '../../shared/ndd-ng-tabsbar/component';
import { NDDTitlebarModule } from '../../shared/ndd-ng-titlebar/component';
import { ProductCreateComponent } from './product-create/product-create.component';
import { ProductEditComponent } from './product-view/product-edit/product-edit.component';
@NgModule({
    imports: [
        CommonModule,
        ReactiveFormsModule,
        ProductRoutingModule,
        GridModule,
        HttpClientModule,
        NDDTabsbarModule,
        NDDBreadcrumbModule,
        NDDTitlebarModule,
    ],
    exports: [],
    declarations: [
        ProductListComponent,
        ProductDetailComponent,
        ProductViewComponent,
        ProductCreateComponent,
        ProductEditComponent,
    ],
    providers: [
        ProductGridService,
        ProductResolveService,
        ProductSharedService,
        ProductService,
    ],
})

export class ProductModule {

}
