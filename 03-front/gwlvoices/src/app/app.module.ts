import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';


import { AuthService } from './services/auth.service';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { TestWGComponent } from './components/test-wg/test-wg.component';
import { TestUsersComponent } from './components/test-users/test-users.component';
import { IndexComponent } from './components/index/index.component';
import { ForgotPasswordComponent } from './components/forgot-password/forgot-password.component';
import { AdminPanelComponent } from './components/admin-panel/admin-panel.component';
import { UserCardComponent } from './components/user-card/user-card.component';
import { UserDetailComponent } from './components/user-detail/user-detail.component';
import { UserListComponent } from './components/user-list/user-list.component';
import { TableUsersComponent } from './components/table-users/table-users.component';

import { MatFormFieldModule } from '@angular/material/form-field';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatCardModule } from '@angular/material/card';
import { MatGridListModule } from '@angular/material/grid-list';
import { RegisterComponent } from './components/register/register.component';
import { MatSelectModule } from '@angular/material/select';
import { MatTabsModule } from '@angular/material/tabs';
import { MatTableModule } from '@angular/material/table';



@NgModule({
  declarations: [
    AppComponent,
    TestWGComponent,
    TestUsersComponent,
    IndexComponent,
    RegisterComponent,
    UserCardComponent,
    UserDetailComponent,
    UserListComponent,
    ForgotPasswordComponent,
    AdminPanelComponent,
    TableUsersComponent,

  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
    CommonModule,
    FormsModule,
    BrowserAnimationsModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatIconModule,
    MatCardModule,
    MatGridListModule,
    MatSelectModule,
    MatTabsModule,
    MatTableModule,
  ],
  providers: [{
    provide: HTTP_INTERCEPTORS,
    useClass: AuthService,
    multi: true
  }],
  bootstrap: [AppComponent]
})
export class AppModule { }
