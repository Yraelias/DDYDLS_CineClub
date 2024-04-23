import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { SettingsComponent } from '../settings/settings.component';
import { UserService } from '../user.service';

@Component({
  selector: 'app-desactivate-dialog',
  templateUrl: './desactivate-dialog.component.html',
  styleUrl: './desactivate-dialog.component.css'
})
export class DesactivateDialogComponent {
  Desactive : any
  data : any
  userService : UserService
  constructor(@Inject(MAT_DIALOG_DATA) public datas: any, public dialogRef: MatDialogRef<SettingsComponent>, _userService : UserService) {
    this.data = datas;
    this.userService = _userService;
  }

}
