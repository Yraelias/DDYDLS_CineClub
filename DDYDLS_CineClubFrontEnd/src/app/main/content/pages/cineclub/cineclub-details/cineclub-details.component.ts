import { Component, OnInit } from '@angular/core';
import { Cineclub } from 'src/app/models/cineclub';
import { CineclubService } from '../cineclub.service';
import { MovieService } from '../../movie.service';
import { ActivatedRoute } from '@angular/router';
import { Result } from 'src/app/models/tmdbmovie';

@Component({
  selector: 'app-cineclub-details',
  templateUrl: './cineclub-details.component.html',
  styleUrl: './cineclub-details.component.css'
})
export class CineclubDetailsComponent implements OnInit {
  
  cineclub : Cineclub 
  cineclubService : CineclubService
  sameDate : boolean = false;
  result !: Result; 
  URLimg:any = 'assets/icons/NotFound.webp';
  isConnected : boolean

  constructor(_cineclubService : CineclubService,private movie_service : MovieService, private activedRoute : ActivatedRoute) {
    this.cineclub = new Cineclub();
    this.cineclub.id_Cineclub = 0
    this.cineclub.id_Cineclub  = activedRoute.snapshot.params['id'];
    this.cineclubService = _cineclubService
   }


  ngOnInit(): void {
    console.log(this.cineclub.id_Cineclub)
    this.loadCineclub();
  }

  loadCineclub() : void{
    this.cineclubService.getOneCineclub(this.cineclub.id_Cineclub).subscribe( {
      next: (data : Cineclub) =>  
        {
        this.cineclub = data;
        this.loadTMDBMovie_1(this.cineclub.movie_1.name);
        this.loadTMDBMovie_2(this.cineclub.movie_2.name);
        this.loadTMDBMovie_3(this.cineclub.movie_3.name);
        this.loadTMDBMovie_4(this.cineclub.movie_4.name);
      error : (error : any) => console.log(error)}
     
  })}

  loadTMDBMovie_1(titlemovie : string): void{
    let a  = 0;
    this.movie_service.getTMDBMovie(titlemovie).subscribe({
      next:(data :Result) =>
      {
        this.result = data;
        while(!this.sameDate && a < this.result.results.length)
          {
            if(this.cineclub.movie_1.year == parseInt(this.result.results[a].release_date.split('-')[0], 10))
              {
                if (this.result.results[a].poster_path != null) this.cineclub.movie_1.UrlIMG = "https://image.tmdb.org/t/p/w500/" + this.result.results[a].poster_path;
                else this.cineclub.movie_1.UrlIMG = this.URLimg;       
                this.cineclub.movie_1.synopsis =  this.result.results[a].overview;
                this.cineclub.movie_1.EN_name = this.result.results[a].original_title;
                this.sameDate = true;
              }
              a++;
          }
          this.sameDate = false;
      }
    })
  }

  loadTMDBMovie_2(titlemovie : string): void{
    let a  = 0;
    this.movie_service.getTMDBMovie(titlemovie).subscribe({
      next:(data :Result) =>
      {
        this.result = data;        
        while(!this.sameDate && a < this.result.results.length)
          {
            if(this.cineclub.movie_2.year == parseInt(this.result.results[a].release_date.split('-')[0], 10))
              {
                if (this.result.results[a].poster_path != null) this.cineclub.movie_2.UrlIMG = "https://image.tmdb.org/t/p/w500/" + this.result.results[a].poster_path;
                else this.cineclub.movie_2.UrlIMG = this.URLimg;               
                this.cineclub.movie_2.synopsis =  this.result.results[a].overview;
                this.cineclub.movie_2.EN_name = this.result.results[a].original_title;
                this.sameDate = true;
              }
              a++;
          }
          this.sameDate = false;
      }
    })
  }
 
  loadTMDBMovie_3(titlemovie : string): void{
    let a  = 0;
    this.movie_service.getTMDBMovie(titlemovie).subscribe({
      next:(data :Result) =>
      {
        this.result = data;
        this.URLimg = "https://image.tmdb.org/t/p/w500/" + this.result.results[0].poster_path;
        
        while(!this.sameDate && a < this.result.results.length)
          {
            if(this.cineclub.movie_3.year == parseInt(this.result.results[a].release_date.split('-')[0], 10))
              {
                if (this.result.results[a].poster_path != null) this.cineclub.movie_3.UrlIMG = "https://image.tmdb.org/t/p/w500/" + this.result.results[a].poster_path;
                else this.cineclub.movie_3.UrlIMG = this.URLimg;       
                this.cineclub.movie_3.UrlIMG = "https://image.tmdb.org/t/p/w500/" + this.result.results[a].poster_path;        
                this.cineclub.movie_3.synopsis =  this.result.results[a].overview;
                this.cineclub.movie_3.EN_name = this.result.results[a].original_title;
                this.sameDate = true;
              }
              a++;
          }
          this.sameDate = false;
      }
    })
  } 

  loadTMDBMovie_4(titlemovie : string): void{
    let a  = 0;
    this.movie_service.getTMDBMovie(titlemovie).subscribe({
      next:(data :Result) =>
      {
        this.result = data;
        this.URLimg = "https://image.tmdb.org/t/p/w500/" + this.result.results[0].poster_path;
        
        while(!this.sameDate && a < this.result.results.length)
          {
            if(this.cineclub.movie_4.year == parseInt(this.result.results[a].release_date.split('-')[0], 10))
              {
                if (this.result.results[a].poster_path != null) this.cineclub.movie_4.UrlIMG = "https://image.tmdb.org/t/p/w500/" + this.result.results[a].poster_path;
                else this.cineclub.movie_4.UrlIMG = this.URLimg;
                this.cineclub.movie_4.synopsis =  this.result.results[a].overview;
                this.cineclub.movie_4.EN_name = this.result.results[a].original_title;
                this.sameDate = true;
              }
              a++;
          }
          this.sameDate = false;
      }
    })
  }
}
