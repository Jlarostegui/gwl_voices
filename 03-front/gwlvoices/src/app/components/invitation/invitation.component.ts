import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormControl, FormGroupDirective, NgForm, Validators } from '@angular/forms';
import { ErrorStateMatcher } from '@angular/material/core';
import { Router } from '@angular/router';
import Swal from 'sweetalert2';

export class MyErrorStateMatcher implements ErrorStateMatcher {
  isErrorState(control: FormControl | null, form: FormGroupDirective | NgForm | null): boolean {
    const isSubmitted = form && form.submitted;
    return !!(control && control.invalid && (control.dirty || control.touched || isSubmitted));
  }
}

@Component({
  selector: 'app-invitation',
  templateUrl: './invitation.component.html',
  styleUrls: ['./invitation.component.scss']
})
export class InvitationComponent implements OnInit {

  emailInvitation = new FormControl('', [Validators.required, Validators.email]);
  matcher = new MyErrorStateMatcher();


  constructor(
    private router: Router
  ) { }

  ngOnInit(): void {
  }

  onSubmit(emailInvitation: AbstractControl) {
    const alert = Swal.mixin({
      // toast: false,
      showConfirmButton: true,
      timer: 2000,
      timerProgressBar: true,
      didOpen: (alert) => {
        alert.addEventListener('mouseenter', Swal.stopTimer)
        alert.addEventListener('mouseleave', Swal.resumeTimer)
      }

    });

    if (emailInvitation.valid) {
      alert.fire({
        position: 'top-end',
        icon: 'info',
        title: 'Invitation to register sent',
      })

    } else {
      alert.fire({
        position: 'top-end',
        icon: 'error',
        title: 'Introduce an valid Mail',
      })

    }
    emailInvitation.reset();
    emailInvitation.markAsPending();
  }


}

