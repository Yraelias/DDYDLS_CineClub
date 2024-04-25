import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../auth.service';
import { User } from 'src/app/models/user';
import { SharedDataService } from 'src/app/navigation/shared.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent implements OnInit {

  loginFG : FormGroup
  
  constructor(private _router : Router,private _builder : FormBuilder,private _authService : AuthService,private sharedDataService: SharedDataService) {
    
  }

  ngOnInit(): void {
    this.loginFG = this._builder.group({
      username : ['',Validators.required],
      email:['',[Validators.email, Validators.required]],
      password : ['',Validators.required],
      newpassword : ['',Validators.required],
      newpassword2 : ['',Validators.required]
    });
  }

  onSubmit() {
    const values = this.loginFG.value;
    this._authService.login(values['email'], values['newpassword']).subscribe({
      next: (data:User) => {
            if(data.iD_User != 0 || data.iD_User != null)
            {
              this._router.navigate(['/login']);
            }
            else { console.log("Erreur de log"), this._router.navigate(['/login']);}
            
          },
          error : (error) => {console.log(error)},
          
    })   
    }

}
