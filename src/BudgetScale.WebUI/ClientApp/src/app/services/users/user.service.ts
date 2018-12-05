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

        return this.http.post(this.baseUrl + "/accounts/register", body, { headers: headers, responseType: "text" })
    }

    login(email, password) {
        let body = new URLSearchParams();
        body.set('email', email);
        body.set('password', password);

        return this.http.post(
            this.baseUrl + '/accounts/login', body)
            .pipe(map((response: any) => {
                let tokenInfo = JSON.parse(response);
                localStorage.setItem('auth_token', tokenInfo.auth_token);
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