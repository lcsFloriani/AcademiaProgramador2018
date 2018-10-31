import { Component, Input } from '@angular/core';
import { FormGroup } from '@angular/forms';

import { State } from '../address.model';
import {EnumValues} from 'enum-values';
@Component({
    selector: 'ndd-address-form',
    templateUrl: './address-form.component.html',
})
export class AddressFormComponent {

    @Input() public formModel: FormGroup;
    public listStates: any[];
    constructor() {
        this.listStates = EnumValues.getNamesAndValues(State);
    }
}
