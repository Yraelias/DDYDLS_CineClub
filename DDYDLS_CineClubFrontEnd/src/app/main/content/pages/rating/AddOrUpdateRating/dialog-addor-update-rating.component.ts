import { Component, Inject, OnInit, inject } from '@angular/core';
import { MatDialog,  MatDialogRef, MatDialogActions, MatDialogClose,  MatDialogTitle,  MatDialogContent, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatInput } from '@angular/material/input';
import { Movie } from 'src/app/models/movie';
import { RatingService } from '../rating.service';
import { Rating } from 'src/app/models/rating';
import { error } from 'console';

@Component({
  selector: 'app-dialog-addor-update-rating',
  templateUrl: './dialog-addor-update-rating.component.html',
  styleUrls: ['./dialog-addor-update-rating.component.css']
})
export class DialogAddorUpdateRatingComponent implements OnInit {
  ratingSelectionned : number = 0;
  Reco : number = 2
  movie : any
  message : MatInput
  iD_User : number;
  AddOrUpdate : boolean = false //False = Add and True = Update
  constructor(private ratingservice : RatingService, public dialogRef: MatDialogRef<DialogAddorUpdateRatingComponent>, @Inject(MAT_DIALOG_DATA) public data: Movie) {
    this.movie = data;
   }
  ngOnInit(): void {
    console.log(this.movie.movie)
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
    let ok : Boolean;
    console.log(this.ratingSelectionned);
    console.log(this.Reco);
    console.log(message);
    console.log(sessionStorage.getItem("id"));
    this.iD_User = parseInt(sessionStorage.getItem("id") || "0") ;
    console.log(this.movie.movie.name)
    if(!this.AddOrUpdate) {
      this.ratingservice.addRatingForMovie(this.iD_User, this.movie.movie.id_Movie, this.ratingSelectionned,message,this.Reco).subscribe({
        next : (data : any) => {ok = true},
        error : (error) => {console.log(error)},
    }); //Service Ajout
    }
    else this.ratingservice.updateRatingForMovie(this.iD_User, this.movie.movie.id_Movie, this.ratingSelectionned,message,this.Reco).subscribe({
      next : (data : any) => {ok = true},
      error : (error) => {console.log(error)},
  });  //Service modifié
    console.log("note ajoutée ou modifié");
  }

  

}
