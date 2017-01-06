import { Component } from '@angular/core';
import { Auth } from '../service/auth.service';

@Component({
    selector: 'contact',
    template: require('./contact.component.html'),
    styles: [require('./contact.component.css')]
})

export class ContactComponent {
    constructor(private auth: Auth) { }
};