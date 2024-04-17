import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { MovieAddComponent } from '../add/movie-add.component';
import { MovieService } from '../../movie.service';
import { Result } from 'src/app/models/tmdbmovie';

@Component({
  selector: 'app-search-movie',
  templateUrl: './search-movie.component.html',
  styleUrl: './search-movie.component.css'
})
export class SearchMovieComponent implements OnInit  {

  data : any
  movieService : MovieService;
  result !: Result; 
  selector : number = 0;
  URLimg:any = "https://image.tmdb.org/t/p/w500//gEU2QniE6E77NI6lCU6MxlNBvIx.jpg";
  maxResult:number =19;

  constructor( public dialogRef: MatDialogRef<MovieAddComponent>, @Inject(MAT_DIALOG_DATA) public datas: any, _movieservice : MovieService) {
    this.movieService = _movieservice;
    this.data = datas;
  }

  ngOnInit(): void {
    this.searchMovie()
  }

  searchMovie() : void {
    this.movieService.getTMDBMovie(this.data.name).subscribe({
      next:(data :Result) =>
        {
          console.log(data);
          this.result = data;
          this.URLimg = "https://image.tmdb.org/t/p/w500/" + this.result.results[this.selector].poster_path;
          if(this.result.results.length < 20) this.maxResult = this.result.results.length;
        },
      error: (error) => {console.log(error)}
    })
  }

  PreviousMovie() :void{
    this.selector = this.selector -1;
    this.URLimg = "https://image.tmdb.org/t/p/w500/" + this.result.results[this.selector].poster_path;
  }
  NextMovie() :void{
    this.selector = this.selector +1;
    this.URLimg = "https://image.tmdb.org/t/p/w500/" + this.result.results[this.selector].poster_path;
  }

  SelectMovie():number{
    return this.selector;                                                                                 
  }
}
