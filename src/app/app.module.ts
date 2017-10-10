import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations'
import { NgModule } from '@angular/core';
import { ToastModule } from 'ng2-toastr/ng2-toastr'

import { routing } from './app.routing';
import { Session } from '../session/session';

import { AppComponent } from './app.component';
import { DialogComponent } from '../dialog/dialog.component';
import { LoginComponent } from './login/login.component';
import { HomeComponent } from './home/home.component';

import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';

import {
  ReactiveFormsModule,
  FormGroup,
  FormControl,
  Validators,
  FormBuilder
} from '@angular/forms';

@NgModule({
  declarations: [
    AppComponent,
    DialogComponent,
    LoginComponent,
    HomeComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule,
    BrowserAnimationsModule,
    ReactiveFormsModule,
    routing,
    ToastModule.forRoot()
  ],
  providers: [
    Session
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
