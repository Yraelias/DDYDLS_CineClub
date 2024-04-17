import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialog} from '@angular/material/dialog';
import { SearchMovieComponent } from '../search/search-movie.component';

@Component({
  selector: 'app-movie-add',
  templateUrl: './movie-add.component.html',
  styleUrl: './movie-add.component.css'
})
export class MovieAddComponent implements OnInit {

  movieFG : FormGroup
  moviename : string 

  constructor(private _builder : FormBuilder, public dialog: MatDialog) {
  }
  ngOnInit(): void {
  }
  
  openDialog(): void {
    const dialogRef = this.dialog.open(SearchMovieComponent, {
      data: {name: this.moviename},
      width: '90%', height :'90%'
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
      //this.animal = result;
    });
  }
  
}
  
