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
  iD_User  : any;

  constructor(public dialogRef: MatDialogRef<SettingsComponent>,private _builder : FormBuilder,_userService : UserService ) {
    this.userService = _userService
  }
 ngOnInit(){
  if (sessionStorage.getItem('isConnected'))
    {
      this.iD_User = sessionStorage.getItem('id');
    }
 }
  onSubmit(username : string){
    this.userService.updateUsername(this.iD_User,username).subscribe(result =>{
      sessionStorage.setItem('Username',username);
      this.dialogRef.close()
    }
    )
  }
}