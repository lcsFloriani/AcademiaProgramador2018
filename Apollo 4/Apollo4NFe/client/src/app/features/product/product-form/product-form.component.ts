import { Component, Input } from '@angular/core';
import { FormGroup } from '@angular/forms';

@Component({
    selector: 'ndd-product-form',
    templateUrl: './product-form.component.html',
})
export class ProductFormComponent {
    @Input() public formModel: FormGroup;
}
