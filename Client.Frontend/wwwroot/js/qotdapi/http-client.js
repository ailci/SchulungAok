
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

    async getWithApiKey(url, apikey) {
        let response;

        try {
            response = await fetch(url, {
                headers: { "x-api-key": `${apikey}` }
            });
            console.log(response);

        } catch (e) {
            console.error(e);
            throw e;
        }

        return response.json();
    }
}