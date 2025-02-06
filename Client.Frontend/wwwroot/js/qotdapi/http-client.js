
export class HttpClient {

    async get(url) {
        let response;

        try {
            response = await fetch(url);
            console.log(response);

        } catch (e) {
            console.error(e);
            throw e;
        }

        return response.json();
    }
}