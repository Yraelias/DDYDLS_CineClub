import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { SettingsComponent } from '../settings/settings.component';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-change-password',
  templateUrl: './change-password.component.html',
  styleUrl: './change-password.component.css'
})
export class ChangePasswordComponent implements OnInit {

  passwordFG : FormGroup 
  newPassword: string = '';
  confirmPassword: string = '';

  constructor(public dialogRef: MatDialogRef<SettingsComponent>,private _builder : FormBuilder) {
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
    }
    else
    console.log("nope")
  }
}
