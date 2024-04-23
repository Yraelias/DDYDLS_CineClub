import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { title } from 'process';
import { Observable } from 'rxjs';
import { User } from 'src/app/models/user';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  public user : User = new User
  private _Url = 'https://localhost:44379/api/user';
  constructor(private httpClient: HttpClient) { }
  updateUsername(username : string) : void{
    console.log("Je change le pseudo en " +username )
  }
  updatePassword(ID_User: number, password : string) :Observable<any>{
    console.log (ID_User +'  '+password)
    this.user.ID_User = ID_User
    this.user.password = password
    return this.httpClient.post<any>(this._Url +'/changePassword',this.user);
  }
  DesactivateAccount(ID_User : number) :Observable<any>{
      return this.httpClient.get<void>(this._Url+'/Desactive/'+ID_User)
  }
}
