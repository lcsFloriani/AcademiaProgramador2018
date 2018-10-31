import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subject } from 'rxjs/Subject';

import { Order } from '../../shared/order-model';
import { OrderResolveService } from '../../shared/order-service';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
    templateUrl: './order-detail.component.html',
})
export class OrderDetailComponent implements OnInit, OnDestroy{
    public order: Order;
    public availabilityText: string = '';
    public dateResult: number;
    public total: number;
    public isLoading: boolean = true;
    private ngUnsubscribe: Subject<void> = new Subject<void>();

    constructor(private resolver: OrderResolveService, private router: Router, private route: ActivatedRoute) {
    }

    public ngOnDestroy(): void {
        this.ngUnsubscribe.next();
        this.ngUnsubscribe.complete();
    }
    public ngOnInit(): void {
        this.resolver.onChanges
        .takeUntil(this.ngUnsubscribe)
        .subscribe((order: Order) => {
            this.isLoading = false;
            this.order = Object.assign(new Order(), order);
            this.total = this.order.calcTotal;
        });
    }
    public redirect(): void {
        this.router.navigate(['/pedidos'], { relativeTo: this.route });
    }

    public onEdit(): void {
        this.router.navigate(['edit'], { relativeTo: this.route });
    }
}
