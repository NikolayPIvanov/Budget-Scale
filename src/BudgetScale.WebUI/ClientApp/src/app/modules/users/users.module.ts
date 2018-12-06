import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginFormComponent } from './login-form/login-form.component';
import { FormsModule } from '@angular/forms';
import { ConfigService } from 'src/app/services/config.service';
import { UserService } from 'src/app/services/users/user.service';
import { RegisterFormComponent } from '../register-form/register-form.component';

@NgModule({
  imports: [
    CommonModule,
    FormsModule
  ],
  declarations: [LoginFormComponent, RegisterFormComponent],
  providers: [
    ConfigService,
    UserService
  ]
})
export class UsersModule { }
