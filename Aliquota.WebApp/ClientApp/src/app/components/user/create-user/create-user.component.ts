import { THIS_EXPR } from '@angular/compiler/src/output/output_ast';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material';
import { Router } from '@angular/router';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-create-user',
  templateUrl: './create-user.component.html',
  styleUrls: ['./create-user.component.css'],
})
export class CreateUserComponent implements OnInit {

  registerForm: FormGroup;
  loading: boolean = false;

  constructor(
    private fb: FormBuilder,
    private userService: UserService,
    private snackBar: MatSnackBar,
    private router: Router,
  ) { }

  get isFormValid() {
    return this.registerForm.valid;
  }

  ngOnInit() {
    this.registerForm = this.fb.group({
      email: [null, [Validators.required, Validators.email]],
      fullName: [null, [Validators.required, Validators.maxLength(50)]],
      password: [null, [Validators.required, Validators.minLength(8), Validators.maxLength(20)]],
    });
  }

  onSubmit() {
    this.loading = true;
    this.userService.createUser({
      email: this.registerForm.value.email,
      fullName: this.registerForm.value.fullName,
      password: this.registerForm.value.password,
    }).subscribe(
      res => {
        if(res.success) {
          this.router.navigateByUrl("/login");
        } else {
          this.loading = false;
          this.snackBar.open(res.message, "Fechar");
        }
      },
      err => this.loading = false
    );
  }
}
