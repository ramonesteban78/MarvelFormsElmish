module SearchCharacterView

open Elmish.XamarinForms
open Elmish.XamarinForms.DynamicViews
open Newtonsoft.Json


// Model

type Model = {
    listOfHeroes : Characters.Model;
}

type Msg =
    | CharactersLoaded of Character.Model list


let private loadCharacters text =
    async {
        let! response = MarvelApi.getCharacters text 0 0
        let marvelData = JsonConvert.DeserializeObject<MarvelTypes.MarvelApiResult<Character.Model>>(response)
        return CharactersLoaded marvelData.data.results 
    }


// Update
let init() = 
    { listOfHeroes = { Characters = None } }, Cmd.ofAsyncMsg(loadCharacters "")


let update msg model =
    match msg with
    | CharactersLoaded chars -> 
        { model with listOfHeroes = { Characters = Some chars }}, Cmd.none


// View
let view (model: Model) dispatch = 
    View.ContentPage(
        title="Marvel Heroes",
        content=View.Grid(
            rowdefs=["auto"; "*"],
            children=[
                (Characters.view model.listOfHeroes).GridRow(1)
            ]))