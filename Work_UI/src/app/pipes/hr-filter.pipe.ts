import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'HrFilterPipe',
})
export class HrFilterPipe implements PipeTransform {
  transform(value: any, input: string) {
    if (input) {
      input = input.toLowerCase();
      return value.filter(function (el: any) {
        return el.Position.toLowerCase().indexOf(input) > -1;
      })
    }
    return value;
  }
}
