import { Component, OnInit } from '@angular/core';
import { AbstractControl, Form, FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { UserService } from 'src/app/services/user.service';


@Component({
  selector: 'app-index',
  templateUrl: './index.component.html',
  styleUrls: ['./index.component.css']
})
export class IndexComponent implements OnInit {

  loginForm: FormGroup

  constructor(
    private userservice: UserService,
    private fctrl: FormBuilder
  ) {
    this.loginForm = fctrl.group({ user: '', password: '' });
  }

  ngOnInit() {



  }


  getLogin(loginForm: AbstractControl) {

    console.log(loginForm.value)

    loginForm.reset();

  }






}
