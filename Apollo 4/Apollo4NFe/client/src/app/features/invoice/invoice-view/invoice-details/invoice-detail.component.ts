import { Component, OnInit, OnDestroy } from '@angular/core';
import { Invoice } from '../../shared/invoice.model';
import { Subject } from 'rxjs/Subject';
import { InvoiceResolveService } from '../../shared/invoice.service';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
    templateUrl: './invoice-detail.component.html',
})
export class InvoiceDetailComponent implements OnInit, OnDestroy {
    public invoice: Invoice;
    public availabilityText: string = '';
    public result: number = 0;
    public dateResult: number = 0;
    public isLoading: boolean = true;
    private ngUnsubscribe: Subject<void> = new Subject<void>();

    constructor(private resolver: InvoiceResolveService, private router: Router, private route: ActivatedRoute) {
    }
    public ngOnInit(): void {
        this.resolver.onChanges
            .takeUntil(this.ngUnsubscribe)
            .subscribe((invoice: Invoice) => {
                this.invoice = Object.assign(new Invoice(), invoice);
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
