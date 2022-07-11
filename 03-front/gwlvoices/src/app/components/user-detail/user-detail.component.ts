import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/services/user.service';
import { LoginService } from 'src/app/services/login.service';
import { User } from 'src/app/models/user_model';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-user-detail',
  templateUrl: './user-detail.component.html',
  styleUrls: ['./user-detail.component.scss']
})
export class UserDetailComponent implements OnInit {

  user: User | undefined;
  isAdmin: boolean;

  constructor(
    private userService: UserService,
    private loginService: LoginService,
    private activatedRoute: ActivatedRoute,
  ) {
    this.isAdmin = loginService.isAdmin;
   }

  ngOnInit() {

    try {

      this.activatedRoute.params.subscribe(async params => {
        let id = parseInt(params['iduser']);
        this.user = await this.userService.getUserById(id);


      })


    } catch (error) {
      console.log(error);

    }

  }

}
