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
  return this.httpClient.post<Cineclub>(this._bookListUrl, this.cineclub);
}

  deleteCineclub(id_cineclub : number) : Observable<Cineclub> {
    return this.httpClient.delete<Cineclub>(this._bookListUrl+"/"+id_cineclub);
  }


}
