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
  data : any
  passwordFG : FormGroup 
  newPassword: string = '';
  confirmPassword: string = '';
  userService : UserService;

  constructor(public dialogRef: MatDialogRef<SettingsComponent>,private _builder : FormBuilder, _userService : UserService, @Inject(MAT_DIALOG_DATA) public datas: any) {
    this.userService = _userService;
    this.data = datas
    
  }
 ngOnInit(){
  this.passwordFG = this._builder.group({
    newPassword:['',Validators.required],
    confirmPassword : ['',Validators.required]
  });
  console.log(this.data)
 }
  onSubmit(){
    if (this.passwordFG.value.newPassword === this.passwordFG.value.confirmPassword) {
      this.userService.updatePassword(this.data.iD_User,this.passwordFG.value.newPassword).subscribe(result =>{
        this.dialogRef.close();
        });
    }
  
  }
}
