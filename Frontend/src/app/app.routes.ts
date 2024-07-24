import { Routes } from '@angular/router';
import { UserPanelComponent } from './user-panel/user-panel.component';
import { isLoggedGuardFn } from './auth/is-logged.guard';
import { ProductComponent } from './product/product.component';

export const routes: Routes = [
  {
    path: 'auth',
    loadChildren: () => import('./auth/auth.module').then((m) => m.AuthModule),
  },
  {
    path: 'user',
    component: UserPanelComponent,
  },
  {
    path: 'product',
    component: ProductComponent,
    canActivate: [isLoggedGuardFn],
  },
];
