import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs';
import { Credentials } from 'src/app/models/users/credentials.model';
import { UserService } from 'src/app/services/users/user.service';
import { Router, ActivatedRoute } from '@angular/router';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-login-form',
  templateUrl: './login-form.component.html',
  styleUrls: ['./login-form.component.css'],

})
export class LoginFormComponent implements OnInit {

  private subscription: Subscription;

  brandNew: boolean;
  errors: string = '';
  isRequesting: boolean;
  submitted: boolean = false;
  credentials: Credentials = { email: '', password: '' };

  constructor(private userService: UserService, private router: Router, private activatedRoute: ActivatedRoute) { }

  ngOnInit() {
    this.subscription = this.activatedRoute.queryParams.subscribe(
      (param: any) => {
        this.brandNew = param['brandNew'];
        this.credentials.email = param['email'];
      });
  }

  ngOnDestroy() {
    this.subscription.unsubscribe();
  }

  login({ value, valid }: { value: Credentials, valid: boolean }) {
    this.submitted = true;
    this.errors = '';

    if (valid) {
      this.userService.login(value.email, value.password)
        .subscribe(result => {
          if (result) {
            this.router.navigate(['/']);
          }
        }, (errors: HttpErrorResponse) => {
          this.errors = errors.error;
        })
    }
  }

}
