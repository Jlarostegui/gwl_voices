import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ROOT_URL_ACCESS } from 'src/environments/config';
import { User } from '../models/user_model';


@Injectable({
  providedIn: 'root'
})
export class LoginService {

  constructor(private httpClient: HttpClient) { }


  login(loginForm: User): void {

    let data = this.httpClient.post<any>(ROOT_URL_ACCESS, loginForm)
    console.log(data.subscribe(data => { token: data }));
  }








}
