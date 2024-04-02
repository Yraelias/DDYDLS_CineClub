import { Component, Inject, OnInit, inject } from '@angular/core';
import { MatLegacyDialog as MatDialog, MatLegacyDialogRef as MatDialogRef, MatLegacyDialogActions as MatDialogActions, MatLegacyDialogClose as MatDialogClose, MatLegacyDialogTitle as MatDialogTitle, MatLegacyDialogContent as MatDialogContent, MAT_LEGACY_DIALOG_DATA as MAT_DIALOG_DATA} from '@angular/material/legacy-dialog';
import { MatLegacyInput as MatInput } from '@angular/material/legacy-input';
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
  Reco : number = 0
  movie : any
  message : MatInput
  id_User : number;
  AddOrUpdate : boolean = false //False = Add and True = Update
  constructor(private ratingservice : RatingService, public dialogRef: MatDialogRef<DialogAddorUpdateRatingComponent>, @Inject(MAT_DIALOG_DATA) public data: Movie) {
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
    let ok : Boolean;
    console.log(this.ratingSelectionned);
    console.log(this.Reco);
    console.log(message);
    console.log(sessionStorage.getItem("id"));
    this.id_User = parseInt(sessionStorage.getItem("id") || "0") ;
    console.log(this.movie.movie.name)
    if(!this.AddOrUpdate) {
      this.ratingservice.addRatingForMovie(this.id_User, this.movie.movie.id_Movie, this.ratingSelectionned).subscribe({
        next : (data : any) => {ok = true},
        error : (error) => {console.log(error)},
    }); //Service Ajout
    }
    else this.ratingservice.updateRatingForMovie(this.id_User, this.movie.movie.id_Movie, this.ratingSelectionned).subscribe({
      next : (data : any) => {ok = true},
      error : (error) => {console.log(error)},
  });  //Service modifié
    console.log("note ajoutée ou modifié");
  }

  

}