import { Rating } from "./rating";

export class Movie {
    id_Movie : number;
    name : string;
    id_Studio : number;
    synopsis : string;
    year : number;
    rating : Rating;
    avgRating : number;
    ratingForUser : number;

}
