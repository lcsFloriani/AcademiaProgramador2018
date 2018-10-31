import { Component, OnDestroy, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Subject } from 'rxjs/Subject';

import { EmitenteResolveService } from '../../shared/emitente.service';
import { Emitente } from '../../shared/emitente.model';

@Component({
    templateUrl: './emitente-detail.component.html',
})

export class EmitenteDetailComponent implements OnInit, OnDestroy {
    public emitente: Emitente;
    public availabilityText: string = '';
    public dateResult: number;
    public total: number;
    public isLoading: boolean = true;
    private ngUnsubscribe: Subject<void> = new Subject<void>();

    constructor(private resolver: EmitenteResolveService, private router: Router, private route: ActivatedRoute) {
    }

    public ngOnInit(): void {
        this.resolver.onChanges
            .takeUntil(this.ngUnsubscribe)
            .subscribe((emitente: Emitente) => {
                this.isLoading = false;
                this.emitente = Object.assign(new Emitente(), emitente);
            });
    }

    public ngOnDestroy(): void {
        this.ngUnsubscribe.next();
        this.ngUnsubscribe.complete();
    }

    public redirect(): void {
        this.router.navigate(['/'], { relativeTo: this.route });
    }

    public onEdit(): void {
        this.router.navigate(['edit'], { relativeTo: this.route });
    }
}
