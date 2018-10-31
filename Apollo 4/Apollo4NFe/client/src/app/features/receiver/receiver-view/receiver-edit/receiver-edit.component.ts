import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Subject } from 'rxjs/Subject';

import { CpfCnpjValidators } from '../../../../shared/ndd-form/cpf-cnpj.validator';
import { Receiver, ReceiverUpdateCommand, ReceiverFormModel } from '../../shared/receiver.model';
import { ReceiverResolveService, ReceiverService } from '../../shared/receiver-shared/receiver.service';

@Component({
    templateUrl: './receiver-edit.component.html',
})
export class ReceiverEditComponent implements OnInit {
    public receiver: Receiver;
    public isLoading: boolean;
    public form: FormGroup = this.fb.group({
        type: ['1', Validators.required],
        address: this.fb.group({
            street: ['', Validators.required],
            number: ['', Validators.required],
            neighbourhood: ['', Validators.required],
            city: ['', Validators.required],
            state: ['', Validators.required],
        }),
    });

    public groupIndividual: FormGroup = this.fb.group({
        name: ['', Validators.required],
        cpf: ['', [Validators.required, CpfCnpjValidators.checkCpf]],
    });

    public groupEnterprice: FormGroup = this.fb.group({
        companyName: ['', Validators.required],
        cnpj: ['', [Validators.required, CpfCnpjValidators.checkCnpj]],
        stateRegistration: ['', Validators.required],
    });

    private ngUnsubscribe: Subject<void> = new Subject<void>();
    constructor(private fb: FormBuilder,
        private router: Router,
        private resolver: ReceiverResolveService,
        private receiverService: ReceiverService,
        private route: ActivatedRoute) { }

    public ngOnInit(): void {
        this.isLoading = false;
        this.resolver.onChanges
            .takeUntil(this.ngUnsubscribe)
            .subscribe((receiver: Receiver) => {
                this.isLoading = false;
                this.receiver = Object.assign(new Receiver(), receiver);
                this.addFormGroup(this.receiver.type.toString());
                this.form.setValue(new ReceiverFormModel(this.receiver));
            });

        this.form.controls.type.valueChanges.subscribe((value: string) => {
            this.addFormGroup(value);
        });
    }
    public redirect(): void {
        this.router.navigate(['../'], { relativeTo: this.route });
    }
    public onSubmit(): void {
        const receiverCmd: ReceiverUpdateCommand = new ReceiverUpdateCommand(this.form.value, this.receiver.id);
        this.receiverService.put(receiverCmd)
            .take(1)
            .subscribe(() => {
                this.isLoading = true;
                this.redirect();
                this.resolver.resolveFromRouteAndNotify();
            });
    }

    private addFormGroup(key: string): void {
        switch (key.toString()) {

            case '1':
                this.form.removeControl('enterprise');
                this.form.addControl('individual', this.groupIndividual);
                break;
            case '2':
                this.form.removeControl('individual');
                this.form.addControl('enterprise', this.groupEnterprice);
                break;

            default:
                break;
        }
    }

}
