import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, Observable, throwError } from 'rxjs';
import { Router } from '@angular/router';
import Swal from 'sweetalert2';

@Injectable({
  providedIn: 'root'
})
export class AuthService implements HttpInterceptor {

  constructor(
    private router: Router
  ) { }

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

    const token: string | null = sessionStorage.getItem('token');

    let request = req;

    if (token) {
      request = req.clone({
        setHeaders: {
          authorization: `${token}`
        }
      });
    }

    return next.handle(request).pipe(
      catchError((err: HttpErrorResponse) => {

        if (err.status === 401) {
          const alert = Swal.mixin({
            // toast: false,
            showConfirmButton: false,
            timer: 1500,
            timerProgressBar: true,
            didOpen: (alert) => {
              alert.addEventListener('mouseenter', Swal.stopTimer)
              alert.addEventListener('mouseleave', Swal.resumeTimer)
            }

          });

          alert.fire({
            icon: 'error',
            title: 'User or password incorrect',
          })

          this.router.navigateByUrl('/login');
        }

        return throwError(() => console.log()
        );

      })
    );


  }

}




