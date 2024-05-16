import { Component, OnInit } from '@angular/core';
import { CineclubService } from '../cineclub.service';
import { Cineclub } from 'src/app/models/cineclub';
import { Router } from '@angular/router';
import { error } from 'console';
import { MatSnackBar } from '@angular/material/snack-bar';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { SearchMovieComponent } from '../../movie/search/search-movie.component';
import { MatDialog } from '@angular/material/dialog';
import { MovieService } from '../../movie.service';
import { Movie } from 'src/app/models/movie';

@Component({
  selector: 'app-cineclub-add',
  templateUrl: './cineclub-add.component.html',
  styleUrl: './cineclub-add.component.css'
})
export class CineclubAddComponent implements OnInit {

cineclubService : CineclubService;
cineclub : Cineclub = new Cineclub;
errorSnackBar : MatSnackBar;
moviename : string 
movie2name : string 
movie3name : string 
movie4name : string 
movie5name : string 
result : any[] 
selector : number
URLimg:any = 'assets/icons/NotFound.webp';
choose : boolean = false;
newcineclub : Cineclub;
movieService : MovieService;
id_movie : number[]

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

constructor(_cineclubService : CineclubService, private _router : Router, _ErrorSnackbar : MatSnackBar,private _formBuilder: FormBuilder, public dialog: MatDialog, public _movieservice : MovieService) {
  this.cineclubService = _cineclubService;
  this.errorSnackBar = _ErrorSnackbar;
  this.result = [];
  this.URLimg = [];
  this.movieService = _movieservice;
  this.id_movie = [];
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
    const dialogRef = this.dialog.open(SearchMovieComponent, {
      data: {name: moviename},
      width: '90%', height :'90%',
    });

    dialogRef.afterClosed().subscribe(Resul => {
      this.result[id] = Resul;
      if(this.result[id].poster_path) this.URLimg[id] = "https://image.tmdb.org/t/p/w500"+ this.result[id].poster_path;
      else this.URLimg[id] = 'assets/icons/NotFound.webp';
      if(this.result != null) this.choose = true;
      this.AddMovie(id)
    });
  }


  AddMovie(id : number)
  {
    this.movieService.addMovie(this.result[id].title,parseInt(this.result[id].release_date.split('-')[0], 10),this.result[id].id).subscribe({
      next :(data:any) => {
        console.log(data);
        if(id == 0) {this.cineclub.id_movie_1 = data , console.log ("ID" + id ),console.log(this.cineclub.id_movie_1),console.log(data) }
        if(id == 1) {this.cineclub.id_movie_2 = data, console.log ("ID" + id ),console.log(this.cineclub.id_movie_2),console.log(data)}
        if(id == 2) {this.cineclub.id_movie_3 = data, console.log ("ID" + id ),console.log(this.cineclub.id_movie_3),console.log(data)}
        if(id == 3) {this.cineclub.id_movie_4 = data, console.log ("ID" + id ),console.log(this.cineclub.id_movie_4),console.log(data)}
        if(id == 4) {this.cineclub.id_movie_5 = data, console.log ("ID" + id ),console.log(this.cineclub.id_movie_5),console.log(data)}
      },
      error :  (error) => {this.errorSnackBar.open(error,'Ok')}
    })
  }

  
  ConfirmCineClub():void
  {
    console.log(this.id_movie)
    this.cineclub.movie_1 = new Movie();
    this.cineclub.movie_2 = new Movie();
    this.cineclub.movie_3 = new Movie();
    this.cineclub.movie_4 = new Movie();
    this.cineclub.movie_5 = new Movie();
    this.cineclub.movie_1.id_Movie = this.cineclub.id_movie_1;
    this.cineclub.movie_2.id_Movie = this.cineclub.id_movie_2;
    this.cineclub.movie_3.id_Movie = this.cineclub.id_movie_3;
    this.cineclub.movie_4.id_Movie = this.cineclub.id_movie_4;
    this.cineclub.movie_5.id_Movie = this.cineclub.id_movie_5;
    this.cineclub.title = this.DetailsFormGroup.value.nameCineclub || 'Pas de titre';
    if (this.DetailsFormGroup.value.numberCineclub !== null && this.DetailsFormGroup.value.numberCineclub !== undefined) {
      this.cineclub.numberOfCineclub = parseInt(this.DetailsFormGroup.value.numberCineclub, 10);
    } else {
      this.cineclub.numberOfCineclub = 0;
    }
    this.cineclub.begin = this.rangeFormGroup.value.start || new Date; 
    this.cineclub.end = this.rangeFormGroup.value.end || new Date; 
    this.cineclubService.addCineclub(this.cineclub).subscribe({
      next : (data : any) =>{
        console.log(data);
        this._router.navigate(['/cineclub'])
      },
      error : (error) => {this.errorSnackBar.open(error,'Ok')}
    })
  }
}
