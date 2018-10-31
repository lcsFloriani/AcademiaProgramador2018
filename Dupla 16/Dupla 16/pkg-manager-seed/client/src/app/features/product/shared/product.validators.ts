import { AbstractControl, ValidationErrors } from '@angular/forms';

export class ProductValidators {
 public static checkDatas(control: AbstractControl): ValidationErrors | null {
   const manufacture: AbstractControl = control.get('manufacture');
   const expiration: AbstractControl = control.get('expiration');
   if (!(manufacture && expiration)) return null;

   const manufactureDate: Date = new Date(manufacture.value);
   const expirationDate: Date = new Date (expiration.value);

   return manufactureDate.getTime() <= expirationDate.getTime() ? null : { invalidDate: true };
 }
}
