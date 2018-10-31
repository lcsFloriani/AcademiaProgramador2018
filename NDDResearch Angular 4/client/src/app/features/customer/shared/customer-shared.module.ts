import { NgModule } from '@angular/core';

import { CustomerService, CustomerGridService} from './customer.service';
import { CustomerResolveService } from './customer-resolve.service';

@NgModule({
    providers: [
        CustomerService,
        CustomerGridService,
        CustomerResolveService,
    ],
    exports: [],
})
export class CustomerSharedModule {}
