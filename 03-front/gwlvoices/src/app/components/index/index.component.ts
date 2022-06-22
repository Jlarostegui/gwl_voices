import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { User } from 'src/app/models/user_model';
import { LoginService } from 'src/app/services/login.service';

@Component({
  selector: 'app-index',
  templateUrl: './index.component.html',
  styleUrls: ['./index.component.scss']
})
export class IndexComponent implements OnInit {

  loginForm: FormGroup;
  user: User;
  token?: string = "";

  constructor(
    private fctrl: FormBuilder,
    private loginService: LoginService
  ) {

    this.loginForm = this.fctrl.group({ user: '', password: '' });
    this.user = new User();
  }

  async ngOnInit() {

  }

  onSubmit(loginForm: AbstractControl) {

    let response = this.loginService.login(loginForm.value)

    console.log(response, "Index");


    loginForm.reset();
  }




}
