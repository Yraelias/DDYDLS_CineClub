import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Rating } from 'src/app/models/rating';
import { RatingService } from '../../rating/rating.service';

@Component({
  selector: 'app-commentary',
  templateUrl: './commentary.component.html',
  styleUrls: ['./commentary.component.css']
})
export class CommentaryCineclubComponent implements OnInit {
  id_cineclub : number;
  listRatings : Rating[];
  constructor(private _ratingService : RatingService,private activedRoute : ActivatedRoute ) {
    this.id_cineclub = activedRoute.snapshot.params['id'];
   }

  ngOnInit(): void {
    this.loadCommentary();
  }
  loadCommentary():void{
    this._ratingService.getRatingForMovie(this.id_cineclub).subscribe({
      next: (data:Rating[]) =>
      {
        this.listRatings = data;
        console.log(this.listRatings);
      }
    })
  }
}
