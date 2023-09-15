import { Injectable } from '@angular/core';
import { Movie } from './movie/movie';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class MovieService {
  
  public movies : Movie[] = []
  private _bookListUrl = 'https://localhost:44379/api/movie';
  constructor(private httpClient: HttpClient) { }

  getMovies()  {
    this.httpClient.get<Movie[]>(this._bookListUrl).subscribe(
      response => {
        this.movies = response;
        console.log(this.movies)
        return this.movies;
        });
  }
}
