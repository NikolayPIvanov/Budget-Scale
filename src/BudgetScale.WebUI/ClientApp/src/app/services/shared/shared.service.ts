import { Injectable } from '@angular/core';
import { BaseService } from '../base.service';
import { ConfigService } from '../config.service';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { catchError } from 'rxjs/operators';
import { Group } from 'src/app/models/groups/group.model';

@Injectable({
    providedIn: 'root'
})
export class SharedService extends BaseService {

    baseUrl = "";

    constructor(
        configService: ConfigService,
        private http: HttpClient) {
        super();
        this.baseUrl = configService.getApiURI();
    }

    requestAccounts() {

        let jwtToken = localStorage.getItem('auth_token');
        let headers = new HttpHeaders({ 'Content-Type': 'application/json', 'Authorization': `Bearer ${jwtToken}` });

        return this.http.get<Account[]>(this.baseUrl + `accounts`, { headers: headers })
            .pipe(catchError(this.handleError));
    }


}
