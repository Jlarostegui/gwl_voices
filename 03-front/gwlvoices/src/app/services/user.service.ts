import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ROOT_URL_US } from '../../environments/config';
import { User } from '../models'
import { lastValueFrom } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private httpClient: HttpClient) { }


  // OK => Devuelve un Objeto 
  getUserById(pId: number): Promise<User> {
    let result = lastValueFrom(this.httpClient.get<User>(`${ROOT_URL_US}/${pId}`))
    console.log(result);
    return result
  }


  getUserByName(pName: string): Promise<User> {
    let result = lastValueFrom(this.httpClient.get<User>(`${ROOT_URL_US}/${pName}`))
    console.log(result)
    return result;
  }

<<<<<<< HEAD
  getUserByName(pName: string): Promise<User> {
    let result = lastValueFrom(this.httpClient.get<User>(`${ROOT_URL_US}/${pName}`))
    console.log(result)
    return result;
  }

=======
>>>>>>> 0f32e2dade72e94dd6fb68d35f7b059ad60512cc
  getAllUsers(): Promise<any[]> {
    let result = lastValueFrom(this.httpClient.get<any[]>(`${ROOT_URL_US}/all`))
    console.log(result);
    return result;
<<<<<<< HEAD
  }
=======
   }
>>>>>>> 0f32e2dade72e94dd6fb68d35f7b059ad60512cc


  addNewUser(newUser: User): Promise<User> {
    let result = lastValueFrom(this.httpClient.post<User>(ROOT_URL_US, newUser))
    console.log(result)
    return result;
  }

  updateUser(updatedUser: User): Promise<User> {
    let result = lastValueFrom(this.httpClient.put<User>(ROOT_URL_US, updatedUser))
    console.log(result)
    return result;
  }

  deleteUser(pId: number): Promise<User> {
    let result = lastValueFrom(this.httpClient.delete<User>(`${ROOT_URL_US}/${pId}`))
    console.log(result);
    return result;
  }



}
