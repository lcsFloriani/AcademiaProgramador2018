import { Component, OnInit, OnDestroy } from '@angular/core';
import { OrderResolveService } from '../../shared/order.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Order } from '../../shared/order.model';
import { Subject } from 'rxjs/Subject';

@Component({
    templateUrl: './order-detail.component.html',
})

export class OrderDetailComponent implements OnInit, OnDestroy{

    public order: Order;
    public isLoading: boolean = false;
    private ngUnsubscribe: Subject<void> = new Subject<void>();

    constructor(private resolver: OrderResolveService, private route: ActivatedRoute, public router: Router) {
        this.isLoading = true;
    }
    public ngOnInit(): void {
        this.resolver.onChanges
            .takeUntil(this.ngUnsubscribe)
            .subscribe((order: Order) => {
                this.order = Object.assign(new Order(), order);
                this.isLoading = false;
            });
    }

    public ngOnDestroy(): void {
        this.ngUnsubscribe.next();
        this.ngUnsubscribe.complete();
    }

    public onEdit(): void {
        this.router.navigate(['./', `editar`], { relativeTo: this.route });
    }
}
