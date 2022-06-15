import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
// import { IndexComponent } from './components/index/index.component';
import { TestWGComponent } from './components/test-wg/test-wg.component';
import { TestUsersComponent } from './components/test-users/test-users.component';

const routes: Routes = [
  { path: '', pathMatch: 'full', redirectTo: '/index' },
  { path: 'index', component: TestWGComponent },
  { path: '**', redirectTo: '/index' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
