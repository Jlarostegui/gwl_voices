import { HttpClient } from '@angular/common/http';
import { JSDocComment, Token } from '@angular/compiler';
import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { ROOT_URL_ACCESS } from 'src/environments/config';
import { User } from '../models/user_model';


@Injectable({
  providedIn: 'root'
})
export class LoginService {

  constructor(private httpClient: HttpClient) { }


  // login(loginForm: User): User {
  //   let request = this.httpClient.post<User>(ROOT_URL_ACCESS, loginForm)
  //   let response;
  //   request.subscribe(resp => {








  //     console.log(response);

  //   })
  //   return response;
  // }








}
