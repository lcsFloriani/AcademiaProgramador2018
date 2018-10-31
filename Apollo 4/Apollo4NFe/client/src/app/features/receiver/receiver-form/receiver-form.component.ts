import { Component, Input } from '@angular/core';
import { FormGroup } from '@angular/forms';

@Component({
    selector: 'ndd-receiver-form',
    templateUrl: './receiver-form.component.html',
})
export class ReceiverFormComponent {
    @Input() public formModel: FormGroup;
}
