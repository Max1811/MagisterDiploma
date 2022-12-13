import { Injectable } from '@angular/core';
import { ApiClient } from './api.client';

@Injectable({
    providedIn:'root'
})

export class AccountService {
  constructor(private api: ApiClient) { }

  public login(login: string, password: string): Promise<LoginResponse> {
      return this.api.post('account/login', { login: login, password: password })
  }

  public logout() {
      return this.api.post('account/logout', {});
  }

  public getCurrentUser(): Promise<ICurrentUser | null> {
      return this.api.get('account/me');
  }

  public signUp(email: string, login: string, password: string): Promise<SignUpResponse> {
    return this.api.post('account/sign-up', { email: email, login: login, password: password });
  }

  public recoverPassword(email: string): Promise<PasswordRecoverResponse> {
    return this.api.post('account/password-recovery', { email: email });
  }

  public changePassword(email: string, password: string, repeatPassword: string): Promise<ChangePasswordResponse> {
    return this.api.post('account/change-password', { email: email, password: password, repeatPassword: repeatPassword });
  }
}

export enum LoginResponse {
  Success = "Success",
  IncorrectPassword = "IncorrectPassword",
  IncorrectLogin = "IncorrectLogin",
  EmptyData = "EmptyData"
}

export enum SignUpResponse {
  Success = "Success",
  InvalidEmail = "InvalidEmail",
  InvalidLogin = "InvalidLogin",
  InvalidPassword = "InvalidPassword",
  EmptyFields = "EmptyFields",
  LoginIsTaken = "LoginIsTaken"
}

export enum PasswordRecoverResponse {
  EmailNotValid = "EmailNotValid",
  UserNotExists = "UserNotExists",
  Success = "Success"
}

export enum ChangePasswordResponse {
  Success = "Success",
  PasswordsNotMatch = "PasswordsNotMatch",
  EmptyFields = "EmptyFields"
}

export interface ICurrentUser {
    id?: number;
    login?: string;
}

