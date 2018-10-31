import { NgModule } from '@angular/core';

import { CpfCnpjPipe } from './cpf-cnpj.pipe';
import { FreightResponsibilityPipe } from './freightResponsibility.pipe';
import { PercentagePipe } from './percentage.pipe';
@NgModule({
    declarations:[
        CpfCnpjPipe,
        FreightResponsibilityPipe,
        PercentagePipe,
    ],
    exports: [
        CpfCnpjPipe,
        FreightResponsibilityPipe,
        PercentagePipe,
    ],
})
export class NddFormModule {}
