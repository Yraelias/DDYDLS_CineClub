import { Studio } from "./studio";

export class Movie {
    id_movie : number;
    name : string;
    id_studio : number;
    synopsis : string;
    year : number;
    studio : Studio;

    
    constructor(movie : Movie) {
     this.id_movie = movie.id_movie || 0;
     this.name = movie.name || 'null';
     this.id_studio = movie.id_studio || 0;
     this.synopsis = movie.synopsis || 'null';
     this.year = movie.year || 0;
     this.studio = movie.studio || 0;0
    }
}
