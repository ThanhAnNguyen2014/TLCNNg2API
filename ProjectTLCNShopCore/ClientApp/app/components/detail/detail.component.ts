import { Component } from '@angular/core';
import { Auth } from '../service/auth.service';

@Component({
    selector: 'detail',
    template: require('./detail.component.html'),
    styles: [require('./detail.component.css')]
})

export class DetailComponent {
    constructor(private auth: Auth) { }
};