import { Component, OnInit } from '@angular/core';
import { MovieService } from '../../movie.service';
import { Movie } from 'src/app/models/movie';
import { ActivatedRoute } from '@angular/router';
import { TMDBMovie, Result } from 'src/app/models/tmdbmovie';
import { DialogAddorUpdateRatingComponent } from '../../rating/AddOrUpdateRating/dialog-addor-update-rating.component';
import { MatDialog,  MatDialogRef, MatDialogActions, MatDialogClose,  MatDialogTitle,  MatDialogContent } from '@angular/material/dialog';



@Component({
  selector: 'app-movie-details',
  templateUrl: './movie-details.component.html',
  styleUrls: ['./movie-details.component.css']
})
export class MovieDetailsComponent implements OnInit {
  iD_User:any  
  movie : Movie = {id_Movie : 1, name : '', id_Studio : 0, year:0, synopsis : '', rating:{ id_Movie :0, iD_User:0,id_Rating:0,date : new Date, rating : 0,  approbate:0, commentary:"", username:""}, avgRating:0 ,ratingForUser:0, Rottenrating:0 };
  tmdbmovie!: TMDBMovie;
  result !: Result; 
  URLimg:any = 'assets/icons/NotFound.webp';
  isConnected:boolean
  myNoteIsNull : boolean
  sameDate : boolean = false;

  constructor(private movie_service : MovieService, private activedRoute : ActivatedRoute, public dialog: MatDialog) {
    this.movie.id_Movie  = activedRoute.snapshot.params['id'];
    this.iD_User = sessionStorage.getItem('id');
   }

   

  ngOnInit(): void {
    if (this.iD_User == null || this.iD_User == undefined) this.loadMovieVisitor();
    else this.loadMovie();
    if (sessionStorage.getItem('isConnected'))
    {
      this.isConnected = true;
      this.iD_User = sessionStorage.getItem('id');
    }
  }
  loadMovieVisitor():void{
    this.movie_service.getOneMovieVisitor(this.movie.id_Movie).subscribe({
      next: (data :Movie) =>
      {
        console.log(data);
        this.movie = data;
        this.loadTMDBMovie();
      }
    })
  }
  loadMovie():void{
    this.movie_service.getOneMovie(this.iD_User,this.movie.id_Movie).subscribe({
      next: (data :Movie) =>
      {
        console.log(data);
        this.movie = data;
        this.loadTMDBMovie();
      }
    })
  }

  loadOnlyMovie():void{
    this.movie_service.getOneMovie(this.iD_User,this.movie.id_Movie).subscribe({
      next: (data :Movie) =>
      {
        this.movie = data;
        console.log(this.movie)
      }
    })
  }
  loadTMDBMovie(): void{
    let a  = 0;
    this.movie_service.getTMDBMovie(this.movie.name).subscribe({
      next:(data :Result) =>
      {
        console.log(data);
        this.result = data;
        this.URLimg = "https://image.tmdb.org/t/p/w500/" + this.result.results[0].poster_path;
        while(!this.sameDate && a < this.result.results.length)
          {
            if(this.movie.year == parseInt(this.result.results[a].release_date.split('-')[0], 10))
              {
                console.log ("je passe ici")
                this.URLimg = "https://image.tmdb.org/t/p/w500/" + this.result.results[a].poster_path;        
                this.movie.synopsis =  this.result.results[a].overview;
                this.movie.EN_name = this.result.results[a].original_title
                this.movie.TMDBrating = this.result.results[a].vote_average;
                this.loadRottenMovie();
                this.sameDate = true;
              }
              a++;
          }
      }
    })
  }
  loadRottenMovie():void{
    this.movie_service.getRottenMovie(this.movie.EN_name!,this.movie.year).subscribe({
      next :(data : any) => {
        console.log(data)
        this.movie.Rottenrating = parseFloat(data.Ratings[1].Value.replace('%',''));
        this.Avg();
        console.log(this.movie)
      }
    })
  }

  Avg():void{
          this.movie.Rottenrating = (this.movie.Rottenrating! / 100) * 6;
          this.movie.TMDBrating = (this.movie.TMDBrating!/10) * 6;
          this.movie.avgratingEXT = (this.movie.Rottenrating + this.movie.TMDBrating!) /2;
  }

  openDialog(enterAnimationDuration: string, exitAnimationDuration: string) : void {
    const dialogRef =  this.dialog.open(DialogAddorUpdateRatingComponent,{
      data: {movie : this.movie},
      width: '90%'
    });

    dialogRef.afterClosed().subscribe(data => {
      console.log ("Dialog fermé : "+ data);
      location.reload();
    });
  }


}

