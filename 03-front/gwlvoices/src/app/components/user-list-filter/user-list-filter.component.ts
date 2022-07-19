import { Component, Input, OnInit } from '@angular/core';
import { User } from 'src/app/models/user_model';

@Component({
  selector: 'app-user-list-filter',
  templateUrl: './user-list-filter.component.html',
  styleUrls: ['./user-list-filter.component.scss']
})
export class UserListFilterComponent implements OnInit {

  @Input('users') users: User[] | undefined;



  constructor() {

  }

  ngOnInit(): void {

  }

}
