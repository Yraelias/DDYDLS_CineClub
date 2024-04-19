import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MovieService } from '../../movie.service';
import { Movie } from '../../../../../models/movie';

@Component({
  selector: 'app-movieslist',
  templateUrl: './movieslist.component.html',
  styleUrls: ['./movieslist.component.css']
})
export class MoviesListComponent implements OnInit, AfterViewInit  {
  
  dataSource : any;
  displayedColumns: string[] = ['name','year','details'];
  movies : Movie[] = [];
  isConnected:boolean = false;
  

  
  constructor( private _movieService : MovieService

  ) { }
  ngAfterViewInit(): void {
    
  }

  ngOnInit(): void {
    if (sessionStorage.getItem('isConnected'))
      {
        this.isConnected = true;
      }
    this.loadMovies();
    console.log(this.movies);
  }

  loadMovies() : void{
    this._movieService.getMovies().subscribe( {
      next: (data : Movie[]) =>  this.dataSource = data,
      error : (error : any) => console.log(error)}
     )
  }

}
