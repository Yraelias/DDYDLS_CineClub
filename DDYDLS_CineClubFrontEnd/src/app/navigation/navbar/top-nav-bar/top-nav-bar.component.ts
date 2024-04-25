import { useAnimation } from '@angular/animations';
import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { environment } from 'src/environments/environment';
import { SharedDataService } from '../../shared.service';

@Component({
  selector: 'app-top-nav-bar',
  templateUrl: './top-nav-bar.component.html',
  styleUrls: ['./top-nav-bar.component.scss']
})
export class TopNavBarComponent implements OnInit {
  isConnected:boolean
  Username:string | null

  constructor(private sharedDataService: SharedDataService) { 
  }

  ngOnInit(): void {
    this.loadSession();
    this.subscribeToChanges();
  }

  private loadSession() {
    if (sessionStorage.getItem('isConnected')) {
      this.isConnected = true;
      this.Username = sessionStorage.getItem('Username');
    }

    this.sharedDataService.barreTacheData$.subscribe((data) =>
    this.ngOnInit()
    )
  }

  private subscribeToChanges() {
    this.sharedDataService.barreTacheData$.subscribe((data) => {
      this.loadSession(); // Charge seulement l'état de la session sans souscrire de nouveau
    });
  } 

  clearSession(){
    console.log("on efface")
      this.isConnected = false;
      this.Username = null;
    sessionStorage.clear();
  }

}
