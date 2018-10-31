import { Component, OnInit, OnDestroy } from '@angular/core';
import { ProductResolveService } from '../../shared/product.service';
import { Product } from '../../shared/product.model';
import { Subject } from 'rxjs/Subject';
import { Router, ActivatedRoute, UrlSegment } from '@angular/router';
@Component({
    templateUrl: './product-detail.component.html',

})

export class ProductDetailComponent implements OnInit, OnDestroy {

    public availabilityText: string = '';
    public product: Product;
    public isLoading: boolean = false;
    private ngUnsubscribe: Subject<void> = new Subject<void>();
    constructor(private resolver: ProductResolveService, private route: ActivatedRoute, public router: Router) {
        this.isLoading = true;
    }

    public ngOnInit(): void {
        this.resolver.onChanges
            .takeUntil(this.ngUnsubscribe)
            .subscribe((product: Product) => {
                this.product = Object.assign(new Product(), product);
                this.availabilityText = product.isAvailable ? 'Disponível' : 'Indisponível';
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
