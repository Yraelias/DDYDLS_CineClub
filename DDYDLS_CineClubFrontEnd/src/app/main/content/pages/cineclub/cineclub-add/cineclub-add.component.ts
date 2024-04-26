import { Component, OnInit } from '@angular/core';
import { CineclubService } from '../cineclub.service';
import { Cineclub } from 'src/app/models/cineclub';
import { Router } from '@angular/router';
import { error } from 'console';
import { MatSnackBar } from '@angular/material/snack-bar';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-cineclub-add',
  templateUrl: './cineclub-add.component.html',
  styleUrl: './cineclub-add.component.css'
})
export class CineclubAddComponent implements OnInit {

cineclubService : CineclubService;
cineclub : Cineclub;
errorSnackBar : MatSnackBar;
DetailsFormGroup = this._formBuilder.group({
  nameCineclub: ['', Validators.required],
  numberCineclub: ['', Validators.required],
});
rangeFormGroup = new FormGroup({
  start: new FormControl<Date | null>(null,Validators.required),
  end: new FormControl<Date | null>(null,Validators.required),
});
firstMovieFormGroup = this._formBuilder.group({
  movieName: ['', Validators.required],
});
secondMovieFormGroup = this._formBuilder.group({
  movie2Name: ['', Validators.required],
});
thirdMovieFormGroup = this._formBuilder.group({
  movie3Name: ['', Validators.required],
});
fourMovieFormGroup = this._formBuilder.group({
  movie4Name: ['', Validators.required],
});
bonusMovieFormGroup = this._formBuilder.group({
  movie5Name: ['', Validators.required],
});

constructor(_cineclubService : CineclubService, private _router : Router, _ErrorSnackbar : MatSnackBar,private _formBuilder: FormBuilder) {
  this.cineclubService = _cineclubService;
  this.errorSnackBar = _ErrorSnackbar;
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
}
