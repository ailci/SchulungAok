import { QotdService } from "./qotd-service.js";
import { QuoteOfTheDay } from "./quote-of-the-day.js";

export class QotdComponent {

    #qotdService = null;
    #qotdUI;
    #qotd;

    constructor(qotdUI) {
        this.#qotdUI = qotdUI;
        this.#qotdService = new QotdService();
    }

    async init() {
        let data = await this.#qotdService.getQotd();
        console.log(`Rückgabe von Service ${JSON.stringify(data)}`);

        this.#qotd = new QuoteOfTheDay(data);
        this.#renderUI();
    }

    #renderUI() {
        if (this.#qotd) {
            this.#qotdUI.authorPhotoEl.innerHTML = this.#qotd.authorPhotoMimeType
                ? `<img src='data:${this.#qotd.authorPhotoMimeType};base64,${this.#qotd.authorPhoto}' alt="Autor-Bild"/>`
                : "<img src='https://via.placeholder.com/150' alt=\"Autor-Bild\"/>";

            //Spruch
            this.#qotdUI.quoteTextEl.innerHTML = this.#qotd.quoteText;

            //Author-Info
            this.#qotdUI.authorNameEl.innerHTML = this.#qotd.authorName;
            this.#qotdUI.authorDescriptionEl.innerHTML = this.#qotd.authorDescription;

            const birthDate = this.#qotd.authorBirthdate
                ? new Intl.DateTimeFormat("de-DE", { month: "2-digit", day: "2-digit", year: "numeric" }).format(new Date(this.#qotd.authorBirthdate))
                : "k.A.";

            this.#qotdUI.authorBirthdateEl.innerHTML = birthDate;
        }
    }
}