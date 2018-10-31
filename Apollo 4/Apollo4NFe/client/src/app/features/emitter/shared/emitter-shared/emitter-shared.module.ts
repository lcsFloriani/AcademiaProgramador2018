import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { EmitterGridService, EmitterService, EmitterResolveService, EmitterSharedService } from './emitter.service';

@NgModule({
    declarations: [],
    imports: [ CommonModule ],
    exports: [],
    providers: [ EmitterGridService, EmitterService, EmitterResolveService, EmitterSharedService ],
})
export class EmitterSharedModule {}
