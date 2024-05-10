import { Component, OnInit } from '@angular/core';
import { Cineclub } from 'src/app/models/cineclub';
import { CineclubService } from '../cineclub.service';
import { MovieService } from '../../movie.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-cineclub-details',
  templateUrl: './cineclub-details.component.html',
  styleUrl: './cineclub-details.component.css'
})
export class CineclubDetailsComponent implements OnInit {
  
  cineclub : Cineclub 
  cineclubService : CineclubService

  constructor(_cineclubService : CineclubService,private movie_service : MovieService, private activedRoute : ActivatedRoute) {
    this.cineclub = new Cineclub();
    this.cineclub.id_Cineclub = 0
    this.cineclub.id_Cineclub  = activedRoute.snapshot.params['id'];
    this.cineclubService = _cineclubService
   }


  ngOnInit(): void {
    console.log(this.cineclub.id_Cineclub)
    this.loadCineclub();
  }

  loadCineclub() : void{
    this.cineclubService.getOneCineclub(this.cineclub.id_Cineclub).subscribe( {
      next: (data : Cineclub) =>  
        {
        this.cineclub = data;
      error : (error : any) => console.log(error)}
     
  })}

}
