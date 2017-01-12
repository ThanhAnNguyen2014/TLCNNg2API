
import { Auth } from '../service/auth.service';
import { Component, OnInit,Input} from '@angular/core';
import { Router } from '@angular/router';
import { Headers, Http, RequestOptions, Response } from '@angular/http';
import { Category } from '../module/category';
import { CategoryService } from '../service/category.service';
import { SearchService } from '../service/search.service'
import { ActivatedRoute, Params } from '@angular/router';
import { Location } from '@angular/common';

@Component({
    selector: 'header',
    template: require('./header.component.html'),
    styles: [require('./header.component.css')]
})

export class HeaderComponent implements OnInit  {
    isIn = false;   // store state
    toggleState() { // click handler
        let bool = this.isIn;
        this.isIn = bool === false ? true : false;
    }
    cate: Category[] = [];
    model: string;
    postData: string;
    public submitted = false;
    @Input() search: string = "";
    public searchstring: number;
    constructor(location: Location, private auth: Auth, private cateService: CategoryService, private http: Http, private searchService: SearchService, public _router: Router) {
    }
    //get category
    ngOnInit() {
        this.cateService
            .getCategory()
            .then(cate => this.cate = cate);
    }

    onSearch(search) {
        if (search != "")
           
            this._router.navigate(['/search', search]);

    }
};