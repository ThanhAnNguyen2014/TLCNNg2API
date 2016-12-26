import { Component } from '@angular/core';
import { Http } from '@angular/http';

@Component({
    selector: 'my-app',
    template: require('./app.component.html'),
    styles: [require('./app.component.css')]
})
export class AppComponent {
    //title = 'My Shop';
    //hero = 'Windstorm';
    //public cate: catergories[];

    //constructor(http: Http) {
    //    http.get('/api/categories').subscribe(result => {
    //        this.cate = result.json();
    //    });
    //}
    public movieList = ['Công ngh? PM', 'Th??ng m?i ?i?n t?', 'C?u trúc d? li?u'];
    selectedMovie() {
        alert('amoive was selected!');
    }

}


interface catergories {
    categoryId: number;
    categoryName: string;
    description: string;
    picture: string;
    displayOrder: number;
    isDisplay: boolean;
    products: any[];
}
