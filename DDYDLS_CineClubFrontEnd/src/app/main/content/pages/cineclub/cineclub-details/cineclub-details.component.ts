import { Component, OnInit } from '@angular/core';
import { Cineclub } from 'src/app/models/cineclub';
import { CineclubService } from '../cineclub.service';

@Component({
  selector: 'app-cineclub-details',
  templateUrl: './cineclub-details.component.html',
  styleUrl: './cineclub-details.component.css'
})
export class CineclubDetailsComponent implements OnInit {
  
  cineclub : Cineclub
  cineclubService : CineclubService
  constructor(_cineclubService : CineclubService) {
    this.cineclubService = _cineclubService
   }

  ngOnInit(): void {
    throw new Error('Method not implemented.');
  }

}
