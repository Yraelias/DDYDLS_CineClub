
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { HomeComponent } from './main/content/pages/home/home.component';
import {RouterModule, Routes} from '@angular/router';
import { MoviesListComponent } from './main/content/pages/movie/list/movieslist.component';
import { HttpClientModule } from '@angular/common/http';
import { MovieService } from './main/content/pages/movie.service';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatListModule} from '@angular/material/list';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatTableDataSource,  MatTableModule} from '@angular/material/table';
import { MatCardModule} from '@angular/material/card';
import { MovieDetailsComponent } from './main/content/pages/movie/details/movie-details.component';
import { MovieResolverService } from './navigation/resolver.service';
import {MatGridListModule} from '@angular/material/grid-list';
import { MatMenuModule} from '@angular/material/menu';
import { MatButtonModule } from '@angular/material/button';
import { TopNavBarComponent } from './navigation/navbar/top-nav-bar/top-nav-bar.component';
import {MatIconModule} from '@angular/material/icon';
import {MatPaginator, MatPaginatorModule} from '@angular/material/paginator'; 
import { LoginComponent } from './auth/login/login.component';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule} from '@angular/material/input';
import { AuthService } from './auth/auth.service';
import { UserComponent } from './main/content/pages/user/Details/userDetails.component';
import { AuthGuardService } from './auth/auth-guard.service';
import { DialogAddorUpdateRatingComponent } from './main/content/pages/rating/AddOrUpdateRating/dialog-addor-update-rating.component';
import { MatDialogModule } from '@angular/material/dialog';
import { RatingService } from './main/content/pages/rating/rating.service';
import { CommentaryComponent } from './main/content/pages/rating/commentary/commentary.component';
import {MatToolbarModule} from '@angular/material/toolbar';
import { CineclubListComponent } from './main/content/pages/cineclub/cineclub-list/cineclub-list.component';
import { CineclubService } from './main/content/pages/cineclub/cineclub.service';
import { FooterComponent } from './navigation/footer/footer.component';
import { MovieAddComponent } from './main/content/pages/movie/add/movie-add.component';
import { SearchMovieComponent } from './main/content/pages/movie/search/search-movie.component';
import { ErrorSnackbarComponent } from './Snackbar/error-snackbar/error-snackbar.component';
import {MatSnackBarModule} from '@angular/material/snack-bar'
import { SettingsComponent } from './main/content/pages/user/settings/settings.component';
import { UserService } from './main/content/pages/user/user.service';
import { RegisterComponent } from './auth/register/register.component';
import { DesactivateDialogComponent } from './main/content/pages/user/desactivate-dialog/desactivate-dialog.component';
import { ChangePasswordComponent } from './main/content/pages/user/change-password/change-password.component';
import { ChangeUsernameComponent } from './main/content/pages/user/change-username/change-username.component';
import { SharedDataService } from './navigation/shared.service';
import { CineclubAddComponent } from './main/content/pages/cineclub/cineclub-add/cineclub-add.component';
import {MatStepperModule} from '@angular/material/stepper';
import {MatDatepickerModule} from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import { ConfirmationDialogComponent } from './main/content/pages/cineclub/confirmation-dialog/confirmation-dialog.component';
import { CineclubDetailsComponent } from './main/content/pages/cineclub/cineclub-details/cineclub-details.component';


const appRoutes: Routes = [
  {
    path:'connexion',
    component: LoginComponent,
    //resolve: {data: MovieService}
  },
  {
    path:'inscription',
    component: RegisterComponent
  },
  {
    path:'settings',
    component: SettingsComponent,
    canActivate :[AuthGuardService]
  },
  {
    path:'movies/add',
    component: MovieAddComponent,
    canActivate :[AuthGuardService]
  },
  {
    path:'movies/:id',
    component: MovieDetailsComponent,
    //resolve:{model: MovieResolverService}
  },
  {
    path:'movies',
    component: MoviesListComponent,
    //resolve: {data: MovieService}
  },
  {
    path:'cineclub/:id',
    component: CineclubDetailsComponent,
  },
  {
    path:'cineclub/add',
    component: CineclubAddComponent,
    canActivate :[AuthGuardService]
  },
  {
    path:'cineclub',
    component: CineclubListComponent,
    //canActivate :[AuthGuardService]
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
        CommentaryComponent,
        CineclubListComponent,
        FooterComponent,
        MovieAddComponent,
        SearchMovieComponent,
        ErrorSnackbarComponent,
        SettingsComponent,
        RegisterComponent,
        DesactivateDialogComponent,
        ChangePasswordComponent,
        ChangeUsernameComponent,
        CineclubAddComponent,
        ConfirmationDialogComponent,
        CineclubDetailsComponent
    ],
    providers: [MovieService, AuthService, AuthGuardService, RatingService,CineclubService,UserService,SharedDataService ],
    bootstrap: [AppComponent],
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
        MatToolbarModule,
        MatGridListModule,
        MatSnackBarModule,
        MatStepperModule,
        MatDatepickerModule,
        MatNativeDateModule
    ]
})
export class AppModule { }
