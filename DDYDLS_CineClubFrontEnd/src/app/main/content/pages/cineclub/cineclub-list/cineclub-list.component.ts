import { Component, OnInit } from '@angular/core';
import { Cineclub } from 'src/app/models/cineclub';
import { CineclubService } from '../cineclub.service';
import { MovieService } from '../../movie.service';
import { Movie } from 'src/app/models/movie';
import { TMDBMovie, Result } from 'src/app/models/tmdbmovie';
import { ConfirmationDialogComponent } from '../confirmation-dialog/confirmation-dialog.component';
import { MatDialog } from '@angular/material/dialog';
import { CineclubUpdateComponent } from '../cineclub-update/cineclub-update.component';

@Component({
  selector: 'app-cineclub-list',
  templateUrl: './cineclub-list.component.html',
  styleUrl: './cineclub-list.component.css'
})
export class CineclubListComponent implements OnInit {
  cineclub : Cineclub[] = [];
  dataSource : any;
  tmdbmovie!: TMDBMovie;
  result !: Result; 
  URLimg:any = 'assets/icons/NotFound.webp';
  sameDate : boolean = false;
  isConnected:boolean = false;
  deleted : boolean = false;
  
  constructor(private _cineclubService : CineclubService, private movie_service : MovieService,public dialog: MatDialog) {
  }

  ngOnInit(): void {
    if (sessionStorage.getItem('isConnected'))
      {
        this.isConnected = true;
      }
   this.loadCineclub();
  }

  loadCineclub() : void{
    this._cineclubService.getCineclub().subscribe( {
      next: (data : Cineclub[]) =>  
        {
        this.cineclub = data;
            for (let i = 0; i< this.cineclub.length ; i++)
              {
              this.loadTMDBMovie_1(i,this.cineclub[i].movie_1.name)
              this.loadTMDBMovie_2(i,this.cineclub[i].movie_2.name)
              this.loadTMDBMovie_3(i,this.cineclub[i].movie_3.name)
              this.loadTMDBMovie_4(i,this.cineclub[i].movie_4.name)
              if(this.cineclub[i].movie_5 != null)
                {
                  this.loadTMDBMovie_5(i, this.cineclub[i].movie_5.name);
                }
              }
      },
      error : (error : any) => console.log(error)}
     )
  }
  loadTMDBMovie_1(i :number, titlemovie : string): void{
    let a  = 0;
    this.movie_service.getTMDBMovie(titlemovie).subscribe({
      next:(data :Result) =>
      {
        this.result = data;
        console.log(this.result)
        while(!this.sameDate && a < this.result.results.length)
          {
            if(this.cineclub[i].movie_1.year == parseInt(this.result.results[a].release_date.split('-')[0], 10))
              {
                if (this.result.results[a].poster_path != null) this.cineclub[i].movie_1.UrlIMG = "https://image.tmdb.org/t/p/w500/" + this.result.results[a].poster_path;
                else this.cineclub[i].movie_1.UrlIMG = this.URLimg;
                this.cineclub[i].movie_1.synopsis =  this.result.results[a].overview;
                this.sameDate = true;
              }
              a++;
          }
          this.sameDate = false;
      }
    })
  }

  loadTMDBMovie_2(i :number, titlemovie : string): void{
    let a  = 0;
    this.movie_service.getTMDBMovie(titlemovie).subscribe({
      next:(data :Result) =>
      {
        this.result = data;
        while(!this.sameDate && a < this.result.results.length)
          {
            if(this.cineclub[i].movie_2.year == parseInt(this.result.results[a].release_date.split('-')[0], 10))
              {
                if (this.result.results[a].poster_path != null) this.cineclub[i].movie_2.UrlIMG = this.cineclub[i].movie_2.UrlIMG = "https://image.tmdb.org/t/p/w500/" + this.result.results[a].poster_path;
                else this.cineclub[i].movie_2.UrlIMG = this.URLimg;        
                this.cineclub[i].movie_2.synopsis =  this.result.results[a].overview;
                this.sameDate = true;
              }
              a++;
          }
          this.sameDate = false;
      }
    })
  }

  loadTMDBMovie_3(i :number, titlemovie : string): void{
    let a  = 0;
    this.movie_service.getTMDBMovie(titlemovie).subscribe({
      next:(data :Result) =>
      {
        this.result = data;
        while(!this.sameDate && a < this.result.results.length)
          {
            if(this.cineclub[i].movie_3.year == parseInt(this.result.results[a].release_date.split('-')[0], 10))
              {
                if (this.result.results[a].poster_path != null) this.cineclub[i].movie_3.UrlIMG = this.cineclub[i].movie_3.UrlIMG = "https://image.tmdb.org/t/p/w500/" + this.result.results[a].poster_path;
                else this.cineclub[i].movie_3.UrlIMG = this.URLimg;         
                this.cineclub[i].movie_3.synopsis =  this.result.results[a].overview;
                this.sameDate = true;
              }
              a++;
          }
          this.sameDate = false;
      }
    })
  }

  loadTMDBMovie_4(i :number, titlemovie : string): void{
    let a  = 0;
    this.movie_service.getTMDBMovie(titlemovie).subscribe({
      next:(data :Result) =>
      {
        this.result = data;        
        while(!this.sameDate && a < this.result.results.length)
          {
            if(this.cineclub[i].movie_4.year == parseInt(this.result.results[a].release_date.split('-')[0], 10))
              {
                if (this.result.results[a].poster_path != null) this.cineclub[i].movie_4.UrlIMG = this.cineclub[i].movie_4.UrlIMG = "https://image.tmdb.org/t/p/w500/" + this.result.results[a].poster_path;
                else this.cineclub[i].movie_4.UrlIMG = this.URLimg;       
                this.cineclub[i].movie_4.synopsis =  this.result.results[a].overview;
                this.sameDate = true;
              }
              a++;
          }
          this.sameDate = false;
      }
    })
  }

  loadTMDBMovie_5(i :number, titlemovie : string): void{
    let a  = 0;
    this.movie_service.getTMDBMovie(titlemovie).subscribe({
      next:(data :Result) =>
      {
        this.result = data;        
        while(!this.sameDate && a < this.result.results.length)
          {
            if(this.cineclub[i].movie_5.year == parseInt(this.result.results[a].release_date.split('-')[0], 10))
              {
                if (this.result.results[a].poster_path != null) this.cineclub[i].movie_5.UrlIMG = this.cineclub[i].movie_5.UrlIMG = "https://image.tmdb.org/t/p/w500/" + this.result.results[a].poster_path;
                else this.cineclub[i].movie_5.UrlIMG = this.URLimg;       
                this.cineclub[i].movie_5.synopsis =  this.result.results[a].overview;
                this.sameDate = true;
              }
              a++;
          }
          this.sameDate = false;
      }
    })
  }

  openDeletDialog(id_cineclub : number): void {
    const dialogRef = this.dialog.open(ConfirmationDialogComponent,{
      width : '90%' 
    });

    dialogRef.afterClosed().subscribe(result => {
      this.deleted = result;
      if(this.deleted == true)
        {
          this._cineclubService.deleteCineclub(id_cineclub).subscribe(result =>{
            
          })
          
          window.location.reload();
        } 
    });
  }

  openUpdateDialog(id_cineclub : number): void {
    const dialogRef = this.dialog.open(CineclubUpdateComponent,{
      data:id_cineclub,
      width : '90%' 
    });

    dialogRef.afterClosed().subscribe(result => {          
          window.location.reload();
    });
  }


}
