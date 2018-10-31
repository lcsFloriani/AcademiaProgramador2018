import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subject } from 'rxjs/Subject';

import { Emitente } from './../shared/emitente.model';
import { EmitenteResolveService } from './../shared/emitente.service';

@Component({
    templateUrl: './emitente-view.component.html',
})

export class EmitenteViewComponent implements OnInit, OnDestroy {
    public emitente: Emitente;
    public title: string;
    public infoItems: object[];
    private ngUnsubscribe: Subject<void> = new Subject<void>();

    constructor(private resolver: EmitenteResolveService) {
    }

    public ngOnInit(): void {
        this.resolver.onChanges
            .takeUntil(this.ngUnsubscribe)
            .subscribe((emitente: Emitente) => {
                this.emitente = emitente;
                this.createProperty();
            });
    }

    public ngOnDestroy(): void {
        this.ngUnsubscribe.next();
        this.ngUnsubscribe.complete();
    }
    private createProperty(): void {
        this.title = this.emitente.nome;
        const nameDescription: string =
        'Nome: ' + this.emitente.nome;
        const cnpjDescription: string =
        'CNPJ: ' + this.emitente.cnpj;

        this.infoItems = [
            {
                value: nameDescription,
                description: nameDescription,
            },
            {
                value: cnpjDescription,
                description: cnpjDescription,
            },
        ];
    }
}
