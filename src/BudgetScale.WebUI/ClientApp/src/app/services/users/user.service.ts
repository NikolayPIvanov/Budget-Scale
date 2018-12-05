import { BaseService } from "../base.service";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { BehaviorSubject, Observable } from "rxjs";
import { ConfigService } from "../config.service";
import 'rxjs/add/operator/catch';
import { Injectable } from "@angular/core";

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

}