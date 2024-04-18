import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent implements OnInit {

  Username : any = '';
  isConnected : boolean;

  constructor() { }

  ngOnInit(): void {
    if (sessionStorage.getItem('isConnected'))
      {
        this.isConnected = true;
        this.Username = sessionStorage.getItem('Username');
      }
  }

}
