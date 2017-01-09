
import { Auth } from '../service/auth.service';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Category } from '../module/category';
import { TestHttpService } from '../service/test-http.service'

@Component({
    selector: 'test-http',
    template: require('./test-http.component.html'),
})

export class TestHttpComponent implements OnInit {
    cate: Category[] = [];
    constructor(private auth: Auth, private testhttpService: TestHttpService) {
        console.log(this.cate);
    }
    ngOnInit() {
        console.log("chay qua day");
            this.testhttpService
                .getCategory()
            .then(cate => this.cate = cate);
            console.log(this.cate);
        }
};