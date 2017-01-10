import { Component, OnInit, Pipe } from '@angular/core';
import { Auth } from '../service/auth.service';


import { Router } from '@angular/router';
import { ActivatedRoute, Params } from '@angular/router';
import { Location } from '@angular/common';

import { Product } from '../module/product';
import { ProductService } from '../service/product.service';
import { CartService } from '../service/cart.service'
declare var $: any;

@Component({
    selector: 'detail',
    template: require('./detail.component.html'),
    styles: [require('./detail.component.css')]
})

export class DetailComponent implements OnInit {
    id: number;
   prodetail: Product;
    constructor(private auth: Auth, private proService: ProductService, private route: ActivatedRoute,
        private location: Location, private cartService: CartService) {
        this.route.params
            .switchMap((params: Params) => this.proService.getProductDetail(+params['id']))
            .subscribe(prodetail =>this.prodetail = prodetail);
        //console.log(this.pro.productID);
    }
    ngOnInit() {

    }

    addCart() {
        this.cartService
            .addToCart(this.prodetail.productID);
    }

    goBack(): void {
        this.location.back();
    }

};
