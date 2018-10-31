import { NumberValidator } from './../../../shared/ndd-form/number.validator';
import { OnInit, Component } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';

import { Conveyor } from '../../conveyor/shared/conveyor.model';
import { Emitter } from '../../emitter/shared/emitter.model';
import { Receiver } from '../../receiver/shared/receiver.model';
import { InvoiceService } from '../shared/invoice.service';
import { InvoiceRegisterCommand } from '../shared/invoice.model';

@Component({
    templateUrl: './invoice-creator.component.html',
})

export class InvoiceCreatorComponent implements OnInit {
    public title: string;
    public minLength: number = 5;
    public isLoading: boolean;
    public form: FormGroup = this.fb.group({
            emitter: ['', Validators.required],
            conveyor: ['', Validators.required],
            receiver: ['', Validators.required],
            natureOperation: ['', [Validators.required, Validators.minLength(this.minLength)]],
            entryDate: ['', Validators.required],
            valueFreight: ['', [Validators.required, NumberValidator.isNumber]],
        },
    );
    private conveyor: Conveyor;
    private emitter: Emitter;
    private receiver: Receiver;
    constructor(private fb: FormBuilder,
                private router: Router,
                private invoiceService: InvoiceService,
                private route: ActivatedRoute)
                { }

    public ngOnInit(): void {
        this.title = 'Criar Nota Fiscal';
        this.isLoading = false;
    }
    public redirect(): void {
        this.router.navigate(['../'], { relativeTo: this.route });
    }
    public onCreate(): void {
        const invoiceCreator: InvoiceRegisterCommand = new InvoiceRegisterCommand(this.form.value);
        invoiceCreator.SetEmitter(this.emitter);
        invoiceCreator.SetConveyor(this.conveyor);
        invoiceCreator.SetReceiver(this.receiver);

        this.invoiceService.post(invoiceCreator)
            .take(1)
            .subscribe(() => {
                this.isLoading = true;
                this.redirect();
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
}
