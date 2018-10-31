import { Component, OnInit, OnDestroy } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Subject } from 'rxjs/Subject';

import { Receiver } from '../../shared/receiver.model';
import { ReceiverResolveService } from '../../shared/receiver-shared/receiver.service';

@Component({
    templateUrl: './receiver-detail.component.html',
})

export class ReceiverDetailComponent implements OnInit, OnDestroy {

    public receiver: Receiver;
    public isLoading: boolean = true;
    private ngUnsubscribe: Subject<void> = new Subject<void>();

    constructor(private resolver: ReceiverResolveService,
                private router: Router,
                private route: ActivatedRoute) {
    }

    public ngOnInit(): void {
        this.resolver.onChanges
        .takeUntil(this.ngUnsubscribe)
        .subscribe((receiver: Receiver) => {
            this.isLoading = false;
            this.receiver = Object.assign(new Receiver(), receiver);
        });
    }

    public ngOnDestroy(): void {
        this.ngUnsubscribe.next();
        this.ngUnsubscribe.complete();
    }

    public redirect(): void {
        this.router.navigate(['/receivers'], { relativeTo: this.route });
    }

    public onEdit(): void {
        this.router.navigate(['edit'], { relativeTo: this.route });
    }
}
