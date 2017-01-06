import { Component } from '@angular/core';
import { Auth } from '../service/auth.service';

@Component({
    selector: 'header',
    template: require('./header.component.html')
})

export class HeaderComponent {

    isIn = false;   // store state
    toggleState() { // click handler
        let bool = this.isIn;
        this.isIn = bool === false ? true : false;
    }
    constructor(private auth: Auth) { }
};