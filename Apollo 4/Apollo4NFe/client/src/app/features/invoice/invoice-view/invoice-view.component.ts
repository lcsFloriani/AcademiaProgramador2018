import { OnInit, OnDestroy, Component } from '@angular/core';
import { Invoice } from '../shared/invoice.model';
import { Subject } from 'rxjs/Subject';
import { InvoiceResolveService } from '../shared/invoice.service';

@Component({
    templateUrl: './invoice-view.component.html',
})
export class InvoiceViewComponent implements OnInit, OnDestroy {
    public invoice: Invoice;
    public infoItems: object[];
    public title: string;
    private ngUnsubscribe: Subject<void> = new Subject<void>();
    constructor(private resolver: InvoiceResolveService) {
    }

    public ngOnInit(): void {
        this.resolver.onChanges
            .takeUntil(this.ngUnsubscribe)
            .subscribe((invoice: Invoice) => {
                this.invoice = invoice;
                this.createProperty();
            });
    }
    public ngOnDestroy(): void {
        this.ngUnsubscribe.next();
        this.ngUnsubscribe.complete();
    }
    public createProperty(): void {
        this.title = 'Numero de identificação da nota: ' + this.invoice.id.toString();
        const descriptionInvoice: string =
           'Data de entrada: ' + this.invoice.entryDate;
        const valueDescription: string =
            'Natureza da opração: ' + this.invoice.natureOperation;
        this.infoItems = [
            {
                value: valueDescription,
                description: valueDescription,
            },
            {
                value: descriptionInvoice,
                description: descriptionInvoice,
            },
        ];
    }
}
