import { Component, OnInit } from '@angular/core';
import { Auth } from '../service/auth.service';
declare var $: any;

@Component({
    selector: 'category',
    template: require('./category.component.html'),
    styles: [require('./category.component.css')]
})

export class CategoryComponent implements OnInit{
    constructor(private auth: Auth) { };

    ngOnInit(): any {

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
};