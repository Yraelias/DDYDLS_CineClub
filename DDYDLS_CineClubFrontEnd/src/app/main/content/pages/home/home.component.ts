import { Component, OnInit } from '@angular/core';
import { MovieService } from '../movie.service';
import { Movie } from '../../../../models/movie';
import { TMDBMovie, Result } from '../../../../models/tmdbmovie';
@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  _movieService : MovieService
  movie : Movie
  result:  Result
  URLimg:any = 'assets/icons/NotFound.webp';
  sameDate : boolean = false;
  isConnected:boolean

  constructor(movieService : MovieService) {
    this._movieService = movieService;
   }

  ngOnInit(): void {
  this.getRandomMovie();
  }
  getRandomMovie(){
    this._movieService.getMovieRandom().subscribe({
            next: (data:Movie) =>
            {
              this.movie = data;
              console.log(this.movie);
              this.loadMovieVisitor()
            }
          })
  }
    loadMovieVisitor():void{
      this._movieService.getOneMovieVisitor(this.movie.id_Movie).subscribe({
        next: (data :Movie) =>
        {
          console.log(data);
          this.movie = data;
          this.loadTMDBMovie();
        }
      })
    }
      loadTMDBMovie(): void{
        let a  = 0;
        this._movieService.getTMDBMovie(this.movie.name).subscribe({
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
        this._movieService.getRottenMovie(this.movie.EN_name!,this.movie.year).subscribe({
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
}
