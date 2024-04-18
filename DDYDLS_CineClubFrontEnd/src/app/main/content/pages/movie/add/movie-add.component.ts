import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialog} from '@angular/material/dialog';
import { SearchMovieComponent } from '../search/search-movie.component';
import { Result } from 'src/app/models/tmdbmovie';
import { MovieService } from '../../movie.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-movie-add',
  templateUrl: './movie-add.component.html',
  styleUrl: './movie-add.component.css'
})
export class MovieAddComponent implements OnInit {

  movieFG : FormGroup
  moviename : string 
  result : any
  selector : number
  URLimg : string
  movieService : MovieService
  isConnected:boolean = false;

  constructor(private _builder : FormBuilder, public dialog: MatDialog, public _movieservice : MovieService,private _router : Router) {
    this.movieService = _movieservice;
  }
  ngOnInit(): void {
    if (sessionStorage.getItem('isConnected'))
      {
        this.isConnected = true;
      }
  }
  
  openDialog(): void {
    const dialogRef = this.dialog.open(SearchMovieComponent, {
      data: {name: this.moviename},
      width: '90%', height :'90%',
    });

    dialogRef.afterClosed().subscribe(Resul => {
      console.log('The dialog was closed');
      this.result = Resul;
      this.URLimg = "https://image.tmdb.org/t/p/w500"+ this.result.poster_path; ;
      console.log(this.result);
    });
  }

  AddMovie()
  {
    this.movieService.addMovie(this.result.title,parseInt(this.result.release_date.split('-')[0], 10),this.result.id).subscribe({
      next :(data:any) => {
        data : this._router.navigate(['/movies/' +data])
      },
      error :  (error) => {console.log(error)}
    })
  }
  
}
  
