import { Component } from '@angular/core';

@Component({
  selector: 'app-login',
  standalone: false,
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss'
})
export class LoginComponent {

<<<<<<< Updated upstream
=======
  constructor(
    private _formBuilder: FormBuilder,
    private _authService: AuthService
  ) {
    this.loginForm = _formBuilder.group({
      email: ['', [Validators.email, Validators.required]],
      password: ['', Validators.required],
    });
  }



  login(){
    
  }

>>>>>>> Stashed changes
}
