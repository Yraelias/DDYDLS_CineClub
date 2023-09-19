import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, Resolve, RouterStateSnapshot } from '@angular/router';
import { Observable } from 'rxjs';
import { Movie } from '../models/movie';
import { MovieService } from '../main/content/pages/movie.service';

@Injectable({
  providedIn: 'root'
})
export class MovieResolverService implements Resolve<Movie> {

  constructor(private _service : MovieService) { }
  resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot):  Observable<Movie> {
    return this._service.getOneMovie(route.params['id']);
  }
}

