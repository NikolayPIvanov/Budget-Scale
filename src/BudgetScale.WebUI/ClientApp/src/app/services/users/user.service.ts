import { BaseService } from "../base.service";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { BehaviorSubject, Observable } from "rxjs";
import { ConfigService } from "../config.service";
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';
import { Injectable } from "@angular/core";
import 'rxjs/Rx';
import { map } from 'rxjs/operators';



@Injectable({
    providedIn: 'root'
})
export class UserService extends BaseService {

    private loggedIn = false;
    baseUrl: string = '';
    private _authNavStatusSource = new BehaviorSubject<boolean>(false);
    authNavStatus$ = this._authNavStatusSource.asObservable();

    constructor(private http: HttpClient, private configService: ConfigService) {
        super();
        this.loggedIn = !!localStorage.getItem('auth_token');
        this._authNavStatusSource.next(this.loggedIn);
        this.baseUrl = configService.getApiURI();
    }

    register(userName: string, password: string, fullName: string, email: string): Observable<any> {

        let body = JSON.stringify({ email, password, fullName, userName });
        let headers = new HttpHeaders({ 'Content-Type': 'application/json' });
        return this.http.post(this.baseUrl + "/users/register", body, { headers: headers })
    }

    login(email, password) {
        let body = new FormData();
        body.append('email', email);
        body.append('password', password);

        let headers = new HttpHeaders({ 'Content-Type': 'application/x-www-form-urlencoded' });

        return this.http.post(this.baseUrl + '/users/login', body)
            .pipe(map((response: any) => {
                console.log({ response });
                localStorage.setItem('auth_token', response.access_token);
                this.loggedIn = true;
                this._authNavStatusSource.next(true);
                return true;
            }));
    }

    logout() {
        localStorage.removeItem('auth_token');
        this.loggedIn = false;
        this._authNavStatusSource.next(false);
    }

    isLoggedIn() {
        return this.loggedIn;
    }
}