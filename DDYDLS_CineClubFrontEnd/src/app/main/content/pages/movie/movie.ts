export class Movie {
    Id_Movie : number;
    Name : string;
    Id_Studio : number;
    Synopsis : string;
    Year : number;

    
    constructor(movie : Movie) {
     this.Id_Movie = movie.Id_Movie;
     this.Name = movie.Name;
     this.Id_Studio = movie.Id_Studio;
     this.Synopsis = movie.Synopsis;
     this.Year = movie.Year;
    }
}
