import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { SettingsComponent } from '../settings/settings.component';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { UserService } from '../user.service';

@Component({
  selector: 'app-change-password',
  templateUrl: './change-password.component.html',
  styleUrl: './change-password.component.css'
})
export class ChangePasswordComponent implements OnInit {

  passwordFG : FormGroup 
  newPassword: string = '';
  confirmPassword: string = '';
  userService : UserService;

  constructor(public dialogRef: MatDialogRef<SettingsComponent>,private _builder : FormBuilder, _userService : UserService) {
    this.userService = _userService
  }
 ngOnInit(){
  this.passwordFG = this._builder.group({
    newPassword:['',Validators.required],
    confirmPassword : ['',Validators.required]
  });
 }
  onSubmit(){
    if (this.passwordFG.value.newPassword === this.passwordFG.value.confirmPassword) {
      console.log("ok les mdp")
      this.userService.updatePassword
    }
    else
    console.log("nope")
  }
}
