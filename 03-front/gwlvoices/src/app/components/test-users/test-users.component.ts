import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/services/user.service';
import {User} from 'src/app/models/User_model';



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
