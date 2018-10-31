import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subject } from 'rxjs/Subject';

import { Conveyor } from '../shared/conveyor.model';
import { ConveyorResolveService } from '../shared/conveyor-shared/conveyor.service';
@Component({
    templateUrl: './conveyor-view.component.html',
})

export class ConveyorViewComponent implements OnInit, OnDestroy {
    public conveyor: Conveyor;
    public title: string;
    public infoItems: object[];
    private ngUnsubscribe: Subject<void> = new Subject<void>();
    constructor(private resolver: ConveyorResolveService) { }
    public ngOnInit(): void {
        this.conveyor = new Conveyor();
        this.resolver.onChanges
            .takeUntil(this.ngUnsubscribe)
            .subscribe((conveyorr: Conveyor) => {
                this.conveyor = conveyorr;
                this.createProperty();
            });
    }
    public ngOnDestroy(): void {
        this.ngUnsubscribe.next();
        this.ngUnsubscribe.complete();
    }
    private createProperty(): void {
        this.title = this.conveyor.nameCompanyName;
    }
}
