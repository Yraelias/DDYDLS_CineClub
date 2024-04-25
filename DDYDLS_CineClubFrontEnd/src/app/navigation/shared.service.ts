import { Injectable } from "@angular/core";
import { BehaviorSubject, Subject } from "rxjs";

@Injectable({
    providedIn: 'root',
  })
  export class SharedDataService {
  
    loggedIn = new BehaviorSubject<boolean>(false);
    isAdmin = new BehaviorSubject<boolean>(false);
    username = new BehaviorSubject<string>('');
    private barreTacheDataSubject = new Subject<void>(); // Sujet pour notifier les changements
  
    constructor() { }
  
  setLoggedIn(value: boolean) {
    this.loggedIn.next(value);
    if (value) {
      sessionStorage.setItem('isConnected', 'True');
    }
    this.barreTacheDataSubject.next(); // Émet une nouvelle valeur
  }

  setIsAdmin(value: boolean) {
    this.isAdmin.next(value);
    this.barreTacheDataSubject.next(); // Émet une nouvelle valeur
  }

  setUsername(value: string) {
    if (!this.username.value) {
      sessionStorage.setItem('username', value);
    }
    this.username.next(value);
    this.barreTacheDataSubject.next(); // Émet une nouvelle valeur
  }

  get barreTacheData$() {
    return this.barreTacheDataSubject.asObservable();
  }
  }
  