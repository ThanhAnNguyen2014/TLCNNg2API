import { Component } from '@angular/core';
import { Auth } from '../service/auth.service';



@Component({
    selector: 'slide',
    template: require('./slide.component.html'),
    styles: [require('./slide.component.css')],
})

export class SlideComponent {

    constructor(private auth: Auth,) {

    }
};
