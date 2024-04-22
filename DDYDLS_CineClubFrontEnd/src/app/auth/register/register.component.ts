import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent implements OnInit {

  loginFG : FormGroup
  
  constructor(private _router : Router,private _builder : FormBuilder) {
    
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

}
