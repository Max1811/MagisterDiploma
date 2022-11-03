import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AccountService, SignUpResponse } from 'src/app/services/account.service';

@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['../auth-styles.scss', './sign-up.component.scss']
})
export class SignUpComponent implements OnInit {

  public signUpForm: FormGroup;
  public loading = false;
  public submitted = false;
  public returnUrl: string;
  public errorMessage: string;

  constructor(
    private formBuilder: FormBuilder,
    private router: Router,
    private accountService: AccountService) { }

  ngOnInit(): void {

    this.signUpForm = this.formBuilder.group({
      email: [''],
      username: [''],
      password: ['']
    });
  }

  get form() { return this.signUpForm.controls; }

  public async onSubmit(): Promise<void> {
    if (this.signUpForm.invalid) {
      return;
    }

    this.loading = true;

    const result = await this.accountService.signUp(this.form.email.value, this.form.username.value, this.form.password.value);

    if (result === SignUpResponse.Success) {
      this.router.navigate(["/login"]);
    }
    else if (result === SignUpResponse.EmptyFields) {
      this.errorMessage = "Fields Cannot Be Empty";
    }
    else if (result === SignUpResponse.InvalidEmail) {
      this.errorMessage = "Invalid Email";
    }
    else if (result === SignUpResponse.InvalidLogin) {
      this.errorMessage = "Invalid login"
    }
    else if (result === SignUpResponse.InvalidPassword) {
      this.errorMessage = "Weak password"
    }
    else if (result === SignUpResponse.LoginIsTaken) {
      this.errorMessage = "This login is already taken"
    }

    this.submitted = true;
    this.loading = false;
  }
}
