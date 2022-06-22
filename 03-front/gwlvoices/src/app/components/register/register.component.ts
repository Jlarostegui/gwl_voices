import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { UserService } from 'src/app/services/user.service';
import { User } from 'src/app/models/user_model';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {

  user: User[];
  formRegister = this.formBuilder.group({
    username: [''],
    password: ['', Validators.required, Validators.minLength(8)],
    rol: ['', Validators.required],
    name: ['', Validators.required],
    surname: ['', Validators.required],
    email: ['', Validators.required],
    img: ['', Validators.required],
    phone: ['', Validators.required],
    address: ['', Validators.required],
    urlGWL: ['', Validators.required]
  })


  constructor(
    private userService: UserService,
    private formBuilder: FormBuilder
  ) {
    this.user = new Array()
   
   }

   async ngOnInit() {

    // try {


    //   let response = await this.userService.addNewUser(user);

     

    //   response.forEach(x => this.user.push(new User({
    //     Id: x['id'],
    //     Name: x['name'],
    //     Email: x['email'],
    //     Password: x['password'],
    //     Rol: x['rol'],
    //     Surname: x['surname'],
    //     Img: x['img'],
    //     Phone: x['phone'],

    //   })));


    //   console.log(this.user, "formulario");

    // } catch (error) {
    //   console.log(error);
    // }

  }

}
