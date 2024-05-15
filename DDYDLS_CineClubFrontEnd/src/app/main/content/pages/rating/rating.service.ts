import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Rating } from 'src/app/models/rating';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class RatingService {
  
  public ratings : Rating[] = []
  public today = new Date();
  private _Url = environment.apiurl + '/api/rating';
  constructor( private httpClient: HttpClient) { }
  
  addRatingForMovie(iD_User : number, Id_Movie : number, rating : number, commentary:string, approbate : number ) : Observable<Rating> {
    return this.httpClient.post<Rating>(this._Url  , {
      iD_User : iD_User,
      Id_Movie : Id_Movie,
      date : this.today,
      Ratings : rating,
      commentary : commentary,
      approbate : approbate
  });
  }

  updateRatingForMovie(iD_User : number, Id_Movie : number, rating : number, commentary:string, approbate : number ) : Observable<Rating> {
    return this.httpClient.put<Rating>(this._Url, {
      iD_User : iD_User,
      Id_Movie : Id_Movie,
      date : this.today,
      Ratings : rating,
      commentary : commentary,
      approbate : approbate
  });
  }

  getRatingForMovie(Id_Movie :number ) : Observable<Rating[]>{
    return this.httpClient.get<Rating[]>(this._Url + '/movie/'+Id_Movie)
  }

  getRatingForUser(iD_User :number ) : Observable<Rating[]>{
    return this.httpClient.get<Rating[]>(this._Url + '/user/'+iD_User)
  }

  getRatingForUserbyYear(iD_User :number, Year :number ) : Observable<Rating[]>{
    return this.httpClient.get<Rating[]>(this._Url + '/user/year/'+iD_User+'/'+Year)
  }

  getRatingForUserbyMonth(Id_Movie :number, Month:number, Year:number ) : Observable<Rating[]>{
    return this.httpClient.get<Rating[]>(this._Url + '/user/month/'+Id_Movie+'/'+ Month + '/'+Year)
  }

  getRatingForCineclub(id_Cineclub : number){
    return this.httpClient.get<Rating[]>(this._Url + '/cineclub/'+id_Cineclub)
  }
  
}
