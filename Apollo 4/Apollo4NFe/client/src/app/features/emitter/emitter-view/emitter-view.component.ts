import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subject } from 'rxjs/Subject';

import { Emitter } from '../shared/emitter.model';
import { EmitterResolveService } from '../shared/emitter-shared/emitter.service';

@Component({
    templateUrl: './emitter-view.component.html',
})
export class EmitterViewComponent implements OnInit, OnDestroy  {
    public emitter: Emitter;
    public title: string;
    public infoItems: object[];
    private ngUnsubscribe: Subject<void> = new Subject<void>();
    constructor(private resolver: EmitterResolveService) { }
    public ngOnInit(): void {
        this.resolver.onChanges
        .takeUntil(this.ngUnsubscribe)
        .subscribe((emitter: Emitter) => {
            this.emitter = emitter;
            this.createProperty();
        });
    }
    public ngOnDestroy(): void {
        this.ngUnsubscribe.next();
        this.ngUnsubscribe.complete();
    }
    private createProperty(): void {
        this.title = this.emitter.fantasyName;
        const companyName: string = 'Razão Social: ' + this.emitter.companyName;
        this.infoItems = [
            {
                value: companyName,
                description: companyName,
            },
        ];
    }
}
