module MarvelApi

let private marveldns = "https://gateway.marvel.com/v1/public/"
let private marvelcredentials = "?ts=1&apikey=a81593164289ccb83f5f908ead89b163&hash=f413dc2ff725ee0c871141bf2acc4252"

let private getAsync (url:string) = 
    async {
        let httpClient = new System.Net.Http.HttpClient()
        let! response = httpClient.GetAsync(url) |> Async.AwaitTask
        response.EnsureSuccessStatusCode () |> ignore
        let! content = response.Content.ReadAsStringAsync() |> Async.AwaitTask
        return content
    }

let private addFilterToUrl filter url =
    match filter with
    | "" -> url
    | filter -> url + "&nameStartsWith=" + System.Net.WebUtility.UrlEncode(filter) 

let private addLimitToUrl limit url =
    match limit with
    | limit when limit > 0 -> url + "&limit=" + limit.ToString()
    | _ -> url

let private addOffsetToUrl offset url =
    match offset with
    | offset when offset > 0 -> url + "&offset=" + offset.ToString()
    | _ -> url


let getCharacters filter limit offset =
    marveldns + "characters" + marvelcredentials 
    |> addFilterToUrl filter
    |> addLimitToUrl limit
    |> addOffsetToUrl offset
    |> getAsync