import 'rxjs/add/operator/toPromise';
import { Injectable } from '@angular/core';
import { Headers, Http } from '@angular/http';
import { Auth } from '../service/auth.service';

import { Observable } from 'rxjs/Observable';
import 'rxjs/Rx';

@Injectable()
export class CheckOutService {
    //
    private headers = new Headers({ 'Content-Type': 'application/json' });
    constructor(private _http: Http, private auth: Auth) {



    }
    postCheckOut(model) {
        var header = new Headers();
        header.append('Content-type', 'application/json');
        console.log("post");
        return this._http.post("/api/cart/postcheckout", model, {
            headers: header
        })
            .map(res => res.json());

    };



};