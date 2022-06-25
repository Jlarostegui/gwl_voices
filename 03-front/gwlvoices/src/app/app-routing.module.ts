import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TestWGComponent } from './components/test-wg/test-wg.component';
import { IndexComponent } from './components/index/index.component';
import { RegisterComponent } from './components/register/register.component';
import { UserDetailComponent } from './components/user-detail/user-detail.component';
import { UserListComponent } from './components/user-list/user-list.component';
import { AuthorizationGuard } from './guards/authorization.guard'

const routes: Routes = [
  { path: '', pathMatch: 'full', redirectTo: '/login' },
  { path: 'login', component: IndexComponent },
  { path: 'users', component: UserListComponent, canActivate: [AuthorizationGuard] },
  { path: 'wk', component: TestWGComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'detail/:iduser', component: UserDetailComponent },
  { path: '**', redirectTo: '/login' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
