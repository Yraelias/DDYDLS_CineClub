import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { Observable } from 'rxjs';
import { Movie } from '../models/movie';
import { MovieService } from '../main/content/pages/movie.service';

@Injectable({
  providedIn: 'root'
})
export class MovieResolverService  {

  constructor(private _service : MovieService) { }
  resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot):  Observable<Movie> {
    return this._service.getOneMovie(route.params['id'],1);
  }
}

