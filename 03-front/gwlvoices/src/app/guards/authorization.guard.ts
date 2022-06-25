import { Token } from '@angular/compiler';
import { tokenize } from '@angular/compiler/src/ml_parser/lexer';
import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { LoginService } from '../services/login.service';

@Injectable({
  providedIn: 'root'
})
export class AuthorizationGuard implements CanActivate {

  token = sessionStorage.getItem('token')

  constructor(
    private logiservice: LoginService,
    private router: Router) { }

  canActivate(): boolean {

    if (this.token) {
      let result = this.logiservice.verifyToken()
    }
    return true

  }

}
