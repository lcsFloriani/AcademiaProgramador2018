import { Component, Input } from '@angular/core';

import { Address } from '../address.model';

@Component({
    selector: 'ndd-address-detail',
    templateUrl: './address-detail.component.html',
})
export class AddressDetailComponent {
    @Input() public address: Address;
}
