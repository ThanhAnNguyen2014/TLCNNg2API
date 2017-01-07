import { Component } from '@angular/core';
import { Auth } from '../service/auth.service';

@Component({
    selector: 'profile',
    template: require('./profile.component.html'),
    styles: [require('./profile.component.css')]
})

export class ProfileComponent {
    profile: any;
    constructor(private auth: Auth) {
        this.profile = JSON.parse(localStorage.getItem('profile'));
        //console.log(this.profile);
        //console.log(this.profile.user_id);
    }
};