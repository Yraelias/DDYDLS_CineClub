import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../auth.service';
import { User } from 'src/app/models/user';
import { SharedDataService } from 'src/app/navigation/shared.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {


  loginFG : FormGroup 
  loginError : string

  constructor(
    private _builder : FormBuilder,
    private _authService : AuthService,
    private _router : Router,
    private sharedDataService: SharedDataService
  ) { }

  ngOnInit(): void {
    this.loginFG = this._builder.group({
      email:['',[Validators.email, Validators.required]],
      password : ['',Validators.required]
    });
  }
  onSubmit() {
    const values = this.loginFG.value;
    console.log(values)
    this._authService.login(values['email'], values['password']).subscribe({
      next: (data:User) => {
            if(data.iD_User != 0 || data.iD_User != null)
            {
              sessionStorage.setItem('token',data.token);
              sessionStorage.setItem('id' , data.iD_User.toString());
              sessionStorage.setItem('isAdmin',data.isAdministrator.toString());
              sessionStorage.setItem('isConnected',"True");
              sessionStorage.setItem('Username',data.username);
              this.sharedDataService.setLoggedIn(true)
              this.sharedDataService.setUsername(data.username)
              this._router.navigate(['/user']);
              console.log(data);

            }
            else { console.log("Erreur de log"), this._router.navigate(['/login']);}
            
          },
          error : (error) => {console.log(error), this.loginError = error.error.message},
          
    })   
    }
}
