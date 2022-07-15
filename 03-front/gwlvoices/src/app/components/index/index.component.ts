import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
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

  constructor(
    private fctrl: FormBuilder,
    private loginService: LoginService,
    private router: Router

  ) {

    this.loginForm = this.fctrl.group(
      {
        user: ['', Validators.required],
        password: ['', Validators.required]
      });

    this.user = new User();
  }

  async ngOnInit() { }

  onSubmit(loginForm: AbstractControl) {

    return this.loginService.login(loginForm.value).subscribe(
      resp => {

        this.user = resp;
        if (this.user.token != null) {

          sessionStorage.setItem('token', this.user.token)


          const alert = Swal.mixin({
            // toast: false,
            showConfirmButton: false,
            timer: 2000,
            timerProgressBar: true,
            didOpen: (alert) => {
              alert.addEventListener('mouseenter', Swal.stopTimer)
              alert.addEventListener('mouseleave', Swal.resumeTimer)
            }

          });

          alert.fire({
            icon: 'success',
            title: 'Welcome   ' + this.user.name,

          });
        };

        if (this.user.rol === 'user') {
          loginForm.reset();
          setTimeout(() => {
            this.router.navigate(['/detail', this.user.id])
          }, 2000);
        } else {
          loginForm.markAsPending();
          loginForm.reset();
          setTimeout(() => {
            this.router.navigate([`/admin/`, this.user.id])
          }, 2000);
        }

      }

    )
  }
}
