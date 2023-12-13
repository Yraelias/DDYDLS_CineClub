import { Component, Inject, OnInit, inject } from '@angular/core';
import { MatDialog, MatDialogRef, MatDialogActions, MatDialogClose, MatDialogTitle, MatDialogContent, MAT_DIALOG_DATA} from '@angular/material/dialog';
import { MatInput } from '@angular/material/input';
import { Movie } from 'src/app/models/movie';

@Component({
  selector: 'app-dialog-addor-update-rating',
  templateUrl: './dialog-addor-update-rating.component.html',
  styleUrls: ['./dialog-addor-update-rating.component.css']
})
export class DialogAddorUpdateRatingComponent implements OnInit {
  ratingSelectionned : number = 0;
  Reco : number = 0
  movie : any
  message : MatInput
  AddOrUpdate : boolean = false //False = Add and True = Update
  constructor(public dialogRef: MatDialogRef<DialogAddorUpdateRatingComponent>, @Inject(MAT_DIALOG_DATA) public data: Movie) {
    this.movie = data;
   }
  ngOnInit(): void {
    console.log(this.movie.movie)
    console.log(this.movie.movie.name)
    console.log(this.movie.movie.name)
    this.ratingSelectionned = this.movie.movie.ratingForUser
    if (this.ratingSelectionned == 10) this.AddOrUpdate = false;
    else this.AddOrUpdate = true;
  }
  
  onClickRating(rating : number)  {
    console.log ("Je choisis le " +rating);
    this.ratingSelectionned = rating;
  }

  onClickRecom(reco : number)  {
    console.log ("Je choisis le " +reco);
    if(this.Reco == reco) this.Reco = 0;
    else this.Reco = reco; 
  }

  validateRating(message : string){
    console.log(this.ratingSelectionned);
    console.log(this.Reco);
    console.log(message);
    console.log(sessionStorage.getItem("id"));
    console.log(this.movie.movie.name)
    if(!this.AddOrUpdate) console.log("Ajout"); //Service Ajout
    else console.log("Modifier") //Service modifié
  }

}
