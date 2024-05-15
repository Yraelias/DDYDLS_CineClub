import { Injectable } from '@angular/core';
import { Movie } from '../../../models/movie';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Result, TMDBMovie } from 'src/app/models/tmdbmovie';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class MovieService {
  
  public movies : Movie[] = []
  public movie : Movie = new Movie;
  private _Url = environment.apiurl + '/api/movie';
  constructor(private httpClient: HttpClient) { }

  getMovies() : Observable<Movie[]> {
      return this.httpClient.get<Movie[]>( this._Url);
  }
  getOneMovie(iD_User : number, Id_Movie : number ) : Observable<Movie> {
    return this.httpClient.get<Movie>( this._Url +'/'+iD_User+'/'+Id_Movie);
  }
  getOneMovieVisitor(Id_Movie : number ) : Observable<Movie> {
    return this.httpClient.get<Movie>(this._Url+ '/'+Id_Movie);
  }
  getTMDBMovie(title : string ): Observable<Result>{
    return this.httpClient.get<Result>('https://api.themoviedb.org/3/search/movie?query='+ title +'&api_key=ba39746f310980f977035c97c2cfff66&language=fr');
  }
  addMovie(title : string, year : number, tmdbId : number):Observable<Movie>{
    this.movie.name = title;
    this.movie.year = year;
    this.movie.TMDB_Id = tmdbId;
    return this.httpClient.post<Movie>(this._Url, this.movie);
  }
       
}