import { Routes } from '@angular/router';
import { UserPanelComponent } from './user-panel/user-panel.component';

export const routes: Routes = [
  {
    path: 'auth',
    loadChildren: () => import('./auth/auth.module').then((m) => m.AuthModule),
  },
  {
    path: 'user',
    component: UserPanelComponent,
  },
];
