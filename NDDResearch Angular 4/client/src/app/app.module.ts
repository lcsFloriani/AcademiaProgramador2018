import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { NDDCoreModule } from 'ndd-ng-core';

import { CoreModule } from './core/core.module';
import { SharedModule } from './shared/shared.module';

import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';

@NgModule({
    imports: [
        BrowserModule,
        NDDCoreModule,
        CoreModule,
        SharedModule,
        AppRoutingModule,
    ],
    declarations: [
        AppComponent,
    ],
    bootstrap: [AppComponent],
})
export class AppModule { }
