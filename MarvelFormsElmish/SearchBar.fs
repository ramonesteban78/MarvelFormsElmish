module SearchBar

open Elmish.XamarinForms
open Elmish.XamarinForms.DynamicViews

// Model

type Model = {
    Text : string
}

//type Msg =
    //| ExecuteSearch of string


//// Update

//let init () = { Text = "" }, Cmd.none

//let update msg model =
    //match msg with
    //| ExecuteSearch text -> { model with Text = text },Cmd.none

// View

let view dispatch msg = 
      View.SearchBar(
          placeholder = "Find your hero",
          searchCommand = (fun text -> dispatch (msg text))
          )