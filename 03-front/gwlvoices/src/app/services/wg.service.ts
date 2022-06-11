import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Working_groups } from '../models/working_groups.model';
import { lastValueFrom } from 'rxjs';
import { ROOT_URL_WK } from '../models/config';

@Injectable({
  providedIn: 'root'
})
export class WgService {

  constructor(private httpClient: HttpClient) { }

  // OK => Devuelve un Array de Objetos {id:"", name:"", error:""}
  getAllWorkingGroups(): Promise<any[]> {
    let result = lastValueFrom(this.httpClient.get<any[]>(ROOT_URL_WK))
    return result
  };

  // OK => Devuelve un Object
  getWorkingGroupById(pId: number): Promise<Working_groups> {
    let response = lastValueFrom(this.httpClient.get<any>(`${ROOT_URL_WK}/${pId}`));
    return response
  }

  // OK => Inserta wg y devuelve su Name
  addWorkingNewWorkingGroup(pWg: Working_groups): Promise<Working_groups> {
    const httpOptions = {
      headers: new HttpHeaders(
        {
          'Content-type': 'application/json; charset=UTF-8'
        })

    }
    let response = lastValueFrom(this.httpClient.post<Working_groups>(`${ROOT_URL_WK}`, pWg, httpOptions));
    return response

  }

  // ok =>  Modifica wg y devuelve su Name
  updateWorkingNewWorkingGroup(pWg: Working_groups): Promise<Working_groups> {

    let response = lastValueFrom(this.httpClient.put<Working_groups>(`${ROOT_URL_WK}`, pWg));
    return response
  }

  // ok => Elimina el wg .
  deleteWorkingGroup(pId: number): Promise<any> {
    let response = lastValueFrom(this.httpClient.delete<any>(`${ROOT_URL_WK}/${pId}`));
    return response
  }
}
