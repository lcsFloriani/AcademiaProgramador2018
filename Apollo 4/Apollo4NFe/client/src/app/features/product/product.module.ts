import { ProductFormComponent } from './product-form/product-form.component';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { GridModule } from '@progress/kendo-angular-grid';

import { SharedModule } from '../../shared/shared.module';
import { ProductRoutingModule } from './product-routing.module';
import { NDDBreadcrumbModule } from '../../shared/ndd-ng-breadcrumb';
import { NddFormModule } from '../../shared/ndd-form/ndd-form.module';
import { NDDTabsbarModule } from '../../shared/ndd-ng-tabsbar/component';
import { NDDTitlebarModule } from '../../shared/ndd-ng-titlebar/component';
import { ProductListComponent } from './product-list/product-list.component';
import { ProductViewComponent } from './product-view/product-view.component';
import { ProductCreateComponent } from './product-create/product-create.component';
import { ProductEditComponent } from './product-view/product-edit/product-edit.component';
import { ProductService, QueryService, ProductResolveService } from './shared/product.service';
import { ProductDetailComponent } from './product-view/product-details/product-detail.component';

@NgModule({
    imports: [
        SharedModule,
        HttpClientModule,
        ProductRoutingModule,
        GridModule,
        NDDBreadcrumbModule,
        NDDTabsbarModule,
        NDDTitlebarModule,
        NddFormModule,
    ],
    declarations: [
        ProductListComponent,
        ProductCreateComponent,
        ProductViewComponent,
        ProductDetailComponent,
        ProductEditComponent,
        ProductFormComponent,
    ],
    providers: [
        ProductService,
        QueryService,
        ProductResolveService,
    ],
})
export class ProductModule {
    //
}
