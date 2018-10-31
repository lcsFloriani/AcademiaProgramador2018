import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { HttpErrorResponse } from '@angular/common/http';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

import { ReceiverRegisterCommand } from '../shared/receiver.model';
import { ReceiverService } from '../shared/receiver-shared/receiver.service';
import { CpfCnpjValidators } from '../../../shared/ndd-form/cpf-cnpj.validator';

@Component({
    templateUrl: './receiver-creator.component.html',
})
export class ReceiverCreatorComponent implements OnInit {

    public title: string;
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

    constructor(private service: ReceiverService, private fb: FormBuilder, private router: Router, private route: ActivatedRoute) { }

    public ngOnInit(): void {
        this.title = 'Criar Destinatário';
        this.isLoading = false;
        this.form.addControl('individual', this.groupIndividual);

        this.form.controls.type.valueChanges.subscribe((value: string) => {
            this.addFormGroup(value);
        });
    }

    public onSubmit(): void {
        this.isLoading = true;
        const command: ReceiverRegisterCommand = new ReceiverRegisterCommand(this.form.value);
        this.service.add(command).take(1)
            .subscribe((response: number) => {
                if (response > 0) {
                    this.router.navigate(['../'], { relativeTo: this.route });
                } else {
                    alert('Não foi possível cadastrar o destinatário!');
                }
                this.isLoading = false;
            }, (err: HttpErrorResponse) => {
                // Erro de chamada http.
                alert('Erro de conexão, tente novamente!');
                this.isLoading = false;
            });
    }

    public redirect(): void {
        this.router.navigate(['../'], { relativeTo: this.route });
    }

    private addFormGroup(key: string): void {
        switch (key) {

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
