import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/services/user.service';
import {User} from 'src/app/models/user_model';



@Component({
  selector: 'app-test-users',
  templateUrl: './test-users.component.html',
  styleUrls: ['./test-users.component.scss']
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
      
    }
}
