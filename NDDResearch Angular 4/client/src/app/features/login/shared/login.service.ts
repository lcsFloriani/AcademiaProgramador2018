import { Injectable } from '@angular/core';

@Injectable()
export class LoginService {

    public showSuccessMessage: boolean = false;
    public successMessage: string;
}
