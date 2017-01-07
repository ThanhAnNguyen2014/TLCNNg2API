import { Component, OnInit } from '@angular/core';
import { Auth } from '../service/auth.service';
import { UserService } from "../service/user.service";
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { Observable } from "rxjs/Observable";

@Component({
    selector: 'my-app',
    template: require('./app.component.html'),
    styles: [require('./app.component.css')]
})
export class AppComponent {
    profile: any;
    constructor(private auth: Auth) {
        this.profile = JSON.parse(localStorage.getItem('profile'));
        //this.userservice.postinforuser(this.profile).subscribe(
        //    (data) => console.log(data)
        //);    
    }
    ngOnInit(){ }

    public postuser() {
        //console.log(this.profile);
        // Get all comments
        //this.userservice.postinforuser(this.profile).subscribe(
        //    (data) => console.log(data)
        //);

    }
};
