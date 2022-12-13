import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { AccountService, ChangePasswordResponse } from 'src/app/services/account.service';

@Component({
  selector: 'app-change-password',
  templateUrl: './change-password.component.html',
  styleUrls: ['../auth-styles.scss', './change-password.component.scss']
})
export class ChangePasswordComponent implements OnInit {

  public changePasswordForm: FormGroup;
  public loading = false;
  public submitted = false;
  public returnUrl: string;
  public errorMessage: string;
  public email: string;

  constructor(
    private formBuilder: FormBuilder,
    private router: Router,
    private accountService: AccountService,
    private route: ActivatedRoute) { }

  ngOnInit(): void {

    this.changePasswordForm = this.formBuilder.group({
      password: [''],
      rePassword: ['']
    });
  }

  get form() { return this.changePasswordForm.controls; }

  public async onSubmit(): Promise<void> {
    this.route.queryParams
      .subscribe(params => {
        this.email = params.email;
      }
    );

    const result = await this.accountService.changePassword(this.email, this.form.password.value, this.form.rePassword.value);
    console.log(this.email);

    if (result === ChangePasswordResponse.Success) {
      this.router.navigate(['']);
    }
    if (result === ChangePasswordResponse.PasswordsNotMatch) {
      this.errorMessage = "Passwords not match, check it out and try again";
    }
    if (result === ChangePasswordResponse.EmptyFields) {
      this.errorMessage = "Fields Cannot Be Empty";
    }
  }
}
