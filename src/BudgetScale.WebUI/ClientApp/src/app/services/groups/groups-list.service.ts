import { Injectable } from '@angular/core';
import { BaseService } from '../base.service';
import { ConfigService } from '../config.service';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class GroupsListService extends BaseService {

  baseUrl: string = '';

  constructor(
    configServie: ConfigService,
    private http: HttpClient, ) {
    super();
    this.baseUrl = configServie.getApiURI();
  }

  requestGroups() {
    let jwtToken = localStorage.getItem('access_token');
    let headers = new HttpHeaders({ 'Content-Type': 'application/json', 'Authorization': `Bearer ${jwtToken}` });

    //TODO: Add month to query;
    return this.http.get(this.baseUrl + '/groups', { headers: headers })
      .pipe(catchError(this.handleError))
  }


}
