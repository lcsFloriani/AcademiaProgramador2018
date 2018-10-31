import { Injectable } from '@angular/core';
import { Router } from '@angular/router';

@Injectable()
export class AuthenticationStatusService {
    private status: boolean = false;

    constructor(private router: Router) { }

    public get loggedIn(): boolean {
        return this.status;
    }

    public set loggedIn(status: boolean) {
        this.status = status;
    }

    public navigateToLogin(params?: any): void {
        const loginUrl: string = '/login';

        if (params) {
            this.router.navigate([loginUrl], params);
        } else {
            this.router.navigate([loginUrl]);
        }
    }
}
