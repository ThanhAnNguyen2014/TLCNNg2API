import { Component, OnInit } from '@angular/core';
import { Auth } from '../service/auth.service';
import { CartService } from '../service/cart.service';


import { Router } from '@angular/router';
import { ActivatedRoute, Params } from '@angular/router';
import { Location } from '@angular/common';

import { Product } from '../module/product';
import {SearchService } from '../service/search.service'
declare var $: any;

@Component({
    selector: 'search',
    template: require('./search.component.html'),
    styles: [require('./search.component.css')]
})

export class SearchComponent implements OnInit {
    public pro: Product[] = [];
    public searchstring: string;
    constructor(private auth: Auth, private searchService: SearchService, private cartService: CartService, private route: ActivatedRoute,
        private location: Location) {
        this.route.params
            .switchMap((params: Params) => this.searchService.getSearch(params['searchstring']))
            .subscribe(pro => this.pro = pro);
        console.log(this.pro);
    }
    // add to cart
    addCart(id) {
        console.log();
        this.cartService
            .addToCart(id);
    }
    // scroll tto top
    ngOnInit() {
        //


        //
        //this.proService
        //    .getProduct(this.id)
        //    .then(pro => this.pro = pro);

        $(document).ready(function ($) {
            if ($(".btn-top").length > 0) {
                $(window).scroll(function () {
                    var e = $(window).scrollTop();
                    if (e > 300) {
                        $(".btn-top").show()
                    } else {
                        $(".btn-top").hide()
                    }
                });
                $(".btn-top").click(function () {
                    $('body,html').animate({
                        scrollTop: 0
                    })
                })
            }
        });

    }

    //



    //get category

};