import { Routes } from '@angular/router';
import { authGuard } from './core/services/auth.service';

export const routes: Routes = [
  {
    path: '',
    redirectTo: 'login',
    pathMatch: 'full',
  },
  {
    path: 'login',
    loadComponent: () =>
      import('./core/Components/login/login.component').then(
        (m) => m.LoginComponent
      ),
  },
  {
    path: 'dashboard',
    loadComponent: () =>
      import('./features/Components/dashboard/dashboard.component').then(
        (m) => m.DashboardComponent
      ),
    canActivate: [authGuard],
  },
  {
    path: 'users',
    loadComponent: () =>
      import('./features/Components/users/users.component').then(
        (m) => m.UsersComponent
      ),
    canActivate: [authGuard],
  },
  {
    path: 'content',
    loadComponent: () =>
      import('./features/Components/content/content.component').then(
        (m) => m.ContentComponent
      ),
    canActivate: [authGuard],
  },
  {
    path: '**',
    redirectTo: 'login',
  },
];
