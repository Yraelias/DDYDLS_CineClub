import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Rating } from 'src/app/models/rating';

@Injectable({
  providedIn: 'root'
})
export class RatingService {
  
  public ratings : Rating[] = []
  public today = new Date();
  private _bookListUrl = 'https://localhost:44379/api/rating';
  constructor(private httpClient: HttpClient) { }
  
  postratingforMovie(Id_User : number, Id_Movie : number, rating : number ) : Observable<Rating> {
    
    return this.httpClient.post<Rating>('https://localhost:44379/api/rating/' , {
      Id_User : Id_User,
      Id_Movie : Id_Movie,
      date : this.today,
      rating : rating
  });
  }
}
