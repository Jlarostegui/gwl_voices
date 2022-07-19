import { AfterContentInit, AfterViewInit, Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { MatTabChangeEvent } from '@angular/material/tabs';
import { Router } from '@angular/router';
import { tbiUserWg } from 'src/app/models/tbI_wg_model';
import { User } from 'src/app/models/user_model';
import { Working_groups } from 'src/app/models/working_groups.model';
import { UserService } from 'src/app/services/user.service';
import { WgService } from 'src/app/services/wg.service';
import { UserListFilterComponent } from '../user-list-filter/user-list-filter.component';

@Component({
  selector: 'app-tabe-working-groups',
  templateUrl: './tabe-working-groups.component.html',
  styleUrls: ['./tabe-working-groups.component.scss']
})
export class TabeWorkingGroupsComponent implements OnInit {


  @ViewChild(UserListFilterComponent, { static: false }) ul!: UserListFilterComponent
  showChild: boolean = true;

  rol: string | null = sessionStorage.getItem('rol')
  isAdmin: boolean = false;
  list: Working_groups[] = [];
  arrUsers: User[] = [];
  allUsers: User[] = [];
  userID?: number = 0;
  wkgrID?: number = 0;



  constructor(
    private wgservices: WgService,
    private userService: UserService,
    private router: Router,
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
    this.wkgrID = this.list[tabChangeEvent.index].id;
    let users = await this.wgservices.getUsersOfWg(this.wkgrID);
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

  async addUser() {
    let userToWg = new tbiUserWg();
    userToWg.userId = this.userID;
    userToWg.workingGrId = this.wkgrID
    await this.wgservices.addUserToWorkingGroup(userToWg)
    let user = await this.userService.getUserById(this.userID = 0)
    this.arrUsers.push(user)
  }

  async deleteUser() {

  }

}


