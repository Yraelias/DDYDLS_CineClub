import { Component, Inject, OnInit, inject } from '@angular/core';
import { MatDialog, MatDialogRef, MatDialogActions, MatDialogClose, MatDialogTitle, MatDialogContent, MAT_DIALOG_DATA} from '@angular/material/dialog';
import { Movie } from 'src/app/models/movie';

@Component({
  selector: 'app-dialog-addor-update-rating',
  templateUrl: './dialog-addor-update-rating.component.html',
  styleUrls: ['./dialog-addor-update-rating.component.css']
})
export class DialogAddorUpdateRatingComponent implements OnInit {

  movie : any
  constructor(public dialogRef: MatDialogRef<DialogAddorUpdateRatingComponent>, @Inject(MAT_DIALOG_DATA) public data: Movie) {
    this.movie = data;
   }
  ngOnInit(): void {
    console.log(this.movie.movie)
    console.log(this.movie.movie.name)
  }
  
  

}
