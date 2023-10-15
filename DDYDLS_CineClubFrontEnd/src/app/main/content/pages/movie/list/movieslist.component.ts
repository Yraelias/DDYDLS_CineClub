import { Component, OnInit } from '@angular/core';
import { MovieService } from '../../movie.service';
import { Movie } from '../../../../../models/movie';

@Component({
  selector: 'app-movieslist',
  templateUrl: './movieslist.component.html',
  styleUrls: ['./movieslist.component.css']
})
export class MoviesListComponent implements OnInit {
  displayedColumns: string[] = ['name','synopsis','year','details'];
  dataSource : any;

  movies : Movie[] = [];
  constructor( private _movieService : MovieService

  ) { }

  ngOnInit(): void {
    this.loadMovies();
    console.log(this.movies);
  }

  loadMovies() : void{
    this._movieService.getMovies().subscribe( {
      next: (data : Movie[]) =>  this.dataSource = data,
      error : (error : any) => console.log(error)}
     )
    this._movieService.getMovies();
    this.movies = this._movieService.movies;
    this.dataSource = this.movies;
    console.log(this.dataSource)
  }

}
