import { Component, Input, OnInit } from '@angular/core';
import { User } from 'src/app/models/user_model';
import { LoginService } from 'src/app/services/login.service';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-table-users',
  styleUrls: ['./table-users.component.scss'],
  templateUrl: './table-users.component.html',
})



export class TableUsersComponent implements OnInit {


  dataSource: User[] = [];
  displayedColumns: string[] = ['img', 'name', 'surname', 'username', 'actions'];
  edit: boolean = false;


  constructor(
    private userService: UserService,
  ) { }
  async ngOnInit() {

    let response = await this.userService.getAllUsers(0);
    if (response.results != null) {
      response.results.forEach(x => this.listUsers.push(new User({
        id: x['id'],
        name: x['name'],
        email: x['email'],
        password: x['password'],
        rol: x['rol'],
        surname: x['surname'],
        img: x['img'],
        phone: x['phone'],
    
      })));
    }
    let response = await this.userService.getAllUsers();
    this.dataSource = response.map(x => new User({ ...x, edit: 'false' }));

  }



  editUser(event: User) {
    this.edit = !this.edit
    let UserUpdated = new User(event)
    UserUpdated.edit = true
    this.dataSource.map(x => {
      x.id == UserUpdated.id ? x.edit = false : x.edit = true
    })
    console.log(this.dataSource);


  };

  saveUser(event: User) {
    console.log(event);


  }

  // onSubmit(updatedUser: AbstractControl) {

  //   console.log(updatedUser.value);

  // }
}
