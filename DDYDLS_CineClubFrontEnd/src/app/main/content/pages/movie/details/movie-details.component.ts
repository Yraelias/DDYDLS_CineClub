import { Component, OnInit } from '@angular/core';
import { MovieService } from '../../movie.service';
import { Movie } from 'src/app/models/movie';
import { ActivatedRoute } from '@angular/router';
import { TMDBMovie, Result } from 'src/app/models/tmdbmovie';


@Component({
  selector: 'app-movie-details',
  templateUrl: './movie-details.component.html',
  styleUrls: ['./movie-details.component.css']
})
export class MovieDetailsComponent implements OnInit {
  id:number
  movie : Movie = {id_movie : 0, name : '', id_studio : 0, year:0, synopsis : '', rating:{ id_movie :0, id_user:0,id_rating:0,date : new Date, ratings : 0}, avgRating:0 };
  tmdbmovie!: TMDBMovie;
  result !: Result; 
  URLimg:any = "https://image.tmdb.org/t/p/w500//gEU2QniE6E77NI6lCU6MxlNBvIx.jpg";

  constructor(private movie_service : MovieService, private activedRoute : ActivatedRoute) {
    this.id  = activedRoute.snapshot.params['id'];
   }

  ngOnInit(): void {
    this.loadMovie();
  }

  loadMovie():void{
    this.movie_service.getOneMovie(this.id).subscribe({
      next: (data :Movie) =>
      {
        console.log(data);
        this.movie = data;
        this.loadTMDBMovie();
      }
    })
  }

  loadTMDBMovie(): void{
    this.movie_service.getTMDBMovie(this.movie.name).subscribe({
      next:(data :Result) =>
      {
        console.log(data);
        this.result = data;
        this.URLimg = "https://image.tmdb.org/t/p/w500/" + this.result.results[0].poster_path;
      }
    })
  }

}
