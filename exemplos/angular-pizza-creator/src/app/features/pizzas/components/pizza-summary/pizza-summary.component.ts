import { Component, Input } from '@angular/core';
import { FormGroup } from '@angular/forms';

@Component({
    selector: 'pizza-summary',
    templateUrl: './pizza-summary.component.html',
})

export class PizzaSummaryComponent{

  @Input() public formModel: FormGroup;

  @Input() public prices: number;

  @Input() public total: string = '';
}
