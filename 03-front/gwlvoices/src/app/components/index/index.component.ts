import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { LoginService } from 'src/app/services/login.service';

@Component({
  selector: 'app-index',
  templateUrl: './index.component.html',
  styleUrls: ['./index.component.scss']
})
export class IndexComponent implements OnInit {

  loginForm: FormGroup;


  constructor(
    private fctrl: FormBuilder,
    private loginService: LoginService
  ) {

    this.loginForm = this.fctrl.group({ user: '', password: '' });

  }

  async ngOnInit() {

  }

  onSubmit(loginForm: AbstractControl) {
    console.log(loginForm.value)
    loginForm.reset();
  }




}
