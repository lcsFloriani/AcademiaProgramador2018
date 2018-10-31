import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NDDTranslationModule } from 'ndd-ng-translation';
import { NDDIntlModule } from 'ndd-ng-intl';
import { NDDButtonsModule } from 'ndd-ng-buttons';
import { NDDSpinnerModule } from 'ndd-ng-spinner';

@NgModule({
    imports: [
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
        NDDTranslationModule,
        NDDIntlModule,
    ],
    exports: [
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
        NDDTranslationModule,
        NDDIntlModule,
        NDDButtonsModule,
        NDDSpinnerModule,
    ],
    declarations: [],
    providers: [],
})
export class SharedModule {}
