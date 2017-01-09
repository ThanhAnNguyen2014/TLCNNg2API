import { Injectable} from '@angular/core';
import { Router, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { CanActivate } from '@angular/router';
import { Auth } from '../service/auth.service';




@Injectable()
export class AuthGuard implements CanActivate {
    profile: any;
    constructor(private auth: Auth, private router: Router) {
        this.profile = JSON.parse(localStorage.getItem('profile'));
    }

    canActivate(next: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
        if (this.auth.authenticated()) {
            console.log('AUTH GUARD PASSED');


            // not logged in so redirect to login page with the return url

            return true;
        } else {
            console.log('BLOCK BY AUTH GUARD')
            this.router.navigate(['/home']);
            return false;
        }
    }

     
        

}