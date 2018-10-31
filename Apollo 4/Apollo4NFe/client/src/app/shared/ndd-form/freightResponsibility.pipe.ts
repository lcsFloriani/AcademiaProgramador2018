import { Pipe, PipeTransform } from '@angular/core';

import { EnumValues } from 'enum-values';
import { FreightResponsibility } from './../../features/conveyor/shared/conveyor.model';

@Pipe({ name: 'nddFreightResponsibility' })
/* tslint:disable */
export class FreightResponsibilityPipe implements PipeTransform {
    public transform(value: any): any {
        return EnumValues.getNameFromValue(FreightResponsibility, value);
    }
}