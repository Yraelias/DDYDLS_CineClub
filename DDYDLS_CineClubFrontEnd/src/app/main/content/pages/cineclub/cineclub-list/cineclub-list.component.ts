import { Component } from '@angular/core';
import { Cineclub } from 'src/app/models/cineclub';
import { CineclubService } from '../cineclub.service';

@Component({
  selector: 'app-cineclub-list',
  standalone: true,
  imports: [],
  templateUrl: './cineclub-list.component.html',
  styleUrl: './cineclub-list.component.css'
})
export class CineclubListComponent {
  cineclub : Cineclub[] = [];
  dataSource : any;
  
  constructor(private _cineclubService : CineclubService) {}

  ngOnInit(): void {
    this.loadCineclub();
    console.log(this.cineclub);
  }

  loadCineclub() : void{
    this._cineclubService.getCineclub().subscribe( {
      next: (data : Cineclub[]) =>  {this.dataSource = data, console.log(data)},
      error : (error : any) => console.log(error)}
     )
     this._cineclubService.getCineclub();
    this.cineclub = this._cineclubService.cineclub
    this.dataSource = this.cineclub;
    console.log(this.dataSource)
  }

}
