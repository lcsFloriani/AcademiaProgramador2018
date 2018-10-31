import { Component } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { State } from '@progress/kendo-data-query';
import { DataStateChangeEvent, SelectionEvent, GridDataResult } from '@progress/kendo-angular-grid';
import { Observable } from 'rxjs/Observable';

import { GridUtilsComponent } from '../../../shared/grid-utils/grid-utils-component';
import { EmitterGridService, EmitterService } from '../shared/emitter-shared/emitter.service';
import { EmitterDeleteCommand, Emitter } from './../shared/emitter.model';
@Component({
    templateUrl: './emitter-list.component.html',
})
export class EmitterListComponent extends GridUtilsComponent {
    public emitterService: EmitterService;
    public view: Observable<GridDataResult>;
    public state: State = {
        skip: 0,
        take: 10,
    };
    constructor(public gridService: EmitterGridService,
                public service: EmitterService,
                private router: Router,
                private route: ActivatedRoute) {
        super();
        this.emitterService = service;
        this.gridService.query(this.createFormattedState());
    }

    public dataStateChange(state: DataStateChangeEvent): void {
        this.state = state;
        this.gridService.query(this.createFormattedState());
        this.selectedRows = [];
    }

    public onSelectionChange(event: SelectionEvent): void {
        this.updateSelectedRows(event.selectedRows, true);
        this.updateSelectedRows(event.deselectedRows, false);
    }

    public redirectOpenEmitter(): void {
        this.router.navigate(['./', `${this.getSelectedEntities()[0].id}`],
            { relativeTo: this.route });
    }

    public redirectOpenEmitterLink(emitter: Emitter): void {
        this.router.navigate(['./', `${emitter.id}`],
            { relativeTo: this.route });
    }

    public deleteEmitter(): void {
        this.gridService.loading = true;
        const emitterToDelete: EmitterDeleteCommand = new EmitterDeleteCommand(this.getSelectedEntities());

        this.emitterService.delete(emitterToDelete)
            .take(1)
            .do(() => this.gridService.loading = false)
            .subscribe(() => {
                this.selectedRows = [];
                this.gridService.query(this.createFormattedState());
            });
    }
}
