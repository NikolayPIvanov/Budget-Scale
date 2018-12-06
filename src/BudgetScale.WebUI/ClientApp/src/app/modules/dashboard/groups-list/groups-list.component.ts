import { Component, OnInit } from '@angular/core';
import { Group } from 'src/app/models/groups/group.model';
import { HttpErrorResponse } from '@angular/common/http';
import { GroupsListService } from 'src/app/services/groups/groups-list.service';

@Component({
  selector: 'app-groups-list',
  templateUrl: './groups-list.component.html',
  styleUrls: ['./groups-list.component.css']
})
export class GroupsListComponent implements OnInit {
  private errors: string = '';
  private groups: Group[] = [];

  constructor(private groupsService: GroupsListService) { }

  ngOnInit() {
    this.groupsService.requestGroups().subscribe(response => {
      this.groups = response;
      console.log("Current groups in local field", this.groups);
      console.log("Current response from service", response);
    }, (errors: HttpErrorResponse) => {
      this.errors = errors.error;
    })
  }
}
