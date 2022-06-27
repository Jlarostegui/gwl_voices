import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ROOT_URL_ACCESS } from 'src/environments/config';
import { User } from '../models/user_model';


@Injectable({
  providedIn: 'root'
})
export class LoginService {

  constructor(private http: HttpClient) { }


  login(loginForm: User): Observable<User> {
    let response = this.http.post<User>(ROOT_URL_ACCESS, loginForm);
    response.forEach(item => console.log(item));

    return response;
  }

  // verifyToken(): void {
  //   this.http.get<any>(ROOT_URL_ACCESS).subscribe(resp => {
  //     console.log(resp);
  //   });
  // }
}
