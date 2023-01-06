import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';

import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';

import { routes } from './app.routing';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './auth/login/login.component';
import { PasswordRecoverComponent } from './auth/password-recover/password-recover.component';

import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatAutocompleteModule } from '@angular/material/autocomplete'
import { RegisterComponent } from './auth/register/register.component';
import { LoggedInGuard } from './logged-in.guard';
import { SignUpComponent } from './auth/sign-up/sign-up.component';
import { CurrentUserStorage } from './current-user-storage';
import { ChangePasswordComponent } from './auth/create-new-password/change-password.component'
import { AddPublicationComponent } from './home/publications/add-publication/add-publication.component';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatDialogModule } from '@angular/material/dialog'; 
import { MatRippleModule } from '@angular/material/core';
import { AddPublicationDialog } from './home/dialogs/add-publication/add-publication-type-dialog';
import {ScrollingModule} from '@angular/cdk/scrolling';
import { AddConferenceDialog } from './home/dialogs/add-conference/add-conference-dialog';
import { MatDatepickerModule }from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import { AddDigestDialog } from './home/dialogs/add-digest/add-digest-dialog';
import { AddAuthorDialog } from './home/dialogs/add-author/add-author-dialog';
import { ViewPublicationsComponent } from './home/publications/view-publications/view-publications';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    LoginComponent,
    PasswordRecoverComponent,
    RegisterComponent,
    SignUpComponent,
    ChangePasswordComponent,
    AddPublicationComponent,
    AddPublicationDialog,
    AddConferenceDialog,
    AddDigestDialog,
    AddAuthorDialog,
    ViewPublicationsComponent,
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,

    //material modules
    BrowserAnimationsModule,
    MatFormFieldModule,
    MatButtonModule,
    MatIconModule,
    MatAutocompleteModule,
    MatInputModule,
    MatDialogModule,
    MatRippleModule,
    ScrollingModule,
    MatDatepickerModule,
    MatNativeDateModule,
    //MaterialModule,
    
    RouterModule.forRoot(routes, { useHash: false }),
  ],
  exports: [
    MatButtonModule,
    MatIconModule,
    MatAutocompleteModule,
    MatFormFieldModule,
    MatInputModule,
    BrowserAnimationsModule,
    MatDialogModule,
    MatRippleModule,
  ],
  providers: [
    LoggedInGuard,
    CurrentUserStorage
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
