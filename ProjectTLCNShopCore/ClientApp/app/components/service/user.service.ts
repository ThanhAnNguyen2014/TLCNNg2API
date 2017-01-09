import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { Observable } from 'rxjs/Rx';

// Import RxJs required methods
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';

@Injectable()
export class UserService {

    // Resolve HTTP using the constructor
    constructor(private http: Http) { }
    // private instance variable to hold base url
    // private commentsUrl = 'http://localhost:3000/api/comments';
    private url = '/api/Cart/getuser';

    // Add a new comment
    postinforuser(body: Object):any {
        
        let bodyString = JSON.stringify(body); // Stringify payload
        let headers = new Headers({ 'Content-Type': 'application/json' }); // ... Set content type to JSON
        let options = new RequestOptions({ headers: headers }); // Create a request option
        console.log(body);
        return this.http.post(this.url, body, options) // ...using post request
            .map((res: Response) => res.json()) // ...and calling .json() on the response to return data
            .catch((error: any) => Observable.throw(error.json().error || 'Server error')); //...errors if any
    }   

}