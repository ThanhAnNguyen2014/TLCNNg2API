import 'rxjs/add/operator/toPromise';
import { Injectable } from '@angular/core';
import { Headers, Http } from '@angular/http';
import { Auth } from '../service/auth.service';

import { Observable } from 'rxjs/Observable';
import 'rxjs/Rx';

@Injectable()
export class ContactService {
    //
    private headers = new Headers({ 'Content-Type': 'application/json' });
    constructor(private _http: Http, private auth: Auth) {
        


    }
    postJson(model) {
        var header = new Headers();
        header.append('Content-type', 'application/json');
        // console.log(this.user);
        return this._http.post("/api/api/getcontact", model, {
            headers: header
        })
            .map(res => res.json());

    };



};