import { AbstractControl, ValidationErrors } from '@angular/forms';

export class ProductValidator{
    public static checkValueEmpty(control: AbstractControl): ValidationErrors | null {
            return control.value > 0 ? null : {valueEmpty: true};
      }
}
