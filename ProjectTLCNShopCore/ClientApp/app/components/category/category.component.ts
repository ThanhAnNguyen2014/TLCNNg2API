import { Component, OnInit,Pipe } from '@angular/core';
import { Auth } from '../service/auth.service';


import { Router } from '@angular/router';
import { ActivatedRoute, Params } from '@angular/router';
import { Location } from '@angular/common';

import { Product } from '../module/product';
import { ProductService } from '../service/product.service'
declare var $: any;


@Pipe({
    name: "explode"

})
export class ExplodePipe {
    transform(value) {
        return value.split(';',1);
    }
}
@Component({
    selector: 'category',
    template: require('./category.component.html'),
    styles: [require('./category.component.css')]
})

export class CategoryComponent implements OnInit{
    public pro: Product[] = [];
    public id: number;
    constructor(private auth: Auth, private proService: ProductService, private route: ActivatedRoute,
        private location: Location) {
        this.route.params
            .switchMap((params: Params) => this.proService.getProduct(+params['id']))
            .subscribe(pro => this.pro = pro);
         console.log(this.pro);
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