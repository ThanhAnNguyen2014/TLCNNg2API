import { Component, OnInit } from '@angular/core';
import { Auth } from '../service/auth.service';
import { Location } from '@angular/common';
import { CartService } from '../service/cart.service';
import { CartFull, Cart } from '../module/cart';
//import { cart } from '../module/cart';
declare var $: any;
@Component({
    selector: 'cart',
    template: require('./cart.component.html'),
    styles: [require('./cart.component.css')]
})

export class CartComponent implements OnInit {

    public cart1: CartFull;
    public line: Cart;
    id: number;
   // line: cart;
    constructor(private auth: Auth, private location: Location, private cartService: CartService) {

        // get cart
            console.log(this.cart1);
            this.cartService.getCart().subscribe(data => this.cart1 = data),
                error => alert(error),
                () => console.log("getCart");
            console.log(this.line);
            this.cartService.getLineCart().subscribe(data => this.line = data);
    };
    ngOnInit():any {
        //// quantity plus
        //$('.value-plus').on('click', function () {
        //    var divUpd = $(this).parent().find('.value'), newVal = parseInt(divUpd.text(), 10) + 1;
        //    if (newVal <= 10) divUpd.text(newVal);
        //});
        //// quantity minus
        //$('.value-minus').on('click', function () {
        //    var divUpd = $(this).parent().find('.value'), newVal = parseInt(divUpd.text(), 10) - 1;
        //    if (newVal >= 1) divUpd.text(newVal);
        //});

        //// deleted item in cart
        //$('.close4').on('click', function (c) {
        //    $('.rem4').fadeOut('slow', function (c) {
        //        $('.rem4').remove();
        //    });
        //});
    	
     
        

        }
    plusCart(id) {
            this.cartService
            .addToCart(id);

    }
    removeCart(id) {
        this.cartService
            .removeToCart(id);
    }

    removeLineCart(id) {
        this.cartService
            .removeLineCart(id);
    }


    goBack(): void {
        this.location.back();
    }
    
};