import { Component, inject } from '@angular/core';
import { Router, RouterLink, RouterOutlet } from '@angular/router';
import { AuthServiceService } from '../../auth-service.service';
import { AsyncPipe, NgIf } from '@angular/common';

@Component({
  selector: 'app-layout',
  standalone: true,
  imports: [
    RouterOutlet,
    RouterLink,
    AsyncPipe, NgIf
  ],
  templateUrl: './layout.component.html',
  styleUrl: './layout.component.scss'
})
export class LayoutComponent {

  private authService = inject(AuthServiceService);
  private router = inject(Router);


  isLoggedIn$ = this.authService.isLoggedIn$;


   onLogout() {
  // Clear authentication
    this.authService.logout();

    this.router.navigate(['/dashboard']);
  }

}
