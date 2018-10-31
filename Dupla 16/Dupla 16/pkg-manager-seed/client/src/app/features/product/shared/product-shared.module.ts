import { NgModule } from '@angular/core';
import { ProductResolveService, ProductService, ProductGridService } from './product.service';

@NgModule({
    imports: [],

    declarations: [],

    providers:[
        ProductGridService,
        ProductService,
        ProductResolveService,
    ],
})

export class ProductSharedModule {

}
