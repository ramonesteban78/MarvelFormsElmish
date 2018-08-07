module SearchBar

open Elmish.XamarinForms
open Elmish.XamarinForms.DynamicViews

// Model

type Model = {
    Text : string
}

type Msg =
    | NewTextEntered of string


// Update

let init () = { Text = "" }, Cmd.none

let update msg model =
    match msg with
    | NewTextEntered text -> { model with Text = text },Cmd.none


// View

let view (model: Model) dispatch = 
      View.SearchBar(searchCommand = (fun searchBarText -> dispatch  (NewTextEntered (searchBarText))))