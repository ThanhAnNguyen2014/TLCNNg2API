import { Component } from '@angular/core';
import { Auth } from '../service/auth.service';

import { HTTPTestService } from '../test/test.service';

@Component({
    selector: 'test',
    template: require('./test.component.html'),
    providers: [HTTPTestService]
})

export class TestComponent {
    getData: string;
    postData: string;
    constructor(private auth: Auth, private _httpService: HTTPTestService) { }
    onGet() {
        console.log('Getting user now.');
        this._httpService.getUser().subscribe(
            data => this.getData = JSON.stringify(data),
            error => alert(error),
            () => console.log('Finished Get')
        );
    }
    onPost() {
        this._httpService.postJson().subscribe(
            data => this.postData = JSON.stringify(data),
            error => alert(error),
            () => console.log('Finished Post')
        );
    }
};