import { Component, OnInit, OnDestroy } from '@angular/core';
import { Order } from '../shared/order.model';
import { Subject } from 'rxjs/Subject';
import { OrderResolveService } from '../shared/order.service';
@Component({
    templateUrl: './order-view.component.html',
})

export class OrderViewComponent implements OnInit, OnDestroy {

    public title: string;
    public order: Order;
    private ngUnsubscribe: Subject<void> = new Subject<void>();

    constructor(private resolver: OrderResolveService) {

    }

    public ngOnInit(): void {
        this.resolver.onChanges
            .takeUntil(this.ngUnsubscribe)
            .subscribe((order: Order) => {
                this.order = order;
                this.createProperty();
            });
    }

    public ngOnDestroy(): void {
        this.ngUnsubscribe.next();
        this.ngUnsubscribe.complete();
    }

    public createProperty(): void {
        this.title = this.order.customer;
    }

}
