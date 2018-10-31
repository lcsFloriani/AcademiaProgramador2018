import { Component, OnInit, OnDestroy } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { Subject } from 'rxjs/Subject';

import { LoginService } from '../shared/login.service';
import { AuthenticationService } from './../../../core/authentication/authentication.service';
@Component({
    selector: 'ndd-login-form',
    templateUrl: 'login-form.component.html',
})
export class LoginFormComponent implements OnInit, OnDestroy {

    public formLogin: FormGroup;
    public isLoading: boolean = false;
    public showErrorMessage: boolean = false;
    public showSuccessMessage: boolean = false;
    public successMessage: string;

    private ngUnsubscribe: Subject<void> = new Subject<void>();
    private redirectUrl: string;
    constructor(
        private router: Router,
        private activatedRoute: ActivatedRoute,
        private fb: FormBuilder,
        private authenticationService: AuthenticationService,
        private loginService: LoginService,
    ) { }

    public ngOnInit(): void {
        this.authenticationService.logout();
        this.activatedRoute.queryParams.filter((params: any) => params.returnUrl).take(1).subscribe( (params: any) => {
            this.redirectUrl = params.returnUrl;
        });

        this.formLogin = this.fb.group({company: this.fb.control('nddigital', [Validators.required]),
            username: this.fb.control('admin@admin.com', [Validators.required, Validators.email ]),
            password: this.fb.control('321', [Validators.required]),
        });
        this.showSuccessMessage = this.loginService.showSuccessMessage;
        this.successMessage = this.loginService.successMessage;
    }

    public ngOnDestroy(): void {
        this.ngUnsubscribe.next();
        this.ngUnsubscribe.complete();
    }

    public onSubmit(): void {
        this.login();
    }

    public login(): void {
        if (this.validateEmail()) {
            this.isLoading = true;

            this.authenticationService.login(this.formLogin.value, false).takeUntil(this.ngUnsubscribe).subscribe(() => {
                    this.redirect(this.redirectUrl);
                    this.loginService.showSuccessMessage = false;
                }, (reason: Response) => {
                    this.isLoading = false;
                    this.showErrorMessage = true;
                    this.showSuccessMessage = false;
                });
        } else {
            this.showErrorMessage = true;
            this.showSuccessMessage = false;
        }
    }

    public navigateToRequestPassword(): void {
        this.router.navigate(['/login/request-password']);
    }

    private validateEmail(): boolean {
        if (this.formLogin.value.username.includes('@')) {
            // tslint:disable-next-line:max-line-length
            const regex: RegExp = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;

            return regex.test(this.formLogin.value.username);
        } else {
            return true;
        }
    }

    private redirect(urlRoute: string): void {
        if (urlRoute) {
            this.router.navigate([urlRoute]);
        } else {
            this.router.navigate(['/']);
        }
    }
}
