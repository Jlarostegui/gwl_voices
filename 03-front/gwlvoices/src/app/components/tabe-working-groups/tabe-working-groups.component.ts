import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormControl } from '@angular/forms';
import { MatTabChangeEvent } from '@angular/material/tabs';
import { User } from 'src/app/models/user_model';
import { Working_groups } from 'src/app/models/working_groups.model';
import { LoginService } from 'src/app/services/login.service';
import { UserService } from 'src/app/services/user.service';
import { WgService } from 'src/app/services/wg.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-tabe-working-groups',
  templateUrl: './tabe-working-groups.component.html',
  styleUrls: ['./tabe-working-groups.component.scss']
})
export class TabeWorkingGroupsComponent implements OnInit {
  rol: string | null = sessionStorage.getItem('rol')
  isAdmin: boolean = false;
  list: Working_groups[] = [];
  arrUsers: User[] = [];
  allUsers: User[] = [];
  userID: number = 0




  constructor(
    private wgservices: WgService,
    private userService: UserService,
  ) {
    if (this.rol === 'admin') {
      this.isAdmin = true
    }



  }

  async ngOnInit() {
    let response = await this.wgservices.getAllWorkingGroups();
    response.forEach(wk => this.list.push(wk));
  }


  async actualTab(tabChangeEvent: MatTabChangeEvent) {
    let id = this.list[tabChangeEvent.index].id;
    let users = await this.wgservices.getUsersOfWg(id);
    users.forEach(async (x: number) => {
      let user = await this.userService.getUserById(x)
      this.arrUsers.push(user)
    })
    this.arrUsers = [];

    let response = await this.userService.getAllUsers(0);
    if (response.results != null) {
      this.allUsers = response.results.map(x => new User(x));
    }

  }

  addUser() {


  }

}


