import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { TestWGComponent } from './components/test-wg/test-wg.component';
import { CommonModule } from '@angular/common';
import { TestUsersComponent } from './components/test-users/test-users.component';
// import { IndexComponent } from './components/index/index.component';

@NgModule({
  declarations: [
    AppComponent,
    TestWGComponent,
   TestUsersComponent

  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
    CommonModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
