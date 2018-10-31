import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Validators, FormGroup, FormBuilder } from '@angular/forms';
import { Subject } from 'rxjs/Subject';

import { Conveyor, ConveyorUpdateCommand, ConveyorFormModel } from '../../shared/conveyor.model';
import { ConveyorResolveService, ConveyorService } from '../../shared/conveyor-shared/conveyor.service';
import { CpfCnpjValidators } from '../../../../shared/ndd-form/cpf-cnpj.validator';

@Component({
    templateUrl: './conveyor-edit.component.html',
})

export class ConveyorEditComponent implements OnInit {
    public conveyor: Conveyor;
    public isLoading: boolean;
    public form: FormGroup = this.fb.group({
        personType: ['', Validators.required],
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

    private ngUnsubscribe: Subject<void> = new Subject<void>();
    constructor(private fb: FormBuilder,
        private router: Router,
        private resolver: ConveyorResolveService,
        private conveyorService: ConveyorService,
        private route: ActivatedRoute)
        { }

    public ngOnInit(): void {
        this.isLoading = false;
        this.resolver.onChanges
        .takeUntil(this.ngUnsubscribe)
        .subscribe((conveyor: Conveyor) => {
            this.isLoading = false;
            this.conveyor = Object.assign(new Conveyor(), conveyor);
            this.addFormGroup(this.conveyor.personType.toString());
            this.form.setValue(new ConveyorFormModel(this.conveyor));
        });
        this.form.controls.personType.valueChanges.subscribe((value: number) => {
            this.addFormGroup(value.toString());
        });
    }
    public redirect(): void {
        this.router.navigate(['../'], { relativeTo: this.route });
    }
    public onEdit(): void {
        const conveyorCmd: ConveyorUpdateCommand = new ConveyorUpdateCommand(this.form.value, this.conveyor.id);
        this.conveyorService.put(conveyorCmd)
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
