import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/services/users/user.service';
import { Router } from '@angular/router';
import { UserRegistration } from 'src/app/models/users/registraton.model';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-register-form',
  templateUrl: './register-form.component.html',
  styleUrls: ['./register-form.component.css']
})
export class RegisterFormComponent implements OnInit {

  errors: string;
  isRequesting: boolean;
  submitted: boolean = false;

  constructor(private userService: UserService, private router: Router) { }

  ngOnInit() {
  }

  register({ value, valid }: { value: UserRegistration, valid: boolean }) {
    this.submitted = true;
    this.isRequesting = true;
    this.errors = '';
    if (valid) {
      this.userService.register(value.userName, value.password, value.fullName, value.email)
        .subscribe(
          result => {
            if (result) {
              this.router.navigate(['/login'], { queryParams: { brandNew: true, email: value.email } });
            }
          }, (errors: HttpErrorResponse) => {
            errors.error.forEach(element => {
              this.errors += element.description;
            });
          });
    }
  }
}
