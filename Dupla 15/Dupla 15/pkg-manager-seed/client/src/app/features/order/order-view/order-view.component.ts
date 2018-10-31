import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subject } from 'rxjs/Subject';

import { Order } from '../shared/order-model';
import { OrderResolveService } from '../shared/order-service';

@Component({
    templateUrl: './order-view.component.html',
})

export class OrderViewComponent implements OnInit, OnDestroy {
    public order: Order;
    public title: string;
    public infoItems: object[];
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
    private createProperty(): void {
        this.title = this.order.customer;
        const productName: string = 'Produto: ' + this.order.productName;
        const quantity: string = 'Quantidade: ' + this.order.quantity;
        this.infoItems = [
            {
                value: productName,
                description: productName,
            },
            {
                value: quantity,
                description: quantity,
            },
        ];
    }

}
