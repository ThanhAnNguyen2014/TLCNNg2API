import { Injectable } from '@angular/core';
import { Headers, Http } from '@angular/http';

import 'rxjs/add/operator/toPromise';

import { Category } from '../module/category';

@Injectable()
export class CategoryService {
    private headers = new Headers({ 'Content-Type': 'application/json' });
    private heroesUrl = '/api/api/getcategory';  // URL to web api

    constructor(private http: Http) {
        console.log(this.heroesUrl);
    }

    // lay danh sach category
    getCategory(): Promise<Category[]> {
        return this.http.get(this.heroesUrl)
            .toPromise()
            .then(response => response.json())
            .catch(this.handleError);
    }
    // error
    private handleError(error: any): Promise<any> {
        console.error('An error occurred', error); // for demo purposes only
        return Promise.reject(error.message || error);
    }
}