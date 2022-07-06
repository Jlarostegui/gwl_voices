import { Component, OnInit } from '@angular/core';
import { User } from 'src/app/models/user_model';
import { UserService } from 'src/app/services/user.service';
import { AbstractControl, FormBuilder, FormControl, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-table-users',
  styleUrls: ['./table-users.component.scss'],
  templateUrl: './table-users.component.html',
})
export class TableUsersComponent implements OnInit {

  panelOpenState = false;
  listUsers: User[] = new Array();
  checked: boolean = true;
  updatedUser: FormGroup;
  id: string = '';

  constructor(
    private userService: UserService,
    private fctrl: FormBuilder,
  ) {
    this.updatedUser = this.fctrl.group(
      {
        id: [''],
        name: [''],
        surname: [''],
        phone: [''],
        address: [''],
        email: [''],
        username: [''],
        password: [''],
        rol: ['',]
      });
  }

  async ngOnInit() {

    let response = await this.userService.getAllUsers();
    response.forEach(x => this.listUsers.push(new User(x)));



  }

  onSubmit(updatedUser: AbstractControl) {

    console.log(updatedUser.value);

  }
}
