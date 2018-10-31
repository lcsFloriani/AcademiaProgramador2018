import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';

import { EmitterRegisterCommand } from './../shared/emitter.model';
import { NumberValidator } from './../../../shared/ndd-form/number.validator';
import { EmitterService } from './../shared/emitter-shared/emitter.service';
import { CpfCnpjValidators } from '../../../shared/ndd-form/cpf-cnpj.validator';

@Component({
    templateUrl: './emitter-creator.component.html',
})
export class EmitterCreatorComponent implements OnInit {

    public title: string;
    public isLoading: boolean;
    public form: FormGroup = this.fb.group({
        fantasyName: ['', Validators.required],
        companyName: ['', Validators.required],
        cnpj: ['', [Validators.required, CpfCnpjValidators.checkCnpj]],
        stateRegistration: ['', [Validators.required, NumberValidator.isNumber]],
        municipalRegistration: ['', [Validators.required, NumberValidator.isNumber]],
        address: this.fb.group({
            street: ['', Validators.required],
            number: ['', Validators.required],
            neighbourhood: ['', Validators.required],
            city: ['', Validators.required],
            state: ['', Validators.required],
        }),
    });

    constructor(private fb: FormBuilder,
                private router: Router,
                private emitterService: EmitterService,
                private route: ActivatedRoute)
                { }

    public ngOnInit(): void {
        this.title = 'Criar Emitente';
        this.isLoading = false;
    }
    public redirect(): void {
        this.router.navigate(['../'], { relativeTo: this.route });
    }
    public onCreate(): void {
        const emitterCmd: EmitterRegisterCommand = new EmitterRegisterCommand(this.form.value);
        this.emitterService.post(emitterCmd)
            .take(1)
            .subscribe(() => {
                this.isLoading = true;
                this.redirect();
            });
    }
}
