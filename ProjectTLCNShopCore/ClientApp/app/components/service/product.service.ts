import { Injectable } from '@angular/core';
import { Headers, Http } from '@angular/http';

import 'rxjs/add/operator/toPromise';

import { Product } from '../module/product';

@Injectable()
export class ProductService {
    id: number;
    private headers = new Headers({ 'Content-Type': 'application/json' });
    private heroesUrl = '/api/api/productcate/'
    private heroesUrl1 = '/api/api/product/'
    constructor(private http: Http) {
        console.log(this.heroesUrl);
    }

    // lay danh sach category  
    getProduct(id): Promise<Product[]> {
        console.log(this.heroesUrl+id);
        return this.http.get(this.heroesUrl+id)
            .toPromise()
            .then(response => response.json())
            .catch(this.handleError);
    }

    // lay 1 Product  theo id
    getProductDetail(id): Promise<Product> {
        console.log(this.heroesUrl1 + id);
        return this.http.get(this.heroesUrl1 + id)
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