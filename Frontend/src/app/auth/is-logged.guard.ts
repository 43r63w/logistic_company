import { inject } from '@angular/core';
import { CanActivateFn } from '@angular/router';
import { AuthService } from '../services/auth.service';
import { publishFacade } from '@angular/compiler';

export const isLoggedGuardFn: CanActivateFn = (route, state) => {
  return inject(AuthService).IsUserAuth
};
