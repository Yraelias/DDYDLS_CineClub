import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MovieService } from '../../movie.service';
import { Movie } from '../../../../../models/movie';
import { MatPaginator } from '@angular/material/paginator';

@Component({
  selector: 'app-movieslist',
  templateUrl: './movieslist.component.html',
  styleUrls: ['./movieslist.component.css']
})
export class MoviesListComponent implements OnInit, AfterViewInit  {
  
  dataSource : any;
  displayedColumns: string[] = ['name','synopsis','year','details'];
  movies : Movie[] = [];

  @ViewChild(MatPaginator)
  paginator!: MatPaginator;

  
  constructor( private _movieService : MovieService

  ) { }
  ngAfterViewInit(): void {
    this.dataSource.paginator = this.paginator;
  }

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
