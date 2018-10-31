import { Component, OnInit, OnDestroy } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Subject } from 'rxjs/Subject';

import { EmitterResolveService } from '../../shared/emitter-shared/emitter.service';
import { Emitter } from '../../shared/emitter.model';

@Component({
    templateUrl: './emitter-detail.component.html',
})

export class EmitterDetailComponent implements OnInit, OnDestroy {
    public emitter: Emitter;
    public isLoading: boolean = true;
    private ngUnsubscribe: Subject<void> = new Subject<void>();
    constructor(private resolver: EmitterResolveService,
                private router: Router,
                private route: ActivatedRoute) {
    }

    public ngOnInit(): void {
        this.resolver.onChanges
        .takeUntil(this.ngUnsubscribe)
        .subscribe((emitter: Emitter) => {
            this.isLoading = false;
            this.emitter = Object.assign(new Emitter(), emitter);
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
