import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { timer } from 'rxjs';
import { User } from 'src/app/models/user_model';
import { LoginService } from 'src/app/services/login.service';

import Swal from 'sweetalert2';

@Component({
  selector: 'app-index',
  templateUrl: './index.component.html',
  styleUrls: ['./index.component.scss']
})
export class IndexComponent implements OnInit {

  loginForm: FormGroup;
  user: User;
  token?: string;
  name?: string = "";

  constructor(
    private fctrl: FormBuilder,
    private loginService: LoginService,
    private router: Router

  ) {

    this.token = ""
    this.loginForm = this.fctrl.group(
      {
        user: ['', Validators.required],
        password: ['', Validators.required]
      });

    this.user = new User();
  }

  async ngOnInit() {


  }



  onSubmit(loginForm: AbstractControl) {

    return this.loginService.login(loginForm.value).subscribe(
      resp => {
        this.token = resp.token;
        this.name = resp.name;
        if (this.token != null) {
          sessionStorage.setItem('token', this.token)

          const alert = Swal.mixin({
            // toast: false,
            showConfirmButton: false,
            timer: 3000,
            timerProgressBar: true,
            didOpen: (alert) => {
              alert.addEventListener('mouseenter', Swal.stopTimer)
              alert.addEventListener('mouseleave', Swal.resumeTimer)
            }

          });

          alert.fire({
            icon: 'success',
            title: 'Welcome   ' + this.name,
          });

          this.router.navigate(['/users'])
        }
        loginForm.reset();

      }

    )
  }
}
