import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ROOT_URL_ATTACHMENTS } from 'src/environments/config';


@Injectable({
  providedIn: 'root'
})
export class FilesService {

  constructor(
    private http: HttpClient
  ) { }

  upload(file: any): Observable<any> {
    return this.http.post<any>(ROOT_URL_ATTACHMENTS, file);
  }




}

