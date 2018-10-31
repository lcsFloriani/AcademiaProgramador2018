import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Component, Input } from '@angular/core';

import { EnumValues } from 'enum-values';
import { FreightResponsibility } from '../shared/conveyor.model';
import { CpfCnpjValidators } from '../../../shared/ndd-form/cpf-cnpj.validator';

@Component({
    selector: 'ndd-conveyor-form',
    templateUrl: './conveyor-form.component.html',
})

export class ConveyorFormComponent{

    @Input() public formModel: FormGroup;
    public responsibilityList: any[];

    public formEnterprise: FormGroup = this.fb.group({
        companyName: ['', Validators.required],
        cnpj: ['', Validators.required, CpfCnpjValidators.checkCnpj],
    });
    public formIndividual: FormGroup = this.fb.group({
        name: ['', Validators.required],
        cpf: ['', Validators.required, CpfCnpjValidators.checkCpf],
    });
    constructor(private fb: FormBuilder) {
        this.responsibilityList = EnumValues.getNamesAndValues(FreightResponsibility);
    }
}
