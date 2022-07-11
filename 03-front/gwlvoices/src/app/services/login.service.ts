import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ROOT_URL_ACCESS } from 'src/environments/config';
import { User } from '../models/user_model';


@Injectable({
  providedIn: 'root'
})
export class LoginService {

  isAdmin: boolean;

  constructor(private http: HttpClient) {
   this.isAdmin = false; 
   }


  login(loginForm: User): Observable<User> {
    let response = this.http.post<User>(ROOT_URL_ACCESS, loginForm);
    response.forEach(item => console.log(item));

    response.subscribe(item => { this.isAdmin = (item.rol=="admin") });

    return response;
  }

  forgotPassword(mail: string): void {
    this.http.put<string>(ROOT_URL_ACCESS, mail)
  }
}
