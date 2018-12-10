import { Component, OnInit } from '@angular/core';
import { SharedService } from 'src/app/services/shared/shared.service';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-side-menu',
  templateUrl: './side-menu.component.html',
  styleUrls: ['./side-menu.component.css']
})
export class SideMenuComponent implements OnInit {
  errors: string = '';
  accounts: Account[] = [];

  constructor(private sharedService: SharedService) { }

  ngOnInit() {
    this.sharedService.requestAccounts().subscribe(response => {
      this.accounts = response;
    },
      (errors: HttpErrorResponse) => {
        this.errors = errors.error;
      })
  }
}
