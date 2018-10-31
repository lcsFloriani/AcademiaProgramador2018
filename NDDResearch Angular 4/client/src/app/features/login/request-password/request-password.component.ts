import { Component, OnInit, OnDestroy } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Subject } from 'rxjs/Subject';

import { LoginService } from '../shared/login.service';
import { AuthenticationService } from './../../../core/authentication/authentication.service';

@Component({
    templateUrl: 'request-password.component.html',
})
export class RequestPasswordComponent implements OnInit, OnDestroy {

    public formRequestPass: FormGroup;
    public formId: string = 'request-password-form';
    public isLoading: boolean = false;
    public showErrorMessage: boolean = false;

    private ngUnsubscribe: Subject<void> = new Subject<void>();

    constructor(
        private router: Router,
        private authenticationService: AuthenticationService,
        private fb: FormBuilder,
        private loginService: LoginService,
    ) { }

    public ngOnInit(): void {
        this.formRequestPass = this.fb.group({
            dealerName: this.fb.control('', [Validators.required]),
            userEmail: this.fb.control('', [Validators.required, Validators.email]),
        });
    }

    public ngOnDestroy(): void {
        this.ngUnsubscribe.next();
        this.ngUnsubscribe.complete();
    }

    public onSubmit(): void {
        this.isLoading = true;
        this.authenticationService.requestPassword(this.formRequestPass.value)
            .takeUntil(this.ngUnsubscribe)
            .subscribe((result: boolean) => {
                if (result) {
                    this.isLoading = false;
                    this.loginService.showSuccessMessage = true;
                    this.loginService.successMessage = 'NDDRequestPasswordSuccess';
                    this.navigateToLogin();
                    this.formRequestPass.markAsPristine();
                } else {
                    this.requestFailed();
                }
            },
            (reason: Response) => {
                this.requestFailed();
            });
    }

    public navigateToLogin(): void {
        this.router.navigate(['/login']);
    }

    private requestFailed(): void {
        this.isLoading = false;
        this.showErrorMessage = true;
    }
}
