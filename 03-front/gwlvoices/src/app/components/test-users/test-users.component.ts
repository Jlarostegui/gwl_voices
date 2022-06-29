import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/services/user.service';
import { User } from 'src/app/models/user_model';
import { MatIconRegistry } from "@angular/material/icon";
import { DomSanitizer } from "@angular/platform-browser";
import { NULL_EXPR } from '@angular/compiler/src/output/output_ast';



@Component({
  selector: 'app-test-users',
  templateUrl: './test-users.component.html',
  styleUrls: ['./test-users.component.scss']
})
export class TestUsersComponent implements OnInit {

  ArrUsers: User[];
  user: User;
  imgroute: string = "../../../assets/img/";

  constructor(
    private userService: UserService,
    private matIconRegistry: MatIconRegistry,
    private domSanitizer: DomSanitizer
  ) {
    {
      this.ArrUsers = new Array();
      this.user = new User();
      this.matIconRegistry.addSvgIcon(
        "musicon",
        this.domSanitizer.bypassSecurityTrustResourceUrl("https://cdn.icon-icons.com/icons2/208/PNG/256/woman256_24802.png")
      );
    }

  }

  async ngOnInit() {

    try {

      // let response = await this.userService.getAllUsers();


      // this.user = await this.userService.getUserById(3);

      //  let response = await this.userService.getUserByName("Ana");

      // response.forEach(x => this.ArrUsers.push(new User({
      //   id: x['id'],
      //   name: x['name'],
      //   email: x['email'],
      //   password: x['password'],
      //   rol: x['rol'],
      //   surname: x['surname'],
      //   img: x['img'],
      //   phone: x['phone'],

      // })));


      console.log(this.ArrUsers, "test");

    } catch (error) {
      console.log(error);
    }

  }
}
