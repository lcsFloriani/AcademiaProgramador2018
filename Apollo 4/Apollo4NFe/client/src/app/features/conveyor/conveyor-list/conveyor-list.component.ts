import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { GridDataResult, DataStateChangeEvent, SelectionEvent } from '@progress/kendo-angular-grid';
import { State } from '@progress/kendo-data-query';
import { Observable } from 'rxjs/Observable';

import { GridUtilsComponent } from '../../../shared/grid-utils/grid-utils-component';
import { ConveyorService, ConveyorGridService } from '../shared/conveyor-shared/conveyor.service';
import { ConveyorDeleteCommand, Conveyor } from '../shared/conveyor.model';

@Component({
    templateUrl: './conveyor-list.component.html',
})

export class ConveyorListComponent extends GridUtilsComponent {
    public conveyorService: ConveyorService;
    public view: Observable<GridDataResult>;
    public state: State = {
        skip: 0,
        take: 10,
    };
    constructor(public gridService: ConveyorGridService,
                public service: ConveyorService,
                private router: Router,
                private route: ActivatedRoute) {
        super();
        this.conveyorService = service;
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

    public redirectOpenConveyor(): void {
        this.router.navigate(['./', `${this.getSelectedEntities()[0].id}`],
            { relativeTo: this.route });
    }

    public redirectOpenConveyorLink(conveyor: Conveyor): void {
        this.router.navigate(['./', `${conveyor.id}`],
            { relativeTo: this.route });
    }

    public deleteConveyor(): void {
        this.gridService.loading = true;
        const conveyorToDelete: ConveyorDeleteCommand = new ConveyorDeleteCommand(this.getSelectedEntities());

        this.conveyorService.delete(conveyorToDelete)
            .take(1)
            .do(() => this.gridService.loading = false)
            .subscribe(() => {
                this.selectedRows = [];
                this.gridService.query(this.createFormattedState());
            });
    }
}
