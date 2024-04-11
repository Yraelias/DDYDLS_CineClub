import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Cineclub } from 'src/app/models/cineclub';

@Injectable({
  providedIn: 'root'
})
export class CineclubService {

  public cineclub : Cineclub[] = []
  private _bookListUrl = 'https://localhost:44379/api/cineclub';
  constructor(private httpClient: HttpClient) { }

  getCineclub() : Observable<Cineclub[]> {
    return this.httpClient.get<Cineclub[]>(this._bookListUrl);
}
}
