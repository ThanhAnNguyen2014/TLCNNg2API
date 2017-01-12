import { Component, ChangeDetectorRef,OnInit } from '@angular/core';
import { Auth } from '../service/auth.service';
import { CheckOutService } from '../service/checkout.service';
import { CartService } from '../service/cart.service';
import { CartFull, Cart } from '../module/cart';

import { CheckOut } from '../module/checkout'

import { Headers, Http, RequestOptions, Response } from '@angular/http';
import { Observable } from "rxjs/Rx";

@Component({
    selector: 'checkout',
    template: require('./checkout.component.html'),
    styles: [require('./checkout.component.css')]
})

export class CheckOutComponent implements OnInit {
    postData: string;

    public cart1 = "0,000 VNĐ";
    public line: Cart;
    public rowDataMainForm = [];
    id: number;
    constructor(private auth: Auth, private http: Http, private _httpService: CheckOutService, private changeDetectorRef: ChangeDetectorRef, private cartService: CartService) { }
    model = new CheckOut('', '', '', '');

    public submitted = false;

    onSubmit() {
        this.submitted = true;
        if (!(this.model.email == '' || this.model.name == '' || this.model.address == '')) {


            this._httpService.postCheckOut(this.model).subscribe(
                data => this.postData = JSON.stringify(data),
                error => alert(error),
                () => console.log('Finished Post')
            );
        }
    }

        ngOnInit() {

            console.log(this.cart1);
            this.cartService.getCart().subscribe(data1 => this.cart1 = data1),
                error => alert(error),
                () => console.log("getCart");
            this.cartService.getLineCart().subscribe(data => this.rowDataMainForm = data);
        }
};