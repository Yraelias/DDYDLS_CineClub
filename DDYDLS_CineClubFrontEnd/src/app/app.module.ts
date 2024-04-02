import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { HomeComponent } from './main/content/pages/home/home.component';
import {RouterModule, Routes} from '@angular/router';
import { MoviesListComponent } from './main/content/pages/movie/list/movieslist.component';
import { HttpClientModule } from '@angular/common/http';
import { MovieService } from './main/content/pages/movie.service';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import {MatLegacyListModule as MatListModule} from '@angular/material/legacy-list';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {MatLegacyTableDataSource as MatTableDataSource, MatLegacyTableModule as MatTableModule} from '@angular/material/legacy-table';
import {MatLegacyCardModule as MatCardModule} from '@angular/material/legacy-card';
import { MovieDetailsComponent } from './main/content/pages/movie/details/movie-details.component';
import { MovieResolverService } from './navigation/resolver.service';
import {MatGridListModule} from '@angular/material/grid-list';
import {MatLegacyMenuModule as MatMenuModule} from '@angular/material/legacy-menu';
import { MatLegacyButtonModule as MatButtonModule } from '@angular/material/legacy-button';
import { TopNavBarComponent } from './navigation/navbar/top-nav-bar/top-nav-bar.component';
import {MatIconModule} from '@angular/material/icon';
import {MatLegacyPaginator as MatPaginator, MatLegacyPaginatorModule as MatPaginatorModule} from '@angular/material/legacy-paginator'; 
import { LoginComponent } from './auth/login/login.component';
import { MatLegacyFormFieldModule as MatFormFieldModule } from '@angular/material/legacy-form-field';
import {MatLegacyInputModule as MatInputModule} from '@angular/material/legacy-input';
import { AuthService } from './auth/auth.service';
import { UserComponent } from './main/content/pages/user/user.component';
import { AuthGuardService } from './auth/auth-guard.service';
import { DialogAddorUpdateRatingComponent } from './main/content/pages/rating/AddOrUpdateRating/dialog-addor-update-rating.component';
import { MatLegacyDialogModule as MatDialogModule } from '@angular/material/legacy-dialog';
import { RatingService } from './main/content/pages/rating/rating.service';
import { CommentaryComponent } from './main/content/pages/movie/commentary/commentary.component';
import {MatToolbarModule} from '@angular/material/toolbar';


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
    DialogAddorUpdateRatingComponent,
    CommentaryComponent
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
    MatDialogModule,
    MatToolbarModule
  ],
  providers: [MovieService,AuthService,AuthGuardService,RatingService],
  bootstrap: [AppComponent]
})
export class AppModule { }
