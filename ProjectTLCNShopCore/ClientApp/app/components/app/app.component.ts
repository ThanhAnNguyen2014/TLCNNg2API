import { Component } from '@angular/core';
import { Http } from '@angular/http'
import { Auth } from '../service/auth.service';

@Component({
    selector: 'my-app',
    providers: [Auth],
    template: require('./app.component.html'),
    //styles: [require('./app.component.css')]
})
export class AppComponent {
    constructor(private auth: Auth) { }
    
    //constructor(http: Http) {
    //    http.get('/api/api/').subscribe(result => {
    //        this.cate = result.json();
    //    });
    //}
 
};
interface Cate {
    categoryId: number;
    categoryName: string;
    description: string;
    picture: string;
}