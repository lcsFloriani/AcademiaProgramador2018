import { Component, OnInit, OnDestroy } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Subject } from 'rxjs/Subject';

import { Product } from '../../shared/product.model';
import { ProductResolveService } from '../../shared/product.service';

@Component({
    templateUrl: './product-detail.component.html',
})
export class ProductDetailComponent implements OnInit, OnDestroy {
    public product: Product;
    public availabilityText: string = '';
    public result: number = 0;
    public dateResult: number = 0;
    public isLoading: boolean = true;
    private ngUnsubscribe: Subject<void> = new Subject<void>();

    constructor(private resolver: ProductResolveService,
                private router: Router,
                private route: ActivatedRoute) {
    }
    public ngOnInit(): void {
        this.resolver.onChanges
            .takeUntil(this.ngUnsubscribe)
            .subscribe((product: Product) => {
                this.product = Object.assign(new Product(), product);
                this.isLoading = false;
            });
    }
    public onEdit(): void {
    this.router.navigate(['./edit'], { relativeTo: this.route });
    }
    public redirect(): void {
      this.router.navigate(['/'], { relativeTo: this.route });
    }
    public ngOnDestroy(): void {
        this.ngUnsubscribe.next();
        this.ngUnsubscribe.complete();
    }

}
