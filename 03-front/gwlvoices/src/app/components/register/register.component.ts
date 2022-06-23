import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { UserService } from 'src/app/services/user.service';
import { User } from 'src/app/models/user_model';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {

  user: User;
  registerForm: FormGroup;


  constructor(
    private userService: UserService,
    private formBuilder: FormBuilder
  ) {
    this.user = new User();
    this.registerForm = this.formBuilder.group({
      username: ['', Validators.required],
      password: ['', Validators.required, Validators.maxLength(6)],
      name: ['', Validators.required],
      surname: ['', Validators.required],
      email: ['', Validators.required],
      img: ['', Validators.required],
      phone: ['', Validators.required],
      address: ['', Validators.required],
      urlGWL: ['', Validators.required],
    });

  }

  async ngOnInit() {
    

    
  }

  onSubmit(registerForm: AbstractControl) {
    
    console.log(registerForm.value);
  }
}
