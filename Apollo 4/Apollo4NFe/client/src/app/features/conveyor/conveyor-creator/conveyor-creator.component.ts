import { Component, OnInit } from '@angular/core';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';

import { ConveyorRegisterCommand } from '../shared/conveyor.model';
import { CpfCnpjValidators } from '../../../shared/ndd-form/cpf-cnpj.validator';
import { ConveyorService } from './../shared/conveyor-shared/conveyor.service';
@Component({
    templateUrl: './conveyor-creator.component.html',
})
export class ConveyorCreatorComponent implements OnInit {
    public title: string;
    public isLoading: boolean;
    public form: FormGroup = this.fb.group({
        personType: ['1', Validators.required],
        freightResponsibility: ['', Validators.required],
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
    });
    constructor(private fb: FormBuilder,
        private router: Router,
        private conveyorService: ConveyorService,
        private route: ActivatedRoute) { }

    public ngOnInit(): void {
        this.title = 'Criar Transportador';
        this.isLoading = false;

        this.form.addControl('individual', this.groupIndividual);
        this.form.controls.personType.valueChanges.subscribe((value: number) => {
            this.addFormGroup(value.toString());
        });
    }
    public redirect(): void {
        this.router.navigate(['../'], { relativeTo: this.route });
    }
    public onCreate(): void {
        const conveyorCmd: ConveyorRegisterCommand = new ConveyorRegisterCommand(this.form.value);
        this.conveyorService.post(conveyorCmd)
            .take(1)
            .subscribe(() => {
                this.isLoading = true;
                this.redirect();
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
