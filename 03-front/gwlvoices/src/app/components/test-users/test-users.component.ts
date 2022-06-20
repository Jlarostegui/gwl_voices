import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/services/user.service';
import { User } from 'src/app/models/user_model';
import { MatIconRegistry } from "@angular/material/icon";
import  {DomSanitizer}  from "@angular/platform-browser";



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
    private matIconRegistry: MatIconRegistry,
    private domSanitizer: DomSanitizer
   ) {
     {
      this.ArrUsers = new Array();
      this.user = new Array();
      this.matIconRegistry.addSvgIcon(
      "musicon",
      this.domSanitizer.bypassSecurityTrustResourceUrl("https://cdn.icon-icons.com/icons2/208/PNG/256/woman256_24802.png")
    );
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
          Img: x['img'],
         Phone: x['phone'],
      
       })));


      console.log(this.ArrUsers);

    } catch (error) {
      console.log(error);
    }

  }
}
