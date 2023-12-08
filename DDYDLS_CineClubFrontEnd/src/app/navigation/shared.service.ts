import { Injectable } from "@angular/core";
import { BehaviorSubject } from "rxjs";

@Injectable({
    providedIn: 'root',
  })
  export class SharedDataService {
    private topNavBar = new BehaviorSubject<string>('');
    barreTacheData$ = this.topNavBar.asObservable();
  
    updateBarreTacheData(data: string) {
      this.topNavBar.next(data);
    }
  }
  