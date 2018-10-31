import { NumberValidator } from './../../../../shared/ndd-form/number.validator';
import { Router, ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subject } from 'rxjs/Subject';

import { InvoiceResolveService, InvoiceService } from '../../shared/invoice.service';
import { Invoice, InvoiceUpdateCommand, InvoiceFormModel } from '../../shared/invoice.model';
import { Emitter } from '../../../../features/emitter/shared/emitter.model';
import { Conveyor } from '../../../../features/conveyor/shared/conveyor.model';
import { Receiver } from '../../../..//features/receiver/shared/receiver.model';

@Component({
    templateUrl: './invoice-edit.component.html',
})
export class InvoiceEditComponent implements OnInit, OnDestroy {
    public minLength: number = 5;
    public form: FormGroup = this.fb.group({
        natureOperation: ['', [Validators.required, Validators.minLength(this.minLength)]],
        entryDate: ['', Validators.required],
        valueFreight: ['', [Validators.required, NumberValidator.isNumber]],
        emitter: ['', Validators.required],
        conveyor: ['', Validators.required],
        receiver: ['', Validators.required],
    },
    );

    public invoice: Invoice;
    public title: string;
    public infoItems: object[];
    public isLoading: boolean;

    private ngUnsubscribe: Subject<void> = new Subject<void>();
    private conveyor: Conveyor;
    private emitter: Emitter;
    private receiver: Receiver;

    constructor(private fb: FormBuilder,
        private router: Router,
        private route: ActivatedRoute,
        private invoiceService: InvoiceService,
        private resolver: InvoiceResolveService) { }

    public ngOnInit(): void {
        this.resolver.onChanges
            .takeUntil(this.ngUnsubscribe)
            .subscribe((invoice: Invoice) => {
                this.invoice = Object.assign(new Invoice(), invoice);
                this.emitter = this.invoice.emitter;
                this.conveyor = this.invoice.conveyor;
                this.receiver = this.invoice.receiver;
                this.form.setValue(new InvoiceFormModel(this.invoice));
                this.createProperty();
            });
    }
    public ngOnDestroy(): void {
        this.ngUnsubscribe.next();
        this.ngUnsubscribe.complete();
    }

    public redirect(): void {
        this.router.navigate(['../'], { relativeTo: this.route });
    }

    public onSubmit(): void {
        const invoiceCreator: InvoiceUpdateCommand = new InvoiceUpdateCommand(
            this.invoice.id,
            this.form.value,
            this.emitter,
            this.conveyor,
            this.receiver,
        );

        this.invoiceService.put(invoiceCreator)
            .take(1)
            .subscribe(() => {
                this.isLoading = true;
                this.redirect();
                this.resolver.resolveFromRouteAndNotify();
            });
    }
    public SelectedEmitter(emitter: Emitter): void {
        this.emitter = emitter;
    }
    public SelectedConveyor(conveyor: Conveyor): void {
        this.conveyor = conveyor;
    }
    public SelectedReceiver(receiver: Receiver): void {
        this.receiver = receiver;
    }

    private createProperty(): void {
        this.title = this.invoice.natureOperation;
        const companyName: string = 'Data de Entrada: ' + this.invoice.entryDate;
        this.infoItems = [
            {
                value: companyName,
                description: companyName,
            },
        ];
    }
}
