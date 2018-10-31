import { NgModule } from '@angular/core';

import { ReceiverGridService, ReceiverService, ReceiverResolveService, ReceiverSharedService } from './receiver.service';

@NgModule({
    providers: [ReceiverGridService, ReceiverService, ReceiverResolveService, ReceiverSharedService],
})
export class ReceiverSharedModule { }
