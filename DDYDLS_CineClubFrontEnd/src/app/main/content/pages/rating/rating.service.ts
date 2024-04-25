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
  
  addRatingForMovie(iD_User : number, Id_Movie : number, rating : number, commentary:string, approbate : number ) : Observable<Rating> {
    console.log(iD_User)
    console.log(Id_Movie)
    console.log(rating)
    console.log(this.today)
    
    return this.httpClient.post<Rating>('https://localhost:44379/api/rating/' , {
      iD_User : iD_User,
      Id_Movie : Id_Movie,
      date : this.today,
      Ratings : rating,
      commentary : commentary,
      approbate : approbate
  });
  }

  updateRatingForMovie(iD_User : number, Id_Movie : number, rating : number, commentary:string, approbate : number ) : Observable<Rating> {
    console.log(iD_User)
    console.log(Id_Movie)
    console.log(rating)
    console.log(this.today)
    return this.httpClient.put<Rating>('https://localhost:44379/api/rating/' , {
      iD_User : iD_User,
      Id_Movie : Id_Movie,
      date : this.today,
      Ratings : rating,
      commentary : commentary,
      approbate : approbate
  });
  }

  getRatingForMovie(Id_Movie :number ) : Observable<Rating[]>{
    return this.httpClient.get<Rating[]>('https://localhost:44379/api/rating/movie/'+Id_Movie)
  }

  getRatingForUser(iD_User :number ) : Observable<Rating[]>{
    return this.httpClient.get<Rating[]>('https://localhost:44379/api/rating/user/'+iD_User)
  }

  getRatingForUserbyYear(iD_User :number, Year :number ) : Observable<Rating[]>{
    return this.httpClient.get<Rating[]>('https://localhost:44379/api/rating/user/year/'+iD_User+'/'+Year)
  }

  getRatingForUserbyMonth(Id_Movie :number, Month:number, Year:number ) : Observable<Rating[]>{
    return this.httpClient.get<Rating[]>('https://localhost:44379/api/rating/user/month/'+Id_Movie+'/'+ Month + '/'+Year)
  }
  
}
