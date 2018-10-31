import { Component, OnInit } from '@angular/core';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';

import { EmitenteService, EmitenteResolveService } from '../../shared/emitente.service';
import { Emitente, EmitenteEditCommand } from '../../shared/emitente.model';
import { Subject } from 'rxjs/Subject';

@Component({
    templateUrl: './emitente-edit.component.html',
})

export class EmitenteEditComponent implements OnInit {
    public emitente: Emitente;
    public emitenteService: EmitenteService;
    public isLoading: boolean = false;
    public title: string = 'Editar Produto';

    public emitenteEditForm: FormGroup = this.fb.group({
        id: ['', Validators.required],
        nome: ['', Validators.required],
        cnpj: ['', Validators.required],
        razaoSocial: ['', Validators.required],
        inscricaoEstadual: ['', Validators.required],
        localizacao: ['', [Validators.required]],
    });
    private ngUnsubscribe: Subject<void> = new Subject<void>();

    constructor(private fb: FormBuilder,
        private service: EmitenteService,
        private resolver: EmitenteResolveService,
        private router: Router,
        private route: ActivatedRoute) {
        this.emitenteService = this.service;
    }

    public ngOnInit(): void {
        const index: number = 16;
        this.resolver.onChanges
            .takeUntil(this.ngUnsubscribe)
            .subscribe((emitente: Emitente) => {
                this.isLoading = false;
                this.emitente = Object.assign(new Emitente(), emitente);
                this.emitenteEditForm.setValue({
                    id: this.emitente.id,
                    nome: this.emitente.nome,
                    razaoSocial: this.emitente.razaoSocial,
                    cnpj: this.emitente.cnpj,
                    inscricaoEstadual: this.emitente.inscricaoEstadual,
                    localizacao: this.emitente.localizacao,
                });
            });

    }
    public redirect(): void {
        this.router.navigate(['../'], { relativeTo: this.route });
    }

    public onEdit(): void {
        const emitenteEdit: EmitenteEditCommand = new EmitenteEditCommand(this.emitenteEditForm.value);
        this.isLoading = true;
        this.emitenteService.put(emitenteEdit)
            .take(1)
            .subscribe(() => {
                this.isLoading = false;
                this.resolver.resolveFromRouteAndNotify();
                this.redirect();
            });
    }
}
