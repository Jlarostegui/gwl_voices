import { Component, Input, OnInit } from '@angular/core';
import { MatTabChangeEvent } from '@angular/material/tabs';
import { Router } from '@angular/router';
import { User } from 'src/app/models/user_model';
import { UserService } from 'src/app/services/user.service';
import Swal from 'sweetalert2';


@Component({
  selector: 'app-admin-panel',
  templateUrl: './admin-panel.component.html',
  styleUrls: ['./admin-panel.component.scss']
})
export class AdminPanelComponent implements OnInit {

  dataSource: User[] = [];
  edit: boolean = true;
  rol: string | null = sessionStorage.getItem('rol')
  isAdmin: boolean = false;

  constructor(
    private userService: UserService,
    private router: Router,
  ) { }

  async ngOnInit() {
    if (this.rol === 'admin') {
      this.isAdmin = true
    }
    let response = await this.userService.getAllUsers(0);
    if (response.results != null) {
      this.dataSource = response.results.map(x => new User({ ...x, edit: false }));
    }
  }


  async actualTab(tabChangeEvent: MatTabChangeEvent) {
    let index = tabChangeEvent.index
    if (index === 5) {
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



}
