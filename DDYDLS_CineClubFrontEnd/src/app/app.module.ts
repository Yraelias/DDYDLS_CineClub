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
import {MatTableDataSource, MatTableModule} from '@angular/material/table';
import {MatCardModule} from '@angular/material/card';
import { MovieDetailsComponent } from './main/content/pages/movie/details/movie-details.component';
import { MovieResolverService } from './navigation/resolver.service';
import {MatGridListModule} from '@angular/material/grid-list';
import {MatMenuModule} from '@angular/material/menu';
import { MatButtonModule } from '@angular/material/button';
import { TopNavBarComponent } from './navigation/navbar/top-nav-bar/top-nav-bar.component';
import {MatIconModule} from '@angular/material/icon';
import {MatPaginator, MatPaginatorModule} from '@angular/material/paginator'; 
import { LoginComponent } from './auth/login/login.component';
import { MatFormFieldModule } from '@angular/material/form-field';
import {MatInputModule} from '@angular/material/input';
import { AuthService } from './auth/auth.service';
import { UserComponent } from './main/content/pages/user/user.component';
import { AuthGuardService } from './auth/auth-guard.service';
import { DialogAddorUpdateRatingComponent } from './main/content/pages/rating/AddOrUpdateRating/dialog-addor-update-rating.component';
import { MatDialogModule } from '@angular/material/dialog';
import { RatingService } from './main/content/pages/rating/rating.service';


const appRoutes: Routes = [
  {
    path:'connexion',
    component: LoginComponent,
    //resolve: {data: MovieService}
  },
  {
    path:'movies/:id',
    component: MovieDetailsComponent,
    resolve:{model: MovieResolverService}
  },
  {
    path:'movies',
    component: MoviesListComponent,
    //resolve: {data: MovieService}
  },
  {
    path:'user',
    component: UserComponent,
    canActivate :[AuthGuardService]
  },
  {
    path: '**',
    component: HomeComponent
  }
  ];
   
@NgModule({
  declarations: [
    AppComponent,
    TopNavBarComponent,
    HomeComponent,
    MoviesListComponent,
    MovieDetailsComponent,
    LoginComponent,
    UserComponent,
    DialogAddorUpdateRatingComponent
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
    MatCardModule,
    MatGridListModule,
    MatMenuModule,
    MatButtonModule,
    MatIconModule,
    MatPaginatorModule,
    MatIconModule,
    MatFormFieldModule,
    MatInputModule,
    MatDialogModule 
  ],
  providers: [MovieService,AuthService,AuthGuardService,RatingService],
  bootstrap: [AppComponent]
})
export class AppModule { }
