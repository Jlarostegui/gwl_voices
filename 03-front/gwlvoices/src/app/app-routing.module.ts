import { Component, NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TestWGComponent } from './components/test-wg/test-wg.component';
import { TestUsersComponent } from './components/test-users/test-users.component';
import { IndexComponent } from './components/index/index.component';

const routes: Routes = [
  { path: '', pathMatch: 'full', redirectTo: '/login' },
  { path: 'login', component: IndexComponent },
  { path: 'user', component: TestUsersComponent },
  { path: 'wk', component: TestWGComponent },
  { path: '**', redirectTo: '/login' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
