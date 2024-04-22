import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { SettingsComponent } from '../settings/settings.component';

@Component({
  selector: 'app-desactivate-dialog',
  templateUrl: './desactivate-dialog.component.html',
  styleUrl: './desactivate-dialog.component.css'
})
export class DesactivateDialogComponent {
  Desactive : any
  data : any
  constructor(@Inject(MAT_DIALOG_DATA) public datas: any, public dialogRef: MatDialogRef<SettingsComponent>) {
    this.data = datas;
  }

}
