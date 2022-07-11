import { Component, OnInit } from '@angular/core';
import { User } from 'src/app/models/user_model';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-table-users',
  styleUrls: ['./table-users.component.scss'],
  templateUrl: './table-users.component.html',
})



export class TableUsersComponent implements OnInit {


  dataSource: User[] = [];
  displayedColumns: string[] = ['img', 'name', 'surname', 'password', 'phone', 'username', 'rol', 'email', 'actions'];
  readonly: string = 'readonly';
  actualPage: number = 1;
  totalPages: number = 0;


  constructor(
    private userService: UserService,

  ) { }

  ngOnInit() {
    this.getUsers(this.actualPage);

  }

  async getUsers(page: number) {
    let response = await this.userService.getAllUsers(page);
    if (response.results != null) {
      this.dataSource = response.results.map(x => new User({ ...x, edit: true }));
    }
    this.totalPages = (response.total != null) ? Math.ceil(response.total / 8) : 10;
    console.log(this.totalPages);

  }

  netxPage() {
    if (this.actualPage > 0 && this.actualPage < this.totalPages) {
      this.actualPage++
      this.getUsers(this.actualPage)
    } else if (this.actualPage >= this.totalPages - 1) {
      this.actualPage = 1
      this.getUsers(this.actualPage)
    }
  }

  beforePage() {
    if (this.actualPage > 1 && this.actualPage <= this.totalPages) {
      this.actualPage--
      this.getUsers(this.actualPage)
    } else if (this.actualPage >= this.totalPages) {
      this.actualPage = 1
      this.getUsers(this.actualPage)
    }
  }

  editUser(event: User) {
    let userUpdated = new User(event)
    this.dataSource.map(x => {
      if (x.id === userUpdated.id) {
        x.edit = !x.edit
      }
    });
  };

  saveUser(event: User) {
    let userUpdated = new User(event)
    console.log(userUpdated);

    this.dataSource.map(x => {
      if (x.id === userUpdated.id) {
        x.edit = !x.edit
      }
    });
  };
}
