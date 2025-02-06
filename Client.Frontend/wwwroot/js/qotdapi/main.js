import { QotdComponent } from "./qotd-component.js";


const qotdUI = {
    quoteTextEl: document.querySelector("#quote"),
    authorPhotoEl: document.querySelector("#author-photo"),
    authorNameEl: document.querySelector("#author-name"),
    authorDescriptionEl: document.querySelector("#author-description"),
    authorBirthdateEl: document.querySelector("#author-birthdate")
};

const qotd = new QotdComponent(qotdUI);
qotd.init();