import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { AccountService, PasswordRecoverResponse, SignUpResponse } from 'src/app/services/account.service';

@Component({
  selector: 'app-password-recover',
  templateUrl: './password-recover.component.html',
  styleUrls: ['../auth-styles.scss', './password-recover.component.scss']
})
export class PasswordRecoverComponent implements OnInit {

  public passwordRecoverForm: FormGroup;
  public loading = false;
  public submitted = false;
  public returnUrl: string;
  public errorMessage: string;
  public successMessage: string;

  constructor(
    private formBuilder: FormBuilder,
    private router: Router,
    private accountService: AccountService) { }

  ngOnInit(): void {

    this.passwordRecoverForm = this.formBuilder.group({
      email: ['']
    });
  }

  get form() { return this.passwordRecoverForm.controls; }

  public async onSubmit(): Promise<void> {
    const result = await this.accountService.recoverPassword(this.form.email.value);

    if (result === PasswordRecoverResponse.Success) {
      this.successMessage = "Recovery email has been sent";
    }
    else if (result === PasswordRecoverResponse.UserNotExists) {
      this.errorMessage = "This user does not exist";
    }
    else if (result === PasswordRecoverResponse.EmailNotValid) {
      this.errorMessage = "Invalid Email";
    }
  }
}
