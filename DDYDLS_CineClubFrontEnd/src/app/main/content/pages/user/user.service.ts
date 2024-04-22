import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private _Url = 'https://localhost:44379/api/user';
  constructor(private httpClient: HttpClient) { }

  checkPassword() :void{}
  updatePassword() :void{}
  DesactivateAccount() :void{
    console.log ("je désactive")
  }
}
