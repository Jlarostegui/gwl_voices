import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-index',
  templateUrl: './index.component.html',
  styleUrls: ['./index.component.css']
})
export class IndexComponent implements OnInit {



  constructor(
    private userservice: UserService
  ) {

  }

  async ngOnInit() {



  }

  // async getLoginData(pLogin: any) {
  //   console.log(pLogin.value)
  //   const response = await this.userservice.getUserByName(pLogin.value)
  //   console.log(response);
  // }




}
