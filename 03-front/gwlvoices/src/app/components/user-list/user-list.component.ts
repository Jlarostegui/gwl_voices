import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/services/user.service';
import { User } from 'src/app/models/user_model';
import { ActivatedRoute, Router } from '@angular/router';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.scss']
})
export class UserListComponent implements OnInit {

  ArrPagesButtons: any[] = new Array();
  ArrUsers: User[];


  constructor(private userService: UserService,
    private activatedRoute: ActivatedRoute,
    private router: Router) {
    this.ArrUsers = new Array();
  }

  async ngOnInit() {
    try {

      this.activatedRoute.params.subscribe(async params => {
        let numpag = parseInt('0' + params['numpag']);
        numpag = (numpag > 0) ? numpag : 1;
        let response = await this.userService.getAllUsers(numpag);

        this.ArrUsers = new Array();
        if (response != null) {

          let pages = (response.total != null) ? Math.ceil(response.total / 8) : 1;          
          this.ArrPagesButtons = new Array(pages);

          if (response.results != null) {
            response.results.forEach(x => this.ArrUsers.push(new User({
              id: x['id'],
              name: x['name'],
              email: x['email'],
              password: x['password'],
              rol: x['rol'],
              surname: x['surname'],
              img: x['img'],
              phone: x['phone'],
              workingGroups: x['workingGroups'],

            })));
          }
        }
      })

      console.log(this.ArrUsers, "test");

    } catch (error) {
      console.log(error);
    }

  }

  async onClickLogout() {
    const result = await Swal.fire({
      title: 'Logout',
      text: 'Are you sure you want to logout?',
      icon: 'question',
      showCancelButton: true,
      confirmButtonText: 'Exit'
    });

    if (result.isConfirmed) {
      sessionStorage.removeItem('token');
      this.router.navigate(['/login']);
    }

  }
}


