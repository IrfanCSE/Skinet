import { Component, Input, OnInit, ViewChild, ElementRef, Self } from '@angular/core';
import { ControlValueAccessor, NgControl } from '@angular/forms';

@Component({
  selector: 'app-input-field',
  templateUrl: './input-field.component.html',
  styleUrls: ['./input-field.component.scss']
})
export class InputFieldComponent implements OnInit, ControlValueAccessor{

  @ViewChild('input', {static: true}) input: ElementRef;
  @Input() type = 'text';
  @Input() label: string;

  constructor(@Self() public controlDir: NgControl) {
    controlDir.valueAccessor = this;
  }

  ngOnInit(): void {
    const control = this.controlDir.control;
    const validator = control.validator ? [control.validator] : [];
    const asyncValidator = control.asyncValidator ? [control.asyncValidator] : [];

    control.setValidators(validator);
    control.setAsyncValidators(asyncValidator);
    control.updateValueAndValidity();
  }

  onChange(event: any){}

  onTouched(){}

  writeValue(obj: any): void {
    this.input.nativeElement.value = obj || '';
  }

  registerOnChange(fn: any): void {
    this.onChange = fn;
  }

  registerOnTouched(fn: any): void {
    this.onTouched = fn;
  }

}
