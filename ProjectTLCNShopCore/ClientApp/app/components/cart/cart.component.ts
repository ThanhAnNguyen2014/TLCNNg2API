import { Component, OnInit } from '@angular/core';
import { Auth } from '../service/auth.service';
declare var $: any;

@Component({
    selector: 'cart',
    template: require('./cart.component.html'),
    styles: [require('./cart.component.css')]
})

export class CartComponent implements OnInit {
    constructor(private auth: Auth) { };
    ngOnInit(): any {
        // quantity plus
        $('.value-plus').on('click', function () {
            var divUpd = $(this).parent().find('.value'), newVal = parseInt(divUpd.text(), 10) + 1;
            if (newVal <= 10) divUpd.text(newVal);
        });
        // quantity minus
        $('.value-minus').on('click', function () {
            var divUpd = $(this).parent().find('.value'), newVal = parseInt(divUpd.text(), 10) - 1;
            if (newVal >= 1) divUpd.text(newVal);
        });

        // deleted item in cart
        $('.close4').on('click', function (c) {
            $('.rem4').fadeOut('slow', function (c) {
                $('.rem4').remove();
            });
        });	

     
    }
    
};