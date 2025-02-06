import { HttpClient } from "./http-client.js";

export class QotdService {
    #httpClient = new HttpClient();

    async getQotd() {
        console.log("getQotd aufgerufen...");

        return await this.#httpClient.get("https://localhost:7087/api/qotd");
    }
}