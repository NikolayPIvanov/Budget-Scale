import { Component, OnInit } from '@angular/core';
import { MDBBootstrapModule } from 'angular-bootstrap-md';

@Component({
  selector: 'app-app-layout',
  templateUrl: './app-layout.component.html',
  styleUrls: ['./app-layout.component.css']
})
export class AppLayoutComponent implements OnInit {

  constructor() {

    MDBBootstrapModule.forRoot()
  }

  ngOnInit() {

    MDBBootstrapModule.forRoot()
  }

}
