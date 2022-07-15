import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TestWGComponent } from './components/test-wg/test-wg.component';
import { IndexComponent } from './components/index/index.component';
import { RegisterComponent } from './components/register/register.component';
import { UserDetailComponent } from './components/user-detail/user-detail.component';
import { UserListComponent } from './components/user-list/user-list.component';
import { AuthorizationGuard } from './guards/authorization.guard'
import { ForgotPasswordComponent } from './components/forgot-password/forgot-password.component';
import { AdminPanelComponent } from './components/admin-panel/admin-panel.component';

const routes: Routes = [
  { path: '', pathMatch: 'full', redirectTo: '/login' },
  { path: 'login', component: IndexComponent },
  { path: 'forgot', component: ForgotPasswordComponent },
  { path: 'admin/:iduser', component: AdminPanelComponent, canActivate: [AuthorizationGuard], },
  { path: 'users', component: UserListComponent, canActivate: [AuthorizationGuard] },
  { path: 'users/:numpag', component: UserListComponent, canActivate: [AuthorizationGuard] },
  { path: 'wk', component: TestWGComponent, canActivate: [AuthorizationGuard] },
  { path: 'register', component: RegisterComponent, canActivate: [AuthorizationGuard] },
  { path: 'detail/:iduser', component: UserDetailComponent, canActivate: [AuthorizationGuard] },
  { path: '**', redirectTo: '/login' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
