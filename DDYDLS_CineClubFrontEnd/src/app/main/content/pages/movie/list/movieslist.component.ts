import { Component, OnInit } from '@angular/core';
import { MovieService } from '../../movie.service';
import { Movie } from '../movie';

@Component({
  selector: 'app-movieslist',
  templateUrl: './movieslist.component.html',
  styleUrls: ['./movieslist.component.css']
})
export class MoviesListComponent implements OnInit {

  movies : Movie[] = [];
  constructor( private _movieService : MovieService

  ) { }

  ngOnInit(): void {
    
    
    this._movieService.getMovies();
    this.movies = this._movieService.movies
  }

}
