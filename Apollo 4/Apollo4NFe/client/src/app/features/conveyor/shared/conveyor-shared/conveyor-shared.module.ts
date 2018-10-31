import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { ConveyorGridService, ConveyorService, ConveyorResolveService, ConveyorSharedService } from './conveyor.service';

@NgModule({
    declarations: [],
    imports: [ CommonModule ],
    exports: [],
    providers: [ ConveyorGridService, ConveyorService, ConveyorResolveService, ConveyorSharedService ],
})
export class ConveyorSharedModule {}
