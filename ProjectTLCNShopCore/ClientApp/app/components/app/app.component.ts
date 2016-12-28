import { Component } from '@angular/core';
import { Http } from '@angular/http'
@Component({
    selector: 'my-app',
    template: require('./app.component.html'),
    styles: [require('./app.component.css')]
})
export class AppComponent {
    public recentlMovie = "None";
    public cart = [];
    public movieList = ['Cấu trúc dữ liệu', 'Điện Toán Đám Mây', 'Thương mại điện tử', 'Hướng đối tượng'];
    selectMovie(movie) {
        this.recentlMovie = movie;
        this.cart.push(movie);
        alert(movie+ ' was added to Cart');
    };
    //constructor(http: Http) {
    //    http.post('/Cart/'){}

    //}
    
};