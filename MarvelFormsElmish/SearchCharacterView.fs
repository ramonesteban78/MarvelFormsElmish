module SearchCharacterView

open Elmish.XamarinForms
open Elmish.XamarinForms.DynamicViews
open Newtonsoft.Json


// Model
type Model = {
    listOfHeroes : Characters.Model;
    searchText : string;
    searchingForHeroes : bool;
}

type Msg =
    | CharactersLoaded of Character.Model list
    | ExecuteSearch of string


let private loadCharacters text =
    async {
        let! response = MarvelApi.getCharacters text 0 0
        let marvelData = JsonConvert.DeserializeObject<MarvelTypes.MarvelApiResult<Character.Model>>(response)
        return CharactersLoaded marvelData.data.results 
    }

// Update
let init() = 
    { listOfHeroes = { Characters = None }; searchText = ""; searchingForHeroes = true }, Cmd.ofAsyncMsg(loadCharacters "")

let update msg model =
    match msg with
    | CharactersLoaded chars -> 
        { model with listOfHeroes = { Characters = Some chars }; searchingForHeroes = false }, Cmd.none
    | ExecuteSearch text -> 
       { model with searchText = text; searchingForHeroes = true }, Cmd.ofAsyncMsg(loadCharacters text)


// View
let view (model: Model) dispatch = 
    View.ContentPage(
        title="Marvel Heroes",
        content=View.Grid(
            rowdefs=["auto"; "*"],
            rowSpacing = 0.0,
            children=[
                (SearchBar.view dispatch ExecuteSearch).GridRow(0)
                (Characters.view model.listOfHeroes).GridRow(1)
                (LoadingControl.view model.searchingForHeroes).GridRow(0).GridRowSpan(2)
            ]))