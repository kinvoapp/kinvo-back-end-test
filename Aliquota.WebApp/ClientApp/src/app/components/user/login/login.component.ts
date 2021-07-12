import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material';
import { Router } from '@angular/router';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  loginForm: FormGroup;
  loading: boolean = false;

  constructor(
    private fb: FormBuilder,
    private userService: UserService,
    private snackBar: MatSnackBar,
    private router: Router,
  ) { }

  get isFormValid() {
    return this.loginForm.valid;
  }

  ngOnInit() {
    this.loginForm = this.fb.group({
      email: [null, [Validators.required]],
      password: [null, [Validators.required]],
    });
  }

  onSubmit() {
    this.loading = true;
    this.userService.login({
      email: this.loginForm.value.email,
      password: this.loginForm.value.password,
    }).subscribe(
      res => {
        if(res.success) {
          this.router.navigateByUrl('/portfolio');
        } else {
          this.snackBar.open(res.message, "Fechar");
          this.loading = false;
        }
      }
    );
  }
}
