import { NgModule } from '@angular/core';
import { PageForbiddenComponent } from './page-forbidden.component';
import { PageForbiddenRoutingModule } from './page-forbidden-routing.module';
import { SharedModule } from '../../../shared/shared.module';

@NgModule({
    imports: [
        SharedModule,
        PageForbiddenRoutingModule,
    ],
    exports: [],
    declarations: [PageForbiddenComponent],
    providers: [],
})
export class PageForbiddenModule {}
