import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { UserService } from 'src/app/services/user.service';
import { User } from 'src/app/models/user_model';

import Swal from 'sweetalert2';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {

  user: User;
  registerForm: FormGroup;
  hide = true;

  constructor(
    private userService: UserService,
    private formBuilder: FormBuilder,
    private router: Router
  ) {
    this.user = new User();
    this.registerForm = this.formBuilder.group({
      name: ['', [Validators.required,Validators.minLength(3)]],
      surname: ['', [Validators.required,Validators.minLength(6)]],
      phone: ['',[Validators.required]],
      address: ['',[Validators.required]],
      email: ['', [Validators.required, Validators.email]],
      username: ['', [Validators.required,Validators.minLength(3)]],
      password: ['', [Validators.minLength(8)]],
      checkpassword: ['', [Validators.required]]
    });
  }

  passwordValidator() {
    const passwordValue = this.registerForm.get('password')?.value;
    const checkpasswordValue = this.registerForm.get('checkpassword')?.value;

    return !(passwordValue === checkpasswordValue);
  }

  async ngOnInit() {    
  }

  async onSubmit(registerForm: AbstractControl) {
        
    let newUser = new User();
    newUser.id = 0;
    newUser.name = registerForm.get('name')?.value;
    newUser.surname = registerForm.get('surname')?.value;
    newUser.phone = registerForm.get('phone')?.value;
    newUser.address = registerForm.get('address')?.value;
    newUser.email = registerForm.get('email')?.value;
    newUser.username = registerForm.get('username')?.value;
    newUser.password = registerForm.get('password')?.value;
    newUser.rol = 'user';
    newUser.img = 'https://s3.amazonaws.com/csvweb/obituaries/photos/5582/438-photo.png';
    newUser.urlGwl = 'https://gwlvoices.com/portfolio/';

    console.log(newUser);

    let response = await this.userService.addNewUser(newUser);
    console.log(response);

    if (response != null) {

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
        title: 'Registration successful',
      });
    };

      registerForm.reset();
      setTimeout(() => {
        this.router.navigate(['/login'])
      }, 2000);
        
  }

  
  checkControl(controlName: string, errorName: string): boolean {
    if (this.registerForm.get(controlName)?.hasError(errorName)
        && this.registerForm.get(controlName)?.touched) {
      return true;
    } else {
      return false;
    }
  }
}
