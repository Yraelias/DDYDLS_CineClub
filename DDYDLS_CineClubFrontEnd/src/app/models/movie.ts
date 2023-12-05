import { Rating } from "./rating";

export class Movie {
    id_movie : number;
    name : string;
    id_studio : number;
    synopsis : string;
    year : number;
    rating : Rating;
    avgRating : number;
    ratingForUser : number;

    
    constructor(movie : Movie) {
     this.id_movie = movie.id_movie || 0;
     this.name = movie.name || 'null';
     this.id_studio = movie.id_studio || 0;
     this.synopsis = movie.synopsis || 'null';
     this.year = movie.year || 0;
     this.rating = movie.rating || 0;
     this.avgRating = movie.avgRating || 0;
     this.ratingForUser = movie.ratingForUser || 0;
    }
}
