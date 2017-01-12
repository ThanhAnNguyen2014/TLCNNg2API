import 'rxjs/add/operator/toPromise';
import { Injectable } from '@angular/core';
import { Headers, Http } from '@angular/http';
import { Auth } from '../service/auth.service';
import { Product } from '../module/product';

import { Observable } from 'rxjs/Observable';
import 'rxjs/Rx';

@Injectable()
export class SearchService {
    searchstring:string;
    private headers = new Headers({ 'Content-Type': 'application/json' });
    private apiUrl6 = 'api/api/keysearch/key=';  // URL to web api
    constructor(private http: Http, private auth: Auth) {



    }
    // lay danh sach product by search
    getSearch(searchstring): Promise<Product[]> {
        console.log(searchstring);
        return this.http.get(this.apiUrl6 + searchstring)
            .toPromise()
            .then(response => response.json())
            .catch(this.handleError);
       
    }

    // error
    private handleError(error: any): Promise<any> {
        console.error('An error occurred', error); // for demo purposes only
        return Promise.reject(error.message || error);
    }



};