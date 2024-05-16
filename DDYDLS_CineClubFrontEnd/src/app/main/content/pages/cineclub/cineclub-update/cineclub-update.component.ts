import { Component, Inject, OnInit } from '@angular/core';
import { CineclubService } from '../cineclub.service';
import { Cineclub } from 'src/app/models/cineclub';
import { Router } from '@angular/router';
import { error } from 'console';
import { MatSnackBar } from '@angular/material/snack-bar';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { SearchMovieComponent } from '../../movie/search/search-movie.component';
import { MAT_DIALOG_DATA, MatDialog } from '@angular/material/dialog';
import { MovieService } from '../../movie.service';
import { Movie } from 'src/app/models/movie';

@Component({
  selector: 'app-cineclub-update',
  templateUrl: './cineclub-update.component.html',
  styleUrl: './cineclub-update.component.css'
})
export class CineclubUpdateComponent implements OnInit {

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
URLimg : string[]
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

constructor(_cineclubService : CineclubService, private _router : Router, _ErrorSnackbar : MatSnackBar,private _formBuilder: FormBuilder, public dialog: MatDialog, public _movieservice : MovieService,  
            @Inject(MAT_DIALOG_DATA) public data: number) {
  this.cineclubService = _cineclubService;
  this.errorSnackBar = _ErrorSnackbar;
  this.result = [];
  this.URLimg = [];
  this.movieService = _movieservice;
  this.id_movie = [];
}

  ngOnInit(): void {
    this.getCineclub();
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
      this.AddMovie(id)
    });
  }

  getCineclub()
  {
    this.cineclubService.getOneCineclub(this.data).subscribe({
      next : (data:Cineclub) => {
        console.log(data);
        this.cineclub.movie_1 = new Movie();
        this.cineclub.movie_2 = new Movie();
        this.cineclub.movie_3 = new Movie();
        this.cineclub.movie_4 = new Movie();
        this.cineclub.movie_5 = new Movie();
        this.cineclub.movie_1.id_Movie = data.movie_1.id_Movie;
        this.cineclub.movie_2.id_Movie = data.movie_2.id_Movie;
        this.cineclub.movie_3.id_Movie = data.movie_3.id_Movie;
        this.cineclub.movie_4.id_Movie = data.movie_4.id_Movie;
        this.cineclub.id_movie_1 = this.cineclub.movie_1.id_Movie;
        this.cineclub.id_movie_2 = this.cineclub.movie_2.id_Movie;
        this.cineclub.id_movie_3 = this.cineclub.movie_3.id_Movie;
        this.cineclub.id_movie_4 = this.cineclub.movie_4.id_Movie;
        this.cineclub.id_movie_5 = this.cineclub.movie_5.id_Movie;
        console.log("cineclub ICI")
        console.log(this.cineclub)
        this.cineclub.movie_5.id_Movie != null ? data.movie_5.id_Movie : null;
        this.DetailsFormGroup.patchValue({
          nameCineclub: data.title,
          numberCineclub  : data.numberOfCineclub != null ? data.numberOfCineclub.toString() : ''
        });
        this.rangeFormGroup.patchValue({
          start: new Date(data.begin),  
          end: new Date(data.end) 
        });
        this.firstMovieFormGroup.patchValue({
          moviename: data.movie_1.name
        });
        this.secondMovieFormGroup.patchValue({
          movie2name: data.movie_2.name
        });
        this.thirdMovieFormGroup.patchValue({
          movie3name: data.movie_3.name
        }); 
        this.fourMovieFormGroup.patchValue({
          movie4name: data.movie_4.name
        });
        this.bonusMovieFormGroup.patchValue({
          movie5name: data.movie_5.name != null ? data.movie_5.name : null
        });
      },
      error : (error) => {this.errorSnackBar.open(error,'Ok')}
    })
  }

  AddMovie(id : number)
  {
    this.movieService.addMovie(this.result[id].title,parseInt(this.result[id].release_date.split('-')[0], 10),this.result[id].id).subscribe({
      next :(data:any) => {
        console.log(data);
        this.id_movie[id] = data;
        if(id == 0) {this.cineclub.id_movie_1 = data , console.log ("ID" + id ),console.log(this.cineclub.id_movie_1),console.log(data) }
        if(id == 1) {this.cineclub.id_movie_2 = data, console.log ("ID" + id ),console.log(this.cineclub.id_movie_2),console.log(data)}
        if(id == 2) {this.cineclub.id_movie_3 = data, console.log ("ID" + id ),console.log(this.cineclub.id_movie_3),console.log(data)}
        if(id == 3) {this.cineclub.id_movie_4 = data, console.log ("ID" + id ),console.log(this.cineclub.id_movie_4),console.log(data)}
        if(id == 4) {this.cineclub.id_movie_5 = data, console.log ("ID" + id ),console.log(this.cineclub.id_movie_5),console.log(data)}
        console.log("Ajout des films")
        console.log(this.cineclub) 
      },
      error :  (error) => {this.errorSnackBar.open(error,'Ok')}
    })
  }

  
  ConfirmCineClub():void
  {
    console.log(this.cineclub);
    console.log("end "+this.rangeFormGroup.value.end);
    this.cineclub.movie_1.id_Movie = this.cineclub.id_movie_1;
    this.cineclub.movie_2.id_Movie = this.cineclub.id_movie_2;
    this.cineclub.movie_3.id_Movie = this.cineclub.id_movie_3;
    this.cineclub.movie_4.id_Movie = this.cineclub.id_movie_4;
    this.cineclub.movie_5.id_Movie = this.cineclub.id_movie_5;
    console.log(this.id_movie)
    this.cineclub.title = this.DetailsFormGroup.value.nameCineclub || 'Pas de titre';
    if (this.DetailsFormGroup.value.numberCineclub !== null && this.DetailsFormGroup.value.numberCineclub !== undefined) {
      this.cineclub.numberOfCineclub = parseInt(this.DetailsFormGroup.value.numberCineclub, 10);
    } else {
      this.cineclub.numberOfCineclub = 0;
    }
    this.cineclub.begin = this.rangeFormGroup.value.start || new Date; 
    this.cineclub.end = this.rangeFormGroup.value.end || new Date; 
    this.cineclub.id_Cineclub = this.data;
    console.log("cineclub titre " + this.cineclub.title);
    console.log("cineclub debut " + this.cineclub.begin);
    console.log("cineclub fin " + this.cineclub.end);
    console.log("cineclub id 1" + this.cineclub.id_movie_1);
    console.log("cineclub id 2" + this.cineclub.id_movie_2);
    console.log("cineclub id 3" + this.cineclub.id_movie_3);
    console.log("cineclub id 4" + this.cineclub.id_movie_4);
    console.log("cineclub id 5 " + this.cineclub.id_movie_5);
    console.log("cineclub numero " + this.cineclub.numberOfCineclub);

    this.cineclubService.updateCineclub(this.cineclub).subscribe({
      next : (data : any) =>{
        console.log(data);
        this.dialog.closeAll()
      },
      error : (error) => {this.errorSnackBar.open(error,'Ok')}
    })
  }
}
