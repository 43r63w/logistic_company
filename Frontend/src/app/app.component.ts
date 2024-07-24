import { Component } from '@angular/core';
import { RouterLink, RouterOutlet } from '@angular/router';
import { AuthModule } from './auth/auth.module';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet,AuthModule,RouterLink],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent {
  title = 'Frontend';
  public isAuth = false
}
