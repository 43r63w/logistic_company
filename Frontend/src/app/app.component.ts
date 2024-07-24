import { Component, inject } from '@angular/core';
import { RouterLink, RouterOutlet } from '@angular/router';
import { AuthModule } from './auth/auth.module';
import { AuthService } from './services/auth.service';
import {
  MatSnackBar,
  MatSnackBarLabel,
  MatSnackBarModule,
} from '@angular/material/snack-bar';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, AuthModule, RouterLink, MatSnackBarModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss',
})
export class AppComponent { 
  public isAuth = false;
  
  constructor(
    private _authService: AuthService,
    private _matSnackBar: MatSnackBar
  ) {}

  login() {
    this._authService.login1();
  }

  click() {
    this._authService.IsUserAuth.next(false)
  }

  title = 'Frontend';
 
}
