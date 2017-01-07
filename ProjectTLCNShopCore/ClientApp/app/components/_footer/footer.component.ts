import { Component } from '@angular/core';
import { Auth } from '../service/auth.service';

@Component({
    selector: 'footer',
    template: require('./footer.component.html'),
    styles: [require('./footer.component.css')]
})

export class FooterComponent {
    constructor(private auth: Auth) { }
};