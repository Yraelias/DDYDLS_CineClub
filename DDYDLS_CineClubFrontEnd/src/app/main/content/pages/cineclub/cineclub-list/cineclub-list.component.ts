import { Component } from '@angular/core';
import { Cineclub } from 'src/app/models/cineclub';
import { CineclubService } from '../cineclub.service';
import { MovieService } from '../../movie.service';
import { Movie } from 'src/app/models/movie';
import { TMDBMovie, Result } from 'src/app/models/tmdbmovie';

@Component({
  selector: 'app-cineclub-list',
  standalone: true,
  imports: [],
  templateUrl: './cineclub-list.component.html',
  styleUrl: './cineclub-list.component.css'
})
export class CineclubListComponent {
  cineclub : Cineclub[] = [];
  dataSource : any;
  tmdbmovie!: TMDBMovie;
  result !: Result; 
  movie : Movie = {id_Movie : 1, name : '', id_Studio : 0, year:0, synopsis : '', rating:{ id_Movie :0, id_User:0,id_Rating:0,date : new Date, ratings : 0,  approbate:0, commentary:"", username:""}, avgRating:0 ,ratingForUser:0 };
  URLimg:string;
  
  constructor(private _cineclubService : CineclubService, private movie_service : MovieService) {}

  ngOnInit(): void {
    this.loadCineclub();
    console.log(this.cineclub);
  }

  loadCineclub() : void{
    this._cineclubService.getCineclub().subscribe( {
      next: (data : Cineclub[]) =>  
        {
        this.cineclub = data;
        
            for (let i = 0; i<4; i++)
              {
                this.cineclub[i].movie_1.UrlIMG = this.loadTMDBMovie(i,this.cineclub[i].movie_1.name)
                this.cineclub[i].movie_2.UrlIMG = this.loadTMDBMovie(i,this.cineclub[i].movie_2.name)
                this.cineclub[i].movie_3.UrlIMG = this.loadTMDBMovie(i,this.cineclub[i].movie_3.name)
                this.cineclub[i].movie_4.UrlIMG = this.loadTMDBMovie(i,this.cineclub[i].movie_4.name)
                console.log(this.cineclub[i].movie_1.UrlIMG);
                console.log(this.cineclub[i].movie_2.UrlIMG);
                console.log(this.cineclub[i].movie_3.UrlIMG);
                console.log(this.cineclub[i].movie_4.UrlIMG);
              }
      },
      error : (error : any) => console.log(error)}
     )
  }

  loadTMDBMovie(i :number, titlemovie : string): any{
    this.movie_service.getTMDBMovie(titlemovie).subscribe({
      next:(data :Result) =>
      {
        console.log(data);
        this.result = data;
        this.URLimg = "https://image.tmdb.org/t/p/w500/" + this.result.results[0].poster_path;
        this.cineclub[i].movie_1.UrlIMG = "https://image.tmdb.org/t/p/w500/" + this.result.results[0].poster_path;
        return this.URLimg;
      }
    })
  }

}
