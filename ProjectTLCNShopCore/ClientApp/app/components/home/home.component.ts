import { Component } from '@angular/core';
import { Auth } from '../service/auth.service';

@Component({
    selector: 'home',
    template: require('./home.component.html')
})

export class HomeComponent {
    constructor(private auth: Auth) { }
};