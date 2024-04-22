import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA, MatDialog } from '@angular/material/dialog';
import { DesactivateDialogComponent } from '../desactivate-dialog/desactivate-dialog.component';
import { UserService } from '../user.service';
import { ChangePasswordComponent } from '../change-password/change-password.component';

@Component({
  selector: 'app-settings',
  templateUrl: './settings.component.html',
  styleUrl: './settings.component.css'
})
export class SettingsComponent {
  Desac : boolean = false;
  userService : UserService

  constructor(public dialog: MatDialog, _userService : UserService) {
    this.userService = _userService;
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
          this.userService.DesactivateAccount();
        } 
    });
  }

  openChangepasswordDialog(): void {
    const dialogRef = this.dialog.open(ChangePasswordComponent,{
      width : '90%' 
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log('apres dialog : '+result)
      this.Desac = result;
      console.log(this.Desac);
      if(this.Desac == true)
        {
          this.userService.DesactivateAccount();
        } 
    });
  }
}
