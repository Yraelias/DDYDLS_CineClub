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
  

  constructor(private movie_service : MovieService, private activedRoute : ActivatedRoute) {
    this.id  = activedRoute.snapshot.params['id'];
   }

  ngOnInit(): void {
    console.log("sefjpoisjpfoijp<osejf");
    this.movie_service.getOneMovie(this.id).subscribe({
      next: (data :Movie) =>
      console.log(data)
    })
  }

}
