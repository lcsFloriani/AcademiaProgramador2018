import { Component, OnDestroy, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Subject } from 'rxjs/Subject';

import { ProductResolveService } from '../../shared/product.service';
import { Product } from '../../shared/product.model';

@Component({
    templateUrl: './product-detail.component.html',
})

export class ProductDetailComponent implements OnInit, OnDestroy {
    public product: Product;
    public availabilityText: string = '';
    public dateResult: number;
    public total: number;
    public isLoading: boolean = true;
    private ngUnsubscribe: Subject<void> = new Subject<void>();

    constructor(private resolver: ProductResolveService, private router: Router, private route: ActivatedRoute) {
    }

    public ngOnInit(): void {
        this.resolver.onChanges
            .takeUntil(this.ngUnsubscribe)
            .subscribe((product: Product) => {
                this.isLoading = false;
                this.product = Object.assign(new Product(), product);
                this.availabilityText = product.isAvailable ? 'Disponivel' : 'Indisponível';
                this.dateResult = this.product.calcDate;
                this.total = this.product.calcResult;
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
