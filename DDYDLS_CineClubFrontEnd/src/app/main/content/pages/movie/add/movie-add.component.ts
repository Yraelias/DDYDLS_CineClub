import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialog} from '@angular/material/dialog';
import { SearchMovieComponent } from '../search/search-movie.component';
import { Result } from 'src/app/models/tmdbmovie';
import { MovieService } from '../../movie.service';
import { Router } from '@angular/router';
import { ErrorSnackbarComponent } from 'src/app/Snackbar/error-snackbar/error-snackbar.component';
import { MatSnackBar } from '@angular/material/snack-bar';

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
  URLimg : string = 'assets/icons/NotFound.webp'
  movieService : MovieService
  isConnected:boolean = false;
  errorSnackBar : MatSnackBar;
  choose : boolean = false;

  constructor(private _builder : FormBuilder, public dialog: MatDialog, public _movieservice : MovieService,private _router : Router, _ErrorSnackbar : MatSnackBar) {
    this.movieService = _movieservice;
    this.errorSnackBar = _ErrorSnackbar
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
      console.log(this.result.poster_path)
      if(this.result.poster_path) this.URLimg = "https://image.tmdb.org/t/p/w500"+ this.result.poster_path;
      if(this.result != null) this.choose = true;
      console.log(this.result);
    });
  }

  AddMovie()
  {
    this.movieService.addMovie(this.result.title,parseInt(this.result.release_date.split('-')[0], 10),this.result.id).subscribe({
      next :(data:any) => {
        data : this._router.navigate(['/movies/' +data])
      },
      error :  (error) => {this.errorSnackBar.open(error,'Ok')}
    })
  }
  
}
  
