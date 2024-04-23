import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

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
  DesactivateAccount() :void{
    console.log ("je désactive")
  }
}
