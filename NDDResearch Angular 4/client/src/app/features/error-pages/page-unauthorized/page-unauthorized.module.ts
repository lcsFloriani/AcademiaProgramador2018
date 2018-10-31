import { NgModule } from '@angular/core';
import { PageUnauthorizedComponent } from './page-unauthorized.component';
import { PageUnauthorizedRoutingModule } from './page-unauthorized-routing.module';
import { SharedModule } from '../../../shared/shared.module';

@NgModule({
    imports: [
        SharedModule,
        [PageUnauthorizedRoutingModule],
    ],
    exports: [],
    declarations: [PageUnauthorizedComponent],
    providers: [],
})
export class PageUnauthorizedModule {}
