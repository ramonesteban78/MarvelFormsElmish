module MainView

open Elmish.XamarinForms
open Elmish.XamarinForms.DynamicViews


type Model = {
    SearchCharacterViewModel : SearchCharacterView.Model;
    DetailCharacterViewModel : DetailCharacterView.Model option
}

type Msg = 
    | SearchCharacterViewMsg of SearchCharacterView.Msg
    | DetailCharacterViewMsg of DetailCharacterView.Msg
    | NavigationPopped


let init() = 
    let searchViewModel, searchViewCmd = SearchCharacterView.init()
    { SearchCharacterViewModel = searchViewModel; DetailCharacterViewModel = None }, 
    Cmd.batch[Cmd.map SearchCharacterViewMsg searchViewCmd]

let update msg model = 
    match msg with
    | SearchCharacterViewMsg searchViewMsg -> 
        match searchViewMsg with
        | SearchCharacterView.SelectedHero msg ->
            match msg with
            | Characters.SelectedHero hero ->
                let detailViewModel, detailViewCmd = DetailCharacterView.init hero
                { model with DetailCharacterViewModel = Some detailViewModel }, Cmd.none
        | _ ->
            let searchViewModel, searchViewCmd = SearchCharacterView.update searchViewMsg model.SearchCharacterViewModel
            { model with SearchCharacterViewModel = searchViewModel }, Cmd.map SearchCharacterViewMsg searchViewCmd 
    | DetailCharacterViewMsg detailViewMsg ->
        let detailViewModel, detailViewCmd = DetailCharacterView.update detailViewMsg model.DetailCharacterViewModel
        { model with DetailCharacterViewModel = detailViewModel }, Cmd.map DetailCharacterViewMsg detailViewCmd 
    | NavigationPopped ->
        { model with DetailCharacterViewModel = None }, Cmd.none



let view (model: Model) dispatch =
    let searchView = SearchCharacterView.view model.SearchCharacterViewModel (SearchCharacterViewMsg >> dispatch)
    let detailView = 
        match model.DetailCharacterViewModel with
        | None -> None
        | Some detailModel -> Some (DetailCharacterView.view detailModel (DetailCharacterViewMsg >> dispatch))
    View.NavigationPage(
        popped=(fun _ -> NavigationPopped |> dispatch),
        pages = 
            match detailView with
            | None -> [searchView]
            | Some detail -> [searchView; detail]
    )