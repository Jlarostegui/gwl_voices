import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';
import { FormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { TestWGComponent } from './components/test-wg/test-wg.component';
<<<<<<< HEAD
import { IndexComponent } from './components/index/index.component';
import { CommonModule } from '@angular/common';
=======
import { CommonModule } from '@angular/common';
import { TestUsersComponent } from './components/test-users/test-users.component';
// import { IndexComponent } from './components/index/index.component';
>>>>>>> 0f32e2dade72e94dd6fb68d35f7b059ad60512cc

@NgModule({
  declarations: [
    AppComponent,
    TestWGComponent,
<<<<<<< HEAD
    IndexComponent,
=======
   TestUsersComponent
>>>>>>> 0f32e2dade72e94dd6fb68d35f7b059ad60512cc

  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
<<<<<<< HEAD
    FormsModule,
=======
>>>>>>> 0f32e2dade72e94dd6fb68d35f7b059ad60512cc
    CommonModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
