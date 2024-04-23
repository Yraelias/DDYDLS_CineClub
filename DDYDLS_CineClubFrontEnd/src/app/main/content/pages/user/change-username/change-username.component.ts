import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { SettingsComponent } from '../settings/settings.component';
import { UserService } from '../user.service';

@Component({
  selector: 'app-change-username',
  templateUrl: './change-username.component.html',
  styleUrl: './change-username.component.css'
})
export class ChangeUsernameComponent implements OnInit {

  
  newPseudo: string = '';
  userService : UserService;

  constructor(public dialogRef: MatDialogRef<SettingsComponent>,private _builder : FormBuilder,_userService : UserService ) {
    this.userService = _userService
  }
 ngOnInit(){
 }
  onSubmit(username : string){
    this.userService.updateUsername(username);
  }
}