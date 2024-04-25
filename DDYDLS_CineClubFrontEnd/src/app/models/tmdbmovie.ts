
export class TMDBMovie {
    
    adult : boolean;
    genre_id : number[];
    id : number;
    original_language : string;
    overview : string;
    popularity : number;
    id_movie : number;
    name : string;
    id_studio : number;
    synopsis : string;
    year : number;
    release_date : string;
    poster_path : string;
    title : string;
    original_title ?: string

    constructor(tmdbMovie : TMDBMovie) {
        
        this.adult = tmdbMovie.adult;
        this.genre_id = tmdbMovie.genre_id;
        this.id = tmdbMovie.id;
        this.original_language = tmdbMovie.original_language;
        this.overview = tmdbMovie.overview;
        this.popularity = tmdbMovie.popularity;
        this.id_movie = tmdbMovie.id_movie;
        this.name = tmdbMovie.name;
        this.id_studio = tmdbMovie.id_studio;
        this.synopsis = tmdbMovie.synopsis;
        this.year = tmdbMovie.year;
        this.release_date = tmdbMovie.release_date;
        this.poster_path = tmdbMovie.poster_path;
    }

}

export class Result{
    page : number;
    results : TMDBMovie[];

    constructor(result : Result){
        this.page = result.page;
        this.results = result.results;
    }
}