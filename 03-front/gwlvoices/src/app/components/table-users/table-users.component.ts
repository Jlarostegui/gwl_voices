import { Component, Input, OnInit } from '@angular/core';
import { User } from 'src/app/models/user_model';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-table-users',
  templateUrl: './table-users.component.html',
  styleUrls: ['./table-users.component.scss']
})
export class TableUsersComponent implements OnInit {

  listUsers = new Array();

  constructor(
    private userService: UserService
  ) {

  }

  async ngOnInit() {

    let response = await this.userService.getAllUsers();
    response.forEach(x => this.listUsers.push(new User({
      id: x['id'],
      name: x['name'],
      email: x['email'],
      rol: x['rol'],
      surname: x['surname'],
      img: x['img'],
      phone: x['phone'],
      username: x['username']
    })));

    this.listUsers.forEach(x => console.log(x)
    )


  }



}
