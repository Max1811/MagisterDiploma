import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AccountService } from 'src/app/services/account.service';
import { LoginResponse } from 'src/app/services/account.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['../auth-styles.scss', './login.component.scss']
})

export class LoginComponent implements OnInit {

  public fieldTextType: boolean;
  public errorMessage: string;
  public loginForm: FormGroup;
  public loading = false;
  public submitted = false;
  public returnUrl: string;

  constructor(
    private formBuilder: FormBuilder,
    private router: Router,
    private accountService: AccountService) { }

  ngOnInit(): void {

    this.loginForm = this.formBuilder.group({
      username: [''],
      password: ['']
    });
  }

  get form() { return this.loginForm.controls; }

  toggleFieldTextType() {
    this.fieldTextType = !this.fieldTextType;
  }

  public async onSubmit(): Promise<void> {
    if (this.loginForm.invalid) {
      return;
    }

    this.loading = true;

    const result = await this.accountService.login(this.form.username.value, this.form.password.value);

    if (result === LoginResponse.Success) {
      this.router.navigate(["/"]);
    }
    else if (result === LoginResponse.IncorrectPassword) {
      this.errorMessage = "Incorrect Password";
    }
    else if (result === LoginResponse.IncorrectLogin) {
      this.errorMessage = "Incorrect login";
    }
    else if (result === LoginResponse.EmptyData) {
      this.errorMessage = "Fields Cannot Be Empty"
    }

    this.submitted = true;
    this.loading = false;
  }
}
