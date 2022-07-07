import { Component, Input, OnInit } from '@angular/core';
import { User } from 'src/app/models/user_model';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-admin-panel',
  templateUrl: './admin-panel.component.html',
  styleUrls: ['./admin-panel.component.scss']
})
export class AdminPanelComponent implements OnInit {

  dataSource: User[] = new Array();
  edit: boolean = true;



  constructor(
    private userService: UserService,
  ) { }

  async ngOnInit() {
    let response = await this.userService.getAllUsers();
    response.forEach(x => this.dataSource.push(new User(x)));
  }

  editUser() {
    this.edit = !this.edit
  };

  saveUser() {
    console.log('click');

  }
}
