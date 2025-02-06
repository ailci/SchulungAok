export class QuoteOfTheDay {
    constructor(data) {
        this.id = data.id;
        this.authorName = data.authorName;
        this.authorDescription = data.authorDescription;
        this.authorBirthdate = data.authorBirthdate;
        this.authorPhoto = data.authorPhoto;
        this.authorPhotoMimeType = data.authorPhotoMimeType;
        this.quoteText = data.quoteText;
    }
}