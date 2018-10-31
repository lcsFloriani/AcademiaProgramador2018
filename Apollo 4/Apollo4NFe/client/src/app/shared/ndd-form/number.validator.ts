import { AbstractControl, ValidationErrors } from '@angular/forms';

export class NumberValidator {

    public static isNumber(control: AbstractControl): ValidationErrors | null {
        if (!(control)) return null;
        const controlText: string = control.value;

        return !isNaN(Number(controlText.toString())) ? null : { invalidNumber: true };
    }
}
