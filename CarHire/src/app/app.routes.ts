import { RouterModule, Routes } from '@angular/router';
import { NgModule } from '@angular/core';
import { LoginComponent } from './pages/login/login.component';
import { LayoutComponent } from './pages/layout/layout.component';
import { DashboardComponent } from './pages/dashboard/dashboard.component';
import { BookingsComponent } from './pages/bookings/bookings.component';
import { CustomersComponent } from './pages/customers/customers.component';
import { VehiclesComponent } from './pages/vehicles/vehicles.component';
import { Error500Component } from './auth/error500/error500.component';
import { authGuard } from './auth.guard';

export const routes: Routes = [
    { path: 'login', component: LoginComponent },

   {
    path: '',
    component: LayoutComponent,
    children: [
      { path: '', redirectTo: 'dashboard', pathMatch: 'full' },
      { path: 'dashboard', component: DashboardComponent},
      { path: 'vehicles/:id', component: VehiclesComponent, canActivate: [authGuard] },
      { path: 'bookings', component: BookingsComponent, canActivate: [authGuard] },
      { path: 'customers', component: CustomersComponent, canActivate: [authGuard] },
      {
    path: 'error-500',
    component: Error500Component,
    data: { title: '500 - Error' },
  },
    ],
  },
  { path: '**', redirectTo: 'dashboard' }
];

