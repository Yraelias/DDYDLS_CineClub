import { Component, OnInit } from '@angular/core';
import { Cineclub } from 'src/app/models/cineclub';
import { CineclubService } from '../cineclub.service';
import { MovieService } from '../../movie.service';
import { Movie } from 'src/app/models/movie';
import { TMDBMovie, Result } from 'src/app/models/tmdbmovie';

@Component({
  selector: 'app-cineclub-list',
  templateUrl: './cineclub-list.component.html',
  styleUrl: './cineclub-list.component.css'
})
export class CineclubListComponent implements OnInit {
  cineclub : Cineclub[] = [];
  dataSource : any;
  tmdbmovie!: TMDBMovie;
  result !: Result; 
  movie : Movie = {id_Movie : 1, name : '', id_Studio : 0, year:0, synopsis : '', rating:{ id_Movie :0, iD_User:0,id_Rating:0,date : new Date, ratings : 0,  approbate:0, commentary:"", username:""}, avgRating:0 ,ratingForUser:0 };
  URLimg:string;
  sameDate : boolean = false;
  
  constructor(private _cineclubService : CineclubService, private movie_service : MovieService) {}

  ngOnInit(): void {
   this.loadCineclub();
  }

  loadCineclub() : void{
    this._cineclubService.getCineclub().subscribe( {
      next: (data : Cineclub[]) =>  
        {
        this.cineclub = data;
        
            for (let i = 0; i<2; i++)
              {
              this.loadTMDBMovie_1(i,this.cineclub[i].movie_1.name)
              this.loadTMDBMovie_2(i,this.cineclub[i].movie_2.name)
              this.loadTMDBMovie_3(i,this.cineclub[i].movie_3.name)
              this.loadTMDBMovie_4(i,this.cineclub[i].movie_4.name)
              this.loadTMDBMovie_5(i,this.cineclub[i].movie_5.name)
              }
      },
      error : (error : any) => console.log(error)}
     )
  }
  loadTMDBMovie_1(i :number, titlemovie : string): void{
    let a  = 0;
    this.movie_service.getTMDBMovie(titlemovie).subscribe({
      next:(data :Result) =>
      {
        this.result = data;
        this.URLimg = "https://image.tmdb.org/t/p/w500/" + this.result.results[0].poster_path;
        
        while(!this.sameDate && a < this.result.results.length)
          {
            if(this.cineclub[i].movie_1.year == parseInt(this.result.results[a].release_date.split('-')[0], 10))
              {
                console.log ("je passe ici")
                this.cineclub[i].movie_1.UrlIMG = "https://image.tmdb.org/t/p/w500/" + this.result.results[a].poster_path;        
                this.cineclub[i].movie_1.synopsis =  this.result.results[a].overview;
                console.log(this.cineclub[i].movie_1.synopsis);
                this.sameDate = true;
              }
              a++;
          }
          this.sameDate = false;
      }
    })
  }

  loadTMDBMovie_2(i :number, titlemovie : string): void{
    let a  = 0;
    this.movie_service.getTMDBMovie(titlemovie).subscribe({
      next:(data :Result) =>
      {
        this.result = data;
        while(!this.sameDate && a < this.result.results.length)
          {
            if(this.cineclub[i].movie_2.year == parseInt(this.result.results[a].release_date.split('-')[0], 10))
              {
                this.cineclub[i].movie_2.UrlIMG = "https://image.tmdb.org/t/p/w500/" + this.result.results[a].poster_path;        
                this.cineclub[i].movie_2.synopsis =  this.result.results[a].overview;
                console.log(this.cineclub[i].movie_2.synopsis);
                this.sameDate = true;
              }
              a++;
          }
          this.sameDate = false;
      }
    })
  }

  loadTMDBMovie_3(i :number, titlemovie : string): void{
    let a  = 0;
    this.movie_service.getTMDBMovie(titlemovie).subscribe({
      next:(data :Result) =>
      {
        this.result = data;
        this.URLimg = "https://image.tmdb.org/t/p/w500/" + this.result.results[0].poster_path;
        
        while(!this.sameDate && a < this.result.results.length)
          {
            if(this.cineclub[i].movie_3.year == parseInt(this.result.results[a].release_date.split('-')[0], 10))
              {
                console.log ("je passe ici")
                this.cineclub[i].movie_3.UrlIMG = "https://image.tmdb.org/t/p/w500/" + this.result.results[a].poster_path;        
                this.cineclub[i].movie_3.synopsis =  this.result.results[a].overview;
                console.log(this.cineclub[i].movie_3.synopsis);
                this.sameDate = true;
              }
              a++;
          }
          this.sameDate = false;
      }
    })
  }

  loadTMDBMovie_4(i :number, titlemovie : string): void{
    let a  = 0;
    this.movie_service.getTMDBMovie(titlemovie).subscribe({
      next:(data :Result) =>
      {
        this.result = data;
        this.URLimg = "https://image.tmdb.org/t/p/w500/" + this.result.results[0].poster_path;
        
        while(!this.sameDate && a < this.result.results.length)
          {
            if(this.cineclub[i].movie_4.year == parseInt(this.result.results[a].release_date.split('-')[0], 10))
              {
                console.log ("je passe ici")
                this.cineclub[i].movie_4.UrlIMG = "https://image.tmdb.org/t/p/w500/" + this.result.results[a].poster_path;        
                this.cineclub[i].movie_4.synopsis =  this.result.results[a].overview;
                console.log(this.cineclub[i].movie_4.synopsis);
                this.sameDate = true;
              }
              a++;
          }
          this.sameDate = false;
      }
    })
  }

  loadTMDBMovie_5(i :number, titlemovie : string): void{
    let a  = 0;
    this.movie_service.getTMDBMovie(titlemovie).subscribe({
      next:(data :Result) =>
      {
        this.result = data;
        this.URLimg = "https://image.tmdb.org/t/p/w500/" + this.result.results[0].poster_path;
        
        while(!this.sameDate && a < this.result.results.length)
          {
            if(this.cineclub[i].movie_5.year == parseInt(this.result.results[a].release_date.split('-')[0], 10))
              {
                console.log ("je passe ici")
                this.cineclub[i].movie_5.UrlIMG = "https://image.tmdb.org/t/p/w500/" + this.result.results[a].poster_path;        
                this.cineclub[i].movie_5.synopsis =  this.result.results[a].overview;
                console.log(this.cineclub[i].movie_5.synopsis);
                this.sameDate = true;
              }
              a++;
          }
          this.sameDate = false;
      }
    })
  }


}
