import { Injectable } from '@angular/core';
import { Movie } from '../../../models/movie';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class MovieService {
  
  public movies : Movie[] = []
  private _bookListUrl = 'https://localhost:44379/api/movie';
  constructor(private httpClient: HttpClient) { }

  getMovies() : Observable<Movie[]> {
      return this.httpClient.get<Movie[]>('https://localhost:44379/api/movie');
  }
  getOneMovie(Id : number ) : Observable<Movie> {
    return this.httpClient.get<Movie>('https://localhost:44379/api/movie/'+Id);
}       
}
