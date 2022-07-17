import { Component, OnInit } from '@angular/core';
import { MatTabChangeEvent } from '@angular/material/tabs';
import { User } from 'src/app/models/user_model';
import { Working_groups } from 'src/app/models/working_groups.model';
import { UserService } from 'src/app/services/user.service';
import { WgService } from 'src/app/services/wg.service';

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
  }



}


