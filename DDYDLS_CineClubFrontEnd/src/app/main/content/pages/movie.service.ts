import { Injectable } from '@angular/core';
import { Movie } from '../../../models/movie';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Result, TMDBMovie } from 'src/app/models/tmdbmovie';

@Injectable({
  providedIn: 'root'
})
export class MovieService {
  
  public movies : Movie[] = []
  private _bookListUrl =  'https://localhost:44379/api/movie';
  constructor(private httpClient: HttpClient) { }

  getMovies() : Observable<Movie[]> {
      return this.httpClient.get<Movie[]>('https://localhost:44379/api/movie');
  }
  getOneMovie(Id_User : number, Id_Movie : number ) : Observable<Movie> {
    return this.httpClient.get<Movie>('https://localhost:44379/api/movie/'+Id_User+'/'+Id_Movie);
  }
  getTMDBMovie(title : string ): Observable<Result>{
    return this.httpClient.get<Result>('https://api.themoviedb.org/3/search/movie?query='+ title +'&api_key=ba39746f310980f977035c97c2cfff66&language=fr');
  }
       
}