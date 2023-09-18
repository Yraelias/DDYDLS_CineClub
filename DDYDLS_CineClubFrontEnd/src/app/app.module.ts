import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { HomeComponent } from './main/content/pages/home/home.component';
import {RouterModule, Routes} from '@angular/router';
import { MoviesListComponent } from './main/content/pages/movie/list/movieslist.component';
import { HttpClientModule } from '@angular/common/http';
import { MovieService } from './main/content/pages/movie.service';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import {MatListModule} from '@angular/material/list';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {MatTableModule} from '@angular/material/table';
import {MatCardModule} from '@angular/material/card';


const appRoutes: Routes = [
  {
    path:'movies',
    component: MoviesListComponent,
    resolve: {data: MovieService}
  },
  {
    path: '**',
    component: HomeComponent
  }
  ];
   
@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    MoviesListComponent
  ],
  imports: [
    BrowserModule,
    RouterModule.forRoot(appRoutes),
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    MatListModule,
    BrowserAnimationsModule,
    MatTableModule,
    MatCardModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
