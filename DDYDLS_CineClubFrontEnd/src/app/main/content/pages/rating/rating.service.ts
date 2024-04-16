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
  constructor( private httpClient: HttpClient) { }
  
  addRatingForMovie(Id_User : number, Id_Movie : number, rating : number, commentary:string, approbate : number ) : Observable<Rating> {
    console.log(Id_User)
    console.log(Id_Movie)
    console.log(rating)
    console.log(this.today)
    
    return this.httpClient.post<Rating>('https://localhost:44379/api/rating/' , {
      Id_User : Id_User,
      Id_Movie : Id_Movie,
      date : this.today,
      Ratings : rating,
      commentary : commentary,
      approbate : approbate
  });
  }

  updateRatingForMovie(Id_User : number, Id_Movie : number, rating : number, commentary:string, approbate : number ) : Observable<Rating> {
    console.log(Id_User)
    console.log(Id_Movie)
    console.log(rating)
    console.log(this.today)
    return this.httpClient.put<Rating>('https://localhost:44379/api/rating/' , {
      Id_User : Id_User,
      Id_Movie : Id_Movie,
      date : this.today,
      Ratings : rating,
      commentary : commentary,
      approbate : approbate
  });
  }

  getRatingForMovie(Id_Movie :number ) : Observable<Rating[]>{
    console.log("test");
    return this.httpClient.get<Rating[]>('https://localhost:44379/api/rating/movie/'+Id_Movie)
  }

  
}
