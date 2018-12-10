import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { Group } from 'src/app/models/groups/group.model';
import { HttpErrorResponse } from '@angular/common/http';
import { GroupsListService } from 'src/app/services/groups/groups-list.service';

@Component({
  selector: 'app-groups-list',
  templateUrl: './groups-list.component.html',
  styleUrls: ['./groups-list.component.css'],
  encapsulation: ViewEncapsulation.None,

})
export class GroupsListComponent implements OnInit {
  private errors: string = '';
  private groups: Group[] = [];

  constructor(private groupsService: GroupsListService) { }

  ngOnInit() {
    this.groupsService.requestGroups().subscribe(response => {
      this.groups = response;
      console.log(this.groups)
    },
      (errors: HttpErrorResponse) => {
        this.errors = errors.error;
      })
  }
}
