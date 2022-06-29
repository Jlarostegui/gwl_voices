import { Component, OnInit } from '@angular/core';
import { User } from 'src/app/models/user_model';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-admin-panel',
  templateUrl: './admin-panel.component.html',
  styleUrls: ['./admin-panel.component.scss']
})
export class AdminPanelComponent implements OnInit {

  listUsers: User[] = new Array();

  constructor(
    private userService: UserService
  ) { }

  async ngOnInit() {

    let response = await this.userService.getAllUsers();
    response.forEach(x => this.listUsers.push(new User({
      id: x['id'],
      name: x['name'],
      email: x['email'],
      password: x['password'],
      rol: x['rol'],
      surname: x['surname'],
      img: x['img'],
      phone: x['phone'],
    })));

    console.log(this.listUsers);

  }




}
