import { Component, OnInit } from '@angular/core';
import { CineclubService } from '../cineclub.service';
import { Cineclub } from 'src/app/models/cineclub';
import { Router } from '@angular/router';
import { error } from 'console';
import { MatSnackBar } from '@angular/material/snack-bar';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { SearchMovieComponent } from '../../movie/search/search-movie.component';
import { MatDialog } from '@angular/material/dialog';

@Component({
  selector: 'app-cineclub-add',
  templateUrl: './cineclub-add.component.html',
  styleUrl: './cineclub-add.component.css'
})
export class CineclubAddComponent implements OnInit {

cineclubService : CineclubService;
cineclub : Cineclub;
errorSnackBar : MatSnackBar;
moviename : string 
movie2name : string 
movie3name : string 
movie4name : string 
movie5name : string 
result : any[] 
selector : number
URLimg : string[]
choose : boolean = false;
newcineclub : Cineclub;
DetailsFormGroup = this._formBuilder.group({
  nameCineclub: ['', Validators.required],
  numberCineclub: ['', Validators.required],
});
rangeFormGroup = new FormGroup({
  start: new FormControl<Date | null>(null,Validators.required),
  end: new FormControl<Date | null>(null,Validators.required),
});
firstMovieFormGroup = this._formBuilder.group({
  moviename: ['', Validators.required],
});
secondMovieFormGroup = this._formBuilder.group({
  movie2name: ['', Validators.required],
});
thirdMovieFormGroup = this._formBuilder.group({
  movie3name: ['', Validators.required],
});
fourMovieFormGroup = this._formBuilder.group({
  movie4name: ['', Validators.required],
});
bonusMovieFormGroup = this._formBuilder.group({
  movie5name: [''],
});

constructor(_cineclubService : CineclubService, private _router : Router, _ErrorSnackbar : MatSnackBar,private _formBuilder: FormBuilder, public dialog: MatDialog) {
  this.cineclubService = _cineclubService;
  this.errorSnackBar = _ErrorSnackbar;
  this.result = [];
  this.URLimg = [];
}

  ngOnInit(): void {
    throw new Error('Method not implemented.');
  }

  addCineclub(cineclub : Cineclub){
    this.cineclubService.addCineclub(cineclub).subscribe({
      next : (data : any) => {
        data : ;
      },
      error : (error) => {this.errorSnackBar.open(error,'Ok')}
    })
  }

  openDialog(moviename :string, id : number): void {
    console.log(moviename +" / " +id);
    const dialogRef = this.dialog.open(SearchMovieComponent, {
      data: {name: moviename},
      width: '90%', height :'90%',
    });

    dialogRef.afterClosed().subscribe(Resul => {
      console.log('The dialog was closed');
      console.log(Resul);
      this.result[id] = Resul;
      console.log(this.result)
      this.URLimg[id] = "https://image.tmdb.org/t/p/w500"+ this.result[id].poster_path;
      if(this.result != null) this.choose = true;
      console.log(this.result);
    });
  }

  ConfirmCineClub():void
  {
    this.cineclub.movie_1 = this.result[0]
    console.log(this.result)
  }
}
