import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthGuardService implements CanActivate  {

  constructor(private router: Router) { }

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) 
  {
      if (sessionStorage.getItem('isConnected') == "True") {
          // logged in so return true
          console.log("connecté")
          return true;
      }
  
      // not logged in so redirect to login page with the return url
      this.router.navigate(['/login'], { queryParams: { returnUrl: 
      state.url }});
      console.log("Vous devez etre connecté ")
      return false;
    }
   }

   