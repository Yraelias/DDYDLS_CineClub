import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { title } from 'process';
import { Observable } from 'rxjs';
import { User } from 'src/app/models/user';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  public user : User = new User
  private _Url = environment.apiurl + '/api/user';
  constructor(private httpClient: HttpClient) { }
  updateUsername(iD_User : number, username : string) : Observable<any>{
    console.log("Je change le pseudo en " +username )
    this.user.iD_User = iD_User;
    this.user.username = username;
    return this.httpClient.post<any>(this._Url+'/changeUsername',this.user)
  }
  updatePassword(iD_User: number, password : string) :Observable<any>{
    console.log (iD_User +'  '+password)
    this.user.iD_User = iD_User
    this.user.password = password
    return this.httpClient.post<any>(this._Url +'/changePassword',this.user);
  }
  DesactivateAccount(iD_User : number) :Observable<any>{
      return this.httpClient.get<void>(this._Url+'/Desactive/'+iD_User)
  }
}
