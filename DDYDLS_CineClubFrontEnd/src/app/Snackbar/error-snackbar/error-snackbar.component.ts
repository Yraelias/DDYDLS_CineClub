import { Component } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-error-snackbar',
  templateUrl: './error-snackbar.component.html',
  styleUrl: './error-snackbar.component.css'
})
export class ErrorSnackbarComponent {

constructor(private _snackBar: MatSnackBar) {}

openSnackBar(message :string, action: string) {
  this._snackBar.open(message, 'OK', {
    horizontalPosition: 'center',
    verticalPosition: 'top'
  });
}

}
