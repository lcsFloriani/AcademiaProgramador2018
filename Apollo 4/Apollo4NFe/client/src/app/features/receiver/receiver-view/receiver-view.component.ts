import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subject } from 'rxjs/Subject';

import { ReceiverResolveService } from '../shared/receiver-shared/receiver.service';
import { Receiver } from '../shared/receiver.model';

@Component({
    templateUrl: './receiver-view.component.html',
})
export class ReceiverViewComponent implements OnInit, OnDestroy  {
    public receiver: Receiver;
    public title: string;
    public infoItems: object[];
    private ngUnsubscribe: Subject<void> = new Subject<void>();
    constructor(private resolver: ReceiverResolveService) { }
    public ngOnInit(): void {
        this.resolver.onChanges
        .takeUntil(this.ngUnsubscribe)
        .subscribe((receiver: Receiver) => {
            this.receiver = receiver;
            this.createProperty();
        });
    }
    public ngOnDestroy(): void {
        this.ngUnsubscribe.next();
        this.ngUnsubscribe.complete();
    }
    private createProperty(): void {
        this.title = this.receiver.nameCompanyName;
        const companyName: string = 'Nome\Razão Social: ' + this.receiver.nameCompanyName;
        this.infoItems = [
            {
                value: companyName,
                description: companyName,
            },
        ];
    }
}
