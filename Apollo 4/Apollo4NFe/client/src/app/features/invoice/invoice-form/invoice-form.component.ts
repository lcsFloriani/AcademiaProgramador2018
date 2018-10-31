import { FormGroup } from '@angular/forms';
import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Subject } from 'rxjs/Subject';

import { InvoiceService } from '../shared/invoice.service';
import { Emitter } from '../../emitter/shared/emitter.model';
import { Conveyor } from '../../conveyor/shared/conveyor.model';
import { Receiver } from '../../receiver/shared/receiver.model';
import { EmitterSharedService } from './../../emitter/shared/emitter-shared/emitter.service';
import { ConveyorSharedService } from '../../conveyor/shared/conveyor-shared/conveyor.service';
import { ReceiverSharedService } from '../../receiver/shared/receiver-shared/receiver.service';

@Component({
    templateUrl: './invoice-form.component.html',
    selector: 'ndd-invoice-form',
})

export class InvoiceFormComponent implements OnInit {

    @Input() public formModel: FormGroup;
    @Output() public selectedEmitter: EventEmitter<Emitter> = new EventEmitter();
    @Output() public selectedConveyor: EventEmitter<Conveyor> = new EventEmitter();
    @Output() public selectedReceiver: EventEmitter<Receiver> = new EventEmitter();

    public emitterData: Emitter[];
    public conveyorData: Conveyor[];
    public receiverData: Receiver[];

    public listEmitters: Emitter[] = [];
    public listConveyors: Conveyor[] = [];
    public invoiceService: InvoiceService;
    public trezentos: number = 300;

    private onEmitterFilterChange: Subject<string> = new Subject<string>();
    private onConveyorFilterChange: Subject<string> = new Subject<string>();
    private onReceiverFilterChange: Subject<string> = new Subject<string>();

        constructor(private service: InvoiceService,
                    private emitterService: EmitterSharedService,
                    private conveyorService: ConveyorSharedService,
                    private receiverService: ReceiverSharedService) {
                        this.invoiceService = this.service;
    }
    public ngOnInit(): void {
        this.onEmitterFilterChange
            .debounceTime(this.trezentos)
            .do((value: any) => {
                this.emitterService.query(value);
            })
            .switchMap((value: any, index: number) => this.emitterService)
            .subscribe((response: any) => {
                this.emitterData = response;
            });
        this.onConveyorFilterChange
            .debounceTime(this.trezentos)
            .do((value: any) => {
                this.conveyorService.query(value);
            })
            .switchMap((value: any, index: number) => this.conveyorService)
            .subscribe((response: any) => {
                this.conveyorData = response;
            });
        this.onReceiverFilterChange
            .debounceTime(this.trezentos)
            .do((value: any) => {
                this.receiverService.query(value);
            })
            .switchMap((value: any, index: number) => this.receiverService)
            .subscribe((response: any) => {
                this.receiverData = response;
            });
    }
    public getSelectedEmitter(): void {
        this.selectedEmitter.emit(this.emitterData.filter((emitter: Emitter) => emitter.fantasyName === this.formModel.value.emitter)[0]);
    }
    public getSelectedConveyor(): void {
        this.selectedConveyor.emit(this.conveyorData.filter((conveyor: Conveyor) => conveyor.nameCompanyName === this.formModel.value.conveyor)[0]);
    }
    public getSelectedReceiver(): void {
        this.selectedReceiver.emit(this.receiverData.filter((receiver: Receiver) => receiver.nameCompanyName === this.formModel.value.receiver)[0]);
    }
    public onEmitterAutoCompleteChange(value: string): void {
        this.onEmitterFilterChange.next(value);
    }
    public onConveyorAutoCompleteChange(value: string): void {
        this.onConveyorFilterChange.next(value);
    }
    public onReceiverAutoCompleteChange(value: string): void {
        this.onReceiverFilterChange.next(value);
    }
}
