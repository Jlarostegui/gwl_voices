import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable, retryWhen } from 'rxjs';
import { ROOT_URL_ACCESS } from 'src/environments/config';
import { User } from '../models/user_model';


@Injectable({
  providedIn: 'root'
})
export class LoginService {

  constructor(private http: HttpClient) { }


  login(loginForm: User): User {

    let response = this.http.post<User>(ROOT_URL_ACCESS, loginForm)
    let a: User = new User();
    return a

    // let user: User = new User();
    // let request = this.httpClient.post<User>(ROOT_URL_ACCESS, loginForm).subscribe((data: User) => {


    // })

    // console.log(user);




    // return user


    // request.subscribe(resp => {
    //   console.log(response);
    // })
  }










}
