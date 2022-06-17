import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TestWGComponent } from './components/test-wg/test-wg.component';
import { TestUsersComponent } from './components/test-users/test-users.component';
import { IndexComponent } from './components/index/index.component';

const routes: Routes = [
  { path: '', pathMatch: 'full', redirectTo: '/index' },
<<<<<<< HEAD
  { path: 'index', component: IndexComponent },
=======
  { path: 'index', component: TestUsersComponent },
>>>>>>> 0f32e2dade72e94dd6fb68d35f7b059ad60512cc
  { path: '**', redirectTo: '/index' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
