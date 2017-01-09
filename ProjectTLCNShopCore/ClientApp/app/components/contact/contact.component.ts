import { Component} from '@angular/core';
import { Auth } from '../service/auth.service';
import {ContactService } from '../service/contact.service';

import { Contact } from '../module/contact'

import {  Headers, Http, RequestOptions,Response } from '@angular/http';
import { Observable } from "rxjs/Rx";

@Component({
    selector: 'contact',
    template: require('./contact.component.html'),
    styles: [require('./contact.component.css')]
})

export class ContactComponent {
    postData: string;
    constructor(private auth: Auth, private http: Http, private _httpService: ContactService) { }
    model = new Contact('','', '', '','');

    public submitted = false;

    onSubmit() {
        this.submitted = true;
        if (!(this.model.email == '' || this.model.name == '' || this.model.subject == '' || this.model.message == '')) {
           
            
            this._httpService.postJson(this.model).subscribe(
                data => this.postData = JSON.stringify(data),
                error => alert(error),
                () => console.log('Finished Post')
            );
        }
       
    }
};