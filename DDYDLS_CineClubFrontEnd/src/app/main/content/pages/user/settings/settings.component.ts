import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA, MatDialog } from '@angular/material/dialog';
import { DesactivateDialogComponent } from '../desactivate-dialog/desactivate-dialog.component';
import { UserService } from '../user.service';
import { ChangePasswordComponent } from '../change-password/change-password.component';
import { ChangeUsernameComponent } from '../change-username/change-username.component';
import { Router } from '@angular/router';

@Component({
  selector: 'app-settings',
  templateUrl: './settings.component.html',
  styleUrl: './settings.component.css'
})
export class SettingsComponent {
  Desac : boolean = false;
  userService : UserService
  iD_User : any

  constructor(public dialog: MatDialog, _userService : UserService, public _router : Router) {
    this.userService = _userService;
    this.iD_User = sessionStorage.getItem('id');
  }
  openDesactDialog(): void {
    const dialogRef = this.dialog.open(DesactivateDialogComponent,{
      width : '90%' 
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log('apres dialog : '+result)
      this.Desac = result;
      console.log(this.Desac);
      if(this.Desac == true)
        {
          this.iD_User = sessionStorage.getItem('id');
          this.userService.DesactivateAccount(this.iD_User).subscribe(result =>{
          sessionStorage.clear();
          window.location.reload();
          });
        } 
    });
  }

  openChangepasswordDialog(): void {
    const dialogRef = this.dialog.open(ChangePasswordComponent,{
      data: {iD_User: this.iD_User},
      width : '90%' 
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log('apres dialog : '+result)
      if(this.Desac == true)
        {
          this.iD_User = sessionStorage.getItem('id');
          this.userService.updatePassword(this.iD_User,result);
        } 
    });
  }

  openChangeusernameDialog(): void {
    const dialogRef = this.dialog.open(ChangeUsernameComponent,{
      width : '90%' 
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log('Username modifié')
      window.location.reload();
    });
  }
}
