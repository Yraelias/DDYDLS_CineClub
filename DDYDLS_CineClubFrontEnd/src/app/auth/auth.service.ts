import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { User } from '../models/user';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  user = new LoginInfo()
  isConnected : boolean
  constructor(
    private _client : HttpClient
  ) { }

  login(email : string, password : string) : Observable<User>
  {
    this.user.email = email;
    this.user.password = password;
    this.isConnected = false;
    return this._client.post<User>(environment.apiurl+"/auth",this.user)
  }

  

  register(user:User):Observable<any>
  {
    console.log(user);
    console.log(environment.apiurl+"/user/");
    return this._client.post<User>(environment.apiurl+"/user",user);
  }

}
export class LoginInfo{
  email :string;
  password : string;
}