import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Cineclub } from 'src/app/models/cineclub';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CineclubService {

  public cineclubList : Cineclub[] = []
  public cineclub : Cineclub = new Cineclub();
  private _cineclubUrl = environment.apiurl + '/api/cineclub';
  constructor(private httpClient: HttpClient) { }

  getCineclub() : Observable<Cineclub[]> {
    return this.httpClient.get<Cineclub[]>(this._cineclubUrl);
}
  getOneCineclub(id_cineclub :number) : Observable<Cineclub> {
  return this.httpClient.get<Cineclub>(this._cineclubUrl +'/'+ id_cineclub);
}

  addCineclub(cineclub : Cineclub) : Observable<Cineclub> {
  this.cineclub = cineclub;
  return this.httpClient.post<Cineclub>(this._cineclubUrl, this.cineclub);
}

  deleteCineclub(id_cineclub : number) : Observable<Cineclub> {
    return this.httpClient.delete<Cineclub>(this._cineclubUrl+"/"+id_cineclub);
  }

  updateCineclub(cineclub: Cineclub) : Observable<Cineclub>{
    this.cineclub = cineclub;
   return this.httpClient.put<Cineclub>(this._cineclubUrl+"/"+cineclub.id_Cineclub,cineclub);
  }
}
