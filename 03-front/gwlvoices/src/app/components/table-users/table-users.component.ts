import { Breakpoints } from '@angular/cdk/layout';
import { Component, Input, OnInit } from '@angular/core';
import { User } from 'src/app/models/user_model';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-table-users',
  styleUrls: ['./table-users.component.scss'],
  templateUrl: './table-users.component.html',
})



export class TableUsersComponent implements OnInit {


  dataSource: User[] = [];
  displayedColumns: string[] = ['img', 'name', 'surname', 'password', 'phone', 'username', 'address', 'rol', 'email', 'actions'];
  readonly: string = 'readonly';



  constructor(
    private userService: UserService,
  ) { }

  async ngOnInit() {
    let response = await this.userService.getAllUsers(0);
    if (response.results != null) {
      this.dataSource = response.results.map(x => new User({ ...x, edit: true }));
    }
    console.log(this.dataSource);
  }



  editUser(event: User) {


    // let UserUpdated = new User(event)
    // this.dataSource.map(x => {
    //   if (x.id === UserUpdated.id) {
    //     x.edit = !x.edit
    //   }
    // });
  };

  saveUser(event: User) {
    let UserUpdated = new User(event)
    this.dataSource.map(x => {
      if (x.id === UserUpdated.id) {
        x.edit = !x.edit
      }
    });
  };
}
