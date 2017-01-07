import { Component } from '@angular/core';
import { Auth } from '../service/auth.service';

@Component({
    selector: 'home',
    template: require('./home.component.html')
})

export class HomeComponent {
    //profile: any;
    constructor(private auth: Auth) {
        //this.profile = JSON.parse(localStorage.getItem('profile'));
    }
};