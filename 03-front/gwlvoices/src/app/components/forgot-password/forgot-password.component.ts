import { Component, OnInit } from '@angular/core';
import { FormControl, Validators, FormBuilder, AbstractControl, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-forgot-password',
  templateUrl: './forgot-password.component.html',
  styleUrls: ['./forgot-password.component.scss']
})
export class ForgotPasswordComponent implements OnInit {
  email: FormGroup;


  constructor(
    private formBuilder: FormBuilder
  ) {
    this.email = this.formBuilder.group({
      email: ['', Validators.email]
    });

  }

  async ngOnInit() {

  }

  onSubmit(registerForm: AbstractControl) {

    console.log(registerForm.value);
  }

}
