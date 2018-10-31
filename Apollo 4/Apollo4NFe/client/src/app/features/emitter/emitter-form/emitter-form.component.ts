import { Component, Input } from '@angular/core';
import { FormGroup } from '@angular/forms';

@Component({
    selector: 'ndd-emitter-form',
    templateUrl: './emitter-form.component.html',
})
export class EmitterFormComponent {
    @Input() public formModel: FormGroup;
}
