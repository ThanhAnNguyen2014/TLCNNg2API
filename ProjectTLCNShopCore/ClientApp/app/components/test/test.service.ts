
import 'rxjs/add/operator/toPromise';
import { Injectable } from '@angular/core';
import { Headers, Http } from '@angular/http';
import { Auth } from '../service/auth.service';

import {Observable} from 'rxjs/Observable';
import 'rxjs/Rx';

@Injectable()
export class HTTPTestService{
    //user: User;
    profile: any;
    private headers = new Headers({ 'Content-Type': 'application/json' });
    constructor(private _http: Http, private auth: Auth) {
        this.profile = JSON.parse(localStorage.getItem('profile'));
        //this.user = this.profile;
     

    }



    getUser(){
      return this._http.get("http://jsonplaceholder.typicode.com/users/1")
      .map(res=>res.json());
    };

        
    postJson() {
        var header = new Headers();
        header.append('Content-type', 'application/json');
       // console.log(this.user);
        console.log("xxx");
        return this._http.post("http://localhost:30586/api/api/getuser", this.profile, {
            headers: header
        })
            .map(res => res.json());
        
    };


    
};

//interface User {
//    //name: string;
//    //email: string;
//}

