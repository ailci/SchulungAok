import { QotdService } from "./qotd-service.js";

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
        console.log(`Rückgabe von Service ${data}`);
    }
}