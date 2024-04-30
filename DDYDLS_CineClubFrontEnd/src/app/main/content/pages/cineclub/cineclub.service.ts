import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Cineclub } from 'src/app/models/cineclub';

@Injectable({
  providedIn: 'root'
})
export class CineclubService {

  public cineclubList : Cineclub[] = []
  public cineclub : Cineclub = new Cineclub();
  private _bookListUrl = 'https://localhost:44379/api/cineclub';
  constructor(private httpClient: HttpClient) { }

  getCineclub() : Observable<Cineclub[]> {
    return this.httpClient.get<Cineclub[]>(this._bookListUrl);
}
  getOneCineclub(id_cineclub :number) : Observable<Cineclub> {
  return this.httpClient.get<Cineclub>(this._bookListUrl +'/'+ id_cineclub);
}

  addCineclub(cineclub : Cineclub) : Observable<Cineclub> {
  this.cineclub = cineclub;
  console.log("cineclub qu'on envoit" + this.cineclub);
  console.log("cineclub qu'on envoit" + this.cineclub.begin);
  console.log("cineclub qu'on envoit" + this.cineclub.end);
  console.log("cineclub qu'on envoit" + this.cineclub.id_movie_1);
  console.log("cineclub qu'on envoit" + this.cineclub.id_movie_2);
  console.log("cineclub qu'on envoit" + this.cineclub.id_movie_3);
  console.log("cineclub qu'on envoit" + this.cineclub.id_movie_4);
  console.log("cineclub qu'on envoit" + this.cineclub.id_movie_5);
  console.log("cineclub qu'on envoit" + this.cineclub.numberOfCineclub);
  return this.httpClient.post<Cineclub>(this._bookListUrl, this.cineclub);
}
}
