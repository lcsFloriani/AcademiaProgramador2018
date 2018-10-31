import { AbstractControl, ValidationErrors } from '@angular/forms';

export class ProductValidator {
    public static checkDate(control: AbstractControl): ValidationErrors | null {
        const manufacture: Date = new Date(control.get('manufacture').value);
        const expiration: Date = new Date(control.get('expiration').value);

        // tslint:disable-next-line:no-console
        console.log('manufa' + manufacture);
        // tslint:disable-next-line:no-console
        console.log('expir' + expiration);

        // tslint:disable-next-line:no-console
        console.log('expre: ' + (manufacture < expiration));

        return manufacture.getTime() < expiration.getTime() ? null : { manufactureIsValid: true };
    }
}
