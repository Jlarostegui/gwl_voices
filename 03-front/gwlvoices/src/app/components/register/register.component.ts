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
    /*this.registerForm = this.formBuilder.group({
      username: ['', Validators.required],
      password: ['', Validators.required, Validators.maxLength(6)],
      name: ['', Validators.required],
      surname: ['', Validators.required],
      email: ['', Validators.required],
      phone: ['', Validators.required],
      address: ['', Validators.required],
    });*/

    this.registerForm = this.formBuilder.group({
      name: ['', 
        [Validators.required,
        Validators.minLength(3)]
      ],
      surname: ['', 
        [Validators.required,
        Validators.minLength(6)]
      ],
      phone: ['',[Validators.required]],
      address: ['',[Validators.required]],
      email: ['', 
        [Validators.required,
        Validators.pattern(/^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$/)]
      ],
      username: ['',
        [Validators.required,
        Validators.minLength(3)]
      ],
      password: ['', [Validators.minLength(8)]],
      repitepassword: ['', this.passwordValidador.bind(this)]
    });
  }


  passwordValidador(form: AbstractControl) {

    const passwordValue = form.get('password')?.value;
    const repitepasswordValue = form.get('repitepassword')?.value;

    if (passwordValue === repitepasswordValue) {
      return Promise.resolve(null);
    }else {
      return { passwordvalidador: true }
    }
  }

  async ngOnInit() {    
  }

  onSubmit(registerForm: AbstractControl) {
    
    console.log(registerForm.value);
  }

  
  checkControl(controlName: string, errorName: string): boolean {
    if (this.registerForm.get(controlName)?.hasError(errorName) && this.registerForm.get(controlName)?.touched) {
      return true;
    } else {
      return false;
    }

  }
}
