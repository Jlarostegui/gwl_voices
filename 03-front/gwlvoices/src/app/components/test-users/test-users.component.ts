import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/services/user.service';
<<<<<<< HEAD
import { User } from 'src/app/models/user_model';
=======
import {User} from 'src/app/models/user_model';
>>>>>>> 0f32e2dade72e94dd6fb68d35f7b059ad60512cc



@Component({
  selector: 'app-test-users',
  templateUrl: './test-users.component.html',
  styleUrls: ['./test-users.component.css']
})
export class TestUsersComponent implements OnInit {

  ArrUsers: User[];
  user: User[];

  constructor(
    private userService: UserService,
  ) {
    {
      this.ArrUsers = new Array();
      this.user = new Array();
<<<<<<< HEAD
=======
     }

   }

   async ngOnInit() {
      
     try {
       
       let response = await this.userService.getAllUsers();

      //  let response = await this.userService.getUserById(3);

      //  let response = await this.userService.getUserByName("Ana");

       response.forEach(x => this.ArrUsers.push(new User({
         Id: x['id'],
         Name: x['name'],
         Email: x['email'],
         Password: x['password'],
         Rol: x['rol'],
         Surname: x['surname'],
      
       })));

       
       console.log(this.ArrUsers);

     } catch (error) {
       console.log(error);
     }
      
>>>>>>> 0f32e2dade72e94dd6fb68d35f7b059ad60512cc
    }

  }

  async ngOnInit() {

    try {

      let response = await this.userService.getUserById(3);
      console.log(response);

    } catch (error) {
      console.log(error);
    }

  }
}
