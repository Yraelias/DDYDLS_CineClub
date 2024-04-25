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
  user : User = new User
  
  constructor(private _router : Router,private _builder : FormBuilder,private _authService : AuthService,private sharedDataService: SharedDataService) {
    
  }

  ngOnInit(): void {
    this.loginFG = this._builder.group({
      username : ['',Validators.required],
      email:['',[Validators.email, Validators.required]],
      newpassword : ['',Validators.required],
      newpassword2 : ['',Validators.required]
    });
  }

  onSubmit() {
    if (this.loginFG.valid) {
      const values = this.loginFG.value;

      if (values['newpassword'] !== values['newpassword2']) {
          console.log("Les mots de passe ne correspondent pas");
          this.loginFG.setErrors({ passwordMismatch: true });
          return; 
      }

      this.user.email = values['email'];
      this.user.username = values['username'];
      this.user.password = values['newpassword'];
      this.user.iD_User = 1;

      this._authService.register(this.user).subscribe({
          next: (data: any) => {
              console.log(data);
          },
          error: (error) => {
              console.log(error);
          },
      });
  } else {
      console.log("Veuillez remplir tous les champs correctement.");
  }
}

}
