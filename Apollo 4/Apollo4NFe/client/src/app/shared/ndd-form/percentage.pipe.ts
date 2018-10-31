import { Pipe, PipeTransform } from '@angular/core';

@Pipe({ name: 'nddPercentage' })
/* tslint:disable */
export class PercentagePipe implements PipeTransform {
    public transform(value: any): string {
        return (value * 100) + "%";
    }
}