import { FormGroup, Validators, FormBuilder } from '@angular/forms';
import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Subject } from 'rxjs/Subject';

import { EmitterService, EmitterResolveService } from '../../shared/emitter-shared/emitter.service';
import { EmitterUpdateCommand, Emitter } from '../../shared/emitter.model';
import { CpfCnpjValidators } from '../../../../shared/ndd-form/cpf-cnpj.validator';

@Component({
    templateUrl: './emitter-edit.component.html',
})
export class EmitterEditComponent implements OnInit{

    public emitter: Emitter;
    public isLoading: boolean;
    public form: FormGroup = this.fb.group({
        id: [''],
        fantasyName: ['', Validators.required],
        companyName: ['', Validators.required],
        cnpj: ['', [Validators.required, CpfCnpjValidators.checkCnpj]],
        stateRegistration: ['', Validators.required],
        municipalRegistration: ['', Validators.required],
        address: this.fb.group({
            street: ['', Validators.required],
            number: ['', Validators.required],
            neighbourhood: ['', Validators.required],
            city: ['', Validators.required],
            state: ['', Validators.required],
        }),
    });
    private ngUnsubscribe: Subject<void> = new Subject<void>();
    constructor(private fb: FormBuilder,
                private router: Router,
                private resolver: EmitterResolveService,
                private emitterService: EmitterService,
                private route: ActivatedRoute)
                { }

    public ngOnInit(): void {
        this.isLoading = false;
        this.resolver.onChanges
            .takeUntil(this.ngUnsubscribe)
            .subscribe((emitter: Emitter) => {
                this.isLoading = false;
                this.emitter = Object.assign(new Emitter(), emitter);
                this.form.setValue({
                    id: this.emitter.id,
                    fantasyName: this.emitter.fantasyName,
                    companyName: this.emitter.companyName,
                    cnpj: this.emitter.cnpj,
                    stateRegistration: this.emitter.stateRegistration,
                    municipalRegistration: this.emitter.municipalRegistration,
                    address: {
                        street: this.emitter.address.street,
                        number: this.emitter.address.number,
                        neighbourhood: this.emitter.address.neighbourhood,
                        city: this.emitter.address.city,
                        state: this.emitter.address.state,
                    },
                });
            });
    }
    public redirect(): void {
        this.router.navigate(['../'], { relativeTo: this.route });
    }
    public onEdit(): void {
        const emitterCmd: EmitterUpdateCommand = new EmitterUpdateCommand(this.form.value);
        this.emitterService.put(emitterCmd)
            .take(1)
            .subscribe(() => {
                this.isLoading = true;
                this.redirect();
                this.resolver.resolveFromRouteAndNotify();
            });
    }

}
