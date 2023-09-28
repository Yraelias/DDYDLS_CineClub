import { Component, OnInit } from '@angular/core';
import { MovieService } from '../../movie.service';
import { Movie } from 'src/app/models/movie';
import { ActivatedRoute } from '@angular/router';


@Component({
  selector: 'app-movie-details',
  templateUrl: './movie-details.component.html',
  styleUrls: ['./movie-details.component.css']
})
export class MovieDetailsComponent implements OnInit {
  id:number
  movie : Movie = {id_movie : 0, name : '', id_studio : 0, year:0, synopsis : '', studio : {Id_Country:0, Id_Studio:0, name:''} };

  constructor(private movie_service : MovieService, private activedRoute : ActivatedRoute) {
    this.id  = activedRoute.snapshot.params['id'];
   }

  ngOnInit(): void {
    this.loadMovie();
    console.log('ici');
    console.log(this.movie.name);
    console.log(this.movie);
    console.log(this.movie);
  }

  loadMovie():void{
    this.movie_service.getOneMovie(this.id).subscribe({
      next: (data :Movie) =>
      {
        console.log(data);
        this.movie = data;
      }
    })
  }

}
