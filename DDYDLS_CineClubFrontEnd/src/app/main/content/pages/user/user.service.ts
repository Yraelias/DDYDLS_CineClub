import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private _Url = 'https://localhost:44379/api/user';
  constructor(private httpClient: HttpClient) { }
  updateUsername(username : string) : void{
    console.log("Je change le pseudo en " +username )
  }
  updatePassword(password : string) :void{
    console.log("je change les mdp en " +password);
  }
  DesactivateAccount(id_User : number) :Observable<any>{
      return this.httpClient.get<void>(this._Url+'/Desactive/'+id_User)
  }
}
