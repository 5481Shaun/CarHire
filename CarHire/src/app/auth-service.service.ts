import { isPlatformBrowser } from '@angular/common';
import { Inject, Injectable, PLATFORM_ID } from '@angular/core';
import { BehaviorSubject, Observable,  } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthServiceService {

  private tokenKey = 'token';
  private isLoggedInSubject = new BehaviorSubject<boolean>(false);
  public isLoggedIn$: Observable<boolean> = this.isLoggedInSubject.asObservable();


  constructor(@Inject(PLATFORM_ID) private platformId: object){
    if (isPlatformBrowser(this.platformId)) {
      const hasToken = !!localStorage.getItem(this.tokenKey);
      this.isLoggedInSubject.next(hasToken);
    }
  }

  login(token: string) {
    if (isPlatformBrowser(this.platformId)) {
    localStorage.setItem(this.tokenKey, token);
    this.isLoggedInSubject.next(true);
  }
}

  logout() {
    if (isPlatformBrowser(this.platformId)) {
    localStorage.removeItem(this.tokenKey);
    this.isLoggedInSubject.next(false);
  }
}

hasToken(): boolean {
  if (isPlatformBrowser(this.platformId)) {
    return !!localStorage.getItem(this.tokenKey);
  }
  return false;
}


 
}
