import { Routes } from "@angular/router";
import { SignUpComponent } from "./auth/sign-up/sign-up.component";
import { LoginComponent } from "./auth/login/login.component";
import { PasswordRecoverComponent } from "./auth/password-recover/password-recover.component";
import { RegisterComponent } from "./auth/register/register.component";
import { HomeComponent } from "./home/home.component";
import { LoggedInGuard } from "./logged-in.guard";
import { ChangePasswordComponent } from "./auth/create-new-password/change-password.component";
import { AddPublicationComponent } from "./home/publications/add-publication/add-publication.component";
import { ViewPublicationsComponent } from "./home/publications/view-publications/view-publications";

export const routes: Routes = [
  {
    path: '',
    component: HomeComponent,
    canActivate: [LoggedInGuard],
    children: [
      {
        path: 'add-publication',
        component: AddPublicationComponent
      },
      {
        path: 'view-publications',
        component: ViewPublicationsComponent
      }
    ]
  },
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'password-recover', component: PasswordRecoverComponent },
  { path: 'sign-up', component: SignUpComponent },
  { path: 'change-password', component: ChangePasswordComponent },

      // otherwise redirect to home
  { path: '**', redirectTo: '' }
];
