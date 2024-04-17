import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialog} from '@angular/material/dialog';
import { SearchMovieComponent } from '../search/search-movie.component';
import { Result } from 'src/app/models/tmdbmovie';

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

  constructor(private _builder : FormBuilder, public dialog: MatDialog) {
  }
  ngOnInit(): void {
  }
  
  openDialog(): void {
    const dialogRef = this.dialog.open(SearchMovieComponent, {
      data: {name: this.moviename},
      width: '90%', height :'90%'
    });

    dialogRef.afterClosed().subscribe(Resul => {
      console.log('The dialog was closed');
      this.result = Resul;
      console.log(this.result);
    });
  }
  
}
  
