import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-create-wg',
  templateUrl: './create-wg.component.html',
  styleUrls: ['./create-wg.component.scss']
})
export class CreateWgComponent implements OnInit {

  wgForm: FormGroup;
  constructor(
    private fctrl: FormBuilder,
  ) {

    this.wgForm = this.fctrl.group(
      {
        user: ['', Validators.required],
        password: ['', Validators.required]
      });
  }

  ngOnInit(): void {
  }

  onSubmit(wgForm: AbstractControl) {

  }

}
