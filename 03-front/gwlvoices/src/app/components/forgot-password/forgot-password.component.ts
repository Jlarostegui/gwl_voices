import { Component, OnInit } from '@angular/core';
import { Validators, FormBuilder, AbstractControl, FormGroup } from '@angular/forms';
import { LoginService } from 'src/app/services/login.service';
import { Router } from '@angular/router';

import Swal from 'sweetalert2';

@Component({
  selector: 'app-forgot-password',
  templateUrl: './forgot-password.component.html',
  styleUrls: ['./forgot-password.component.scss']
})
export class ForgotPasswordComponent implements OnInit {
  email: FormGroup;


  constructor(
    private formBuilder: FormBuilder,
    private loginService: LoginService,
    private router: Router,
  ) {
    this.email = this.formBuilder.group({
      email: ['', Validators.email]
    });

  }

  async ngOnInit() {

  }

  onSubmit(mail: AbstractControl) {

    this.loginService.forgotPassword(mail.value)
    const alert = Swal.mixin({
      showConfirmButton: true,
      timer: 2000,
      timerProgressBar: true,
      didOpen: (alert) => {
        alert.addEventListener('mouseenter', Swal.stopTimer)
        alert.addEventListener('mouseleave', Swal.resumeTimer)
      }

    })

    alert.fire({
      icon: 'info',
      title: 'We send an email for recovery your password'
    }).then(function () {
      window.location.href = "/login";
    })

  }



}


