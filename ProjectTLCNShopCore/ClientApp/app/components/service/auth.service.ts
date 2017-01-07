import { Injectable, OnInit } from '@angular/core';
import { tokenNotExpired } from 'angular2-jwt';
import { UserService } from "../service/user.service";
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { Observable } from "rxjs/Observable";

// Avoid name not found warnings
declare var Auth0Lock: any;

@Injectable()
export class Auth {
    // Configure Auth0
    lock = new Auth0Lock('gxxqskooruGfCZ0JPyNOxyDVBkYyORkW', 'shopapi.auth0.com', {});
    profile: any;
    userinfor: any;
    constructor(private http: Http, private userservice: UserService) {
        // Add callback for lock `authenticated` event
        this.lock.on("authenticated", (authResult: any) => {
            this.lock.getProfile(authResult.idToken, function (error: any, profile: any) {
                if (error) {
                    throw new Error(error);
                }
                localStorage.setItem('id_token', authResult.idToken);
                localStorage.setItem('profile', JSON.stringify(profile));
                console.log(profile);
                userservice.postinforuser(profile).subscribe((data) => console.log(data));
            });         
             
        });  
        //this.userservice.postinforuser(profile).subscribe(
        //    (data) => console.log(data)
        //);
        console.log('Constructor');
        // write log user.
       
    }
    ngOnInit() {
       
        console.log('OnInit');

    }
    public login() {
        // Call the show method to display the widget.
        
        this.lock.show();
        console.log('Login');
        
    }

    public authenticated() {
        //console.log('authenticated');
        // Check if there's an unexpired JWT
        // This searches for an item in localStorage with key == 'id_token'
        return tokenNotExpired();
    }

    public logout() {
        // Remove token from localStorage
        localStorage.removeItem('id_token');
        localStorage.removeItem('profile');
    }
   

}
