import { Injectable } from '@angular/core';
import { BaseService } from '../base.service';
import { ConfigService } from '../config.service';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { catchError } from 'rxjs/operators';
import { Group } from 'src/app/models/groups/group.model';

@Injectable({
  providedIn: 'root'
})
export class GroupsListService extends BaseService {

  baseUrl = "";

  constructor(
    configService: ConfigService,
    private http: HttpClient) {
    super();
    this.baseUrl = configService.getApiURI();
  }

  requestGroups() {
    let jwtToken = localStorage.getItem('auth_token');
    console.log(jwtToken);
    let headers = new HttpHeaders({ 'Content-Type': 'application/json', 'Authorization': `Bearer ${jwtToken}` });

    //TODO: Add month to query;
    return this.http.get<Group[]>(this.baseUrl + "/groups/shaped", { headers: headers })
      .pipe(catchError(this.handleError));
  }


}
