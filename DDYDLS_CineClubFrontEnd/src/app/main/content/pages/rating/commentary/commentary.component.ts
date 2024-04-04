import { Component, OnInit } from '@angular/core';
import { RatingService } from '../rating.service';
import { ActivatedRoute } from '@angular/router';
import { Rating } from 'src/app/models/rating';

@Component({
  selector: 'app-commentary',
  templateUrl: './commentary.component.html',
  styleUrls: ['./commentary.component.css']
})
export class CommentaryComponent implements OnInit {
  id_movie : number;
  listRatings : Rating[];
  constructor(private _ratingService : RatingService,private activedRoute : ActivatedRoute ) {
    this.id_movie = activedRoute.snapshot.params['id'];
   }

  ngOnInit(): void {
    this.loadCommentary();
  }
  loadCommentary():void{
    this._ratingService.getRatingForMovie(this.id_movie).subscribe({
      next: (data:Rating[]) =>
      {
        this.listRatings = data;
        console.log(this.listRatings);
      }
    })
  }
}
