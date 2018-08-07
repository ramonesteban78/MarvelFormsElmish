module Characters

open Elmish.XamarinForms
open Elmish.XamarinForms.DynamicViews
open Xamarin.Forms

let toTupleList listTuple =
     let firstList = listTuple |> List.map (fun (item1,_) -> item1)
     let secondList = listTuple |> List.map (fun (_,item2) -> item2)
     firstList, secondList 


// Model

type Model = {
    Characters : Character.Model list option
    }

//type Msg = 
    //| Selected of Character.Model
    //| CharactersLoaded
    //| NoCharactersToDisplay


// Update

//let initModel model = 
     //model |> List.map Character.init


//let init model =
    //match model with
    //| Some values -> 
    //    match values with
    //    | [] -> { Characters = None }, Cmd.ofMsg NoCharactersToDisplay
    //    | chars ->  { Characters = Some chars }, Cmd.ofMsg CharactersLoaded
    //| None -> { Characters = None }, Cmd.ofMsg NoCharactersToDisplay


//let updateModel model =
    //let characters = 
    //    model 
    //    |> List.map (fun char -> Character.update Character.Normal char) 
    //    |> toTupleList
    //match characters with
    //| ([],_) -> None
    //| (chars,cmds) -> Some chars


//let update msg model =
    //match msg with
    //| Selected character -> model, Cmd.ofMsg (Selected (character))
    //| CharactersLoaded -> init model.Characters
    //| NoCharactersToDisplay -> { model with Characters = None }, Cmd.none



// View 

let view (model: Model) = 
    match model.Characters with
    | Some characters ->
        View.ListView(
             horizontalOptions = LayoutOptions.FillAndExpand,
             verticalOptions = LayoutOptions.FillAndExpand,
             separatorVisibility = SeparatorVisibility.None,
             rowHeight=80,
             //itemTapped=(fun idx -> dispatch(Selected(characters.[idx]))),
             items = [
                 for character in characters do
                     yield Character.view character
             ])
    | None ->
        View.Label(
            text="No heroes found",
            horizontalOptions= LayoutOptions.Center,
            verticalOptions = LayoutOptions.Center
        )
         