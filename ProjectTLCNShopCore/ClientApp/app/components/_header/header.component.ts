
import { Auth } from '../service/auth.service';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { Category } from '../module/category';
import { CategoryService } from '../service/category.service'


@Component({
    selector: 'header',
    template: require('./header.component.html'),
})

export class HeaderComponent implements OnInit  {
    isIn = false;   // store state
    toggleState() { // click handler
        let bool = this.isIn;
        this.isIn = bool === false ? true : false;
    }
    cate: Category[] = [];

    constructor(private auth: Auth, private cateService: CategoryService) {
    }
    //get category
    ngOnInit() {
        this.cateService
            .getCategory()
            .then(cate => this.cate = cate);
    }
};