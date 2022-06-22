import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable, retryWhen } from 'rxjs';
import { ROOT_URL_ACCESS } from 'src/environments/config';
import { User } from '../models/user_model';


@Injectable({
  providedIn: 'root'
})
export class LoginService {

  constructor(private httpClient: HttpClient) { }


  login(loginForm: User): User {
    let user: User = new User();
    let request = this.httpClient.post<User>(ROOT_URL_ACCESS, loginForm).subscribe(data => {
      debugger;
      console.log(data);

    })



    return user
    // request.subscribe(resp => {
    //   console.log(response);
    // })
  }










}
