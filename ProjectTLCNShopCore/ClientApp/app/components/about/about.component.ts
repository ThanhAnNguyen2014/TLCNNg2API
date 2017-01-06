import { Component } from '@angular/core';
import { Auth } from '../service/auth.service';

@Component({
    selector: 'about',
    template: require('./about.component.html'),
    styles: [require('./about.component.css')]
})

export class AboutComponent {

    constructor(private auth: Auth) { }
};