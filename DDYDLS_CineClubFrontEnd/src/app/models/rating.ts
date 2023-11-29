export class Rating {
    id_rating : number;
    id_movie : number;
    id_user : number;
    ratings : number;
    date : Date;

    
    constructor(rating : Rating) {
    this.id_rating = rating.id_rating;
     this.id_movie = rating.id_movie;
     this.id_user = rating.id_user;
     this.ratings = rating.ratings;
     this.date = rating.date;
    }
}
