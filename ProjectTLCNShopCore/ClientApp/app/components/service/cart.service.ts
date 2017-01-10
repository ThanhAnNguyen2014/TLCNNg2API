import { Injectable } from '@angular/core';
import { Headers, Http } from '@angular/http';

import 'rxjs/add/operator/toPromise';

import { CartFull,Cart } from '../module/cart';


@Injectable()
export class CartService {
    id: number;
    private headers = new Headers({ 'Content-Type': 'application/json' });
    private apiUrl = '/api/cart/addtocart/'
    private apiUrl1 = '/api/cart/removeproduct/'
    private apiUrl2 = '/api/cart/removelinecart/'
    private apiUrl3 = '/api/cart/removecart'
    private apiUrl4 = '/api/cart/getcart'
    constructor(private http: Http) {
        console.log(this.apiUrl);
    }



    // them 1 Product  vao io hang
    addToCart(id): Promise<any> {
        console.log(this.apiUrl + id);
        return this.http.get(this.apiUrl + id)
            .toPromise()
            .catch(this.handleError);
    }
    // giam so luong Product  trong gio hang di 1
    removeToCart(id): Promise<any> {
        console.log(this.apiUrl1 + id);
        return this.http.get(this.apiUrl1 + id)
            .toPromise()
            .catch(this.handleError);
    }

    // xoa Product  trong gio hang 
    removeLineCart(id): Promise<any> {
        console.log(this.apiUrl2 + id);
        return this.http.get(this.apiUrl2 + id)
            .toPromise()
            .catch(this.handleError);
    }
    // xoa  gio hang 
    removeCart(): Promise<any> {
        console.log(this.apiUrl3);
        return this.http.get(this.apiUrl3)
            .toPromise()
            .catch(this.handleError);
    }

    //get gio hang
    // lay 1 Product  theo id
    getCart() {
        console.log("get Cart");
        const url = '/api/Cart/getcart';
        return this.http.get(url)
            .map(response => <CartFull>response.json())
            .catch(this.handleError);
    }
    getLineCart() {
        console.log("get Cart");
        const url = '/api/Cart/getcart';
        return this.http.get(url)
            .map(response => <Cart>response.json().cart.lines)
            .catch(this.handleError);
    }
   
    // error
    private handleError(error: any): Promise<any> {
        console.error('An error occurred', error); // for demo purposes only
        return Promise.reject(error.message || error);
    }
}