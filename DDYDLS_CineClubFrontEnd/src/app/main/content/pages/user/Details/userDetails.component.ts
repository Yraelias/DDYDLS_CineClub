import { Component, OnInit } from '@angular/core';
import { RatingService } from '../../rating/rating.service';
import { Rating } from 'src/app/models/rating';
import { SettingsComponent } from '../settings/settings.component';
import { User } from 'src/app/models/user';
import { MatDialog } from '@angular/material/dialog';
import { MovieService } from '../../movie.service';
import { Movie } from 'src/app/models/movie';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent implements OnInit {

  Username : any = '';
  isConnected : boolean;
  _ratingService : RatingService
  _movieService : MovieService
  iD_User : any = 0;
  listRatings : Rating[];
 dateDuJour : Date = new Date();
 listRatingsByMonth : Rating[];
 listRatingsByYear :Rating[];
 MonthL : number = 0;
 YearL : number = 0;
 Lenght : number = 0;
 user : User;
 a : number = 0;

  constructor(ratingService : RatingService, public dialog: MatDialog, movieService : MovieService) 
  {
    this._ratingService = ratingService;
    this._movieService = movieService;
  }

  ngOnInit(): void {
    console.log(this.dateDuJour);
    if (sessionStorage.getItem('isConnected'))
      {
        this.isConnected = true;
        this.Username = sessionStorage.getItem('Username');
        this.iD_User = sessionStorage.getItem('id');
      }
      this.getUserCommentary();
  
  } 

  getUserCommentary(): void
  {
      this._ratingService.getRatingForUser(this.iD_User).subscribe({
        next: (data:Rating[]) =>
        {
          this.listRatings = data;
          this.Lenght = this.listRatings.length;
          for(this.a = 0; this.a < this.Lenght; this.a++)
            {
              this.getMovieName(this.a);
              console.log("test")
            }
          console.log(this.listRatings);
          console.log(this.Lenght);
        }
      })

      this._ratingService.getRatingForUserbyYear(this.iD_User, this.dateDuJour.getFullYear()).subscribe({
        next: (data:Rating[]) =>
        {
          this.listRatingsByYear = data;
          this.YearL = this.listRatingsByYear.length
          console.log(this.listRatingsByYear);
          console.log(this.YearL);
        }
      })

      this._ratingService.getRatingForUserbyMonth(this.iD_User,this.dateDuJour.getMonth() +1,this.dateDuJour.getFullYear()).subscribe({
        next: (data:Rating[]) =>
        {
          this.listRatingsByMonth = data;
          this.MonthL = this.listRatingsByMonth.length;
          console.log(this.listRatingsByMonth);
          console.log(this.MonthL);
        }
      })
  }

  getMovieName(a : number) : void{
    this._movieService.getOneMovie(this.iD_User,this.listRatings[a].id_Movie).subscribe({
      next: (data:Movie) =>
        {
          console.log(data.name)
          this.listRatings[a].MovieName = data.name
        }
    })
  }

  openDialog() : void {
    const dialogRef =  this.dialog.open(SettingsComponent,{
      data: {user : this.user},
      width: '90%'
    });

    dialogRef.afterClosed().subscribe(data => {
      console.log ("Dialog fermé : "+ data);
    });
  }

  
}
