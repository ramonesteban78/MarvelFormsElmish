module Characters

open Elmish.XamarinForms
open Elmish.XamarinForms.DynamicViews
open Xamarin.Forms


type Msg =
    | SelectedHero of Character.Model


let charactersView heroes (dispatch: Msg -> unit) = 
    match heroes with
    | Some characters ->
        match characters with
        | [] ->
            View.Label(
                text="No heroes found",
                horizontalOptions= LayoutOptions.Center,
                verticalOptions = LayoutOptions.Center
            )
        | _ ->
            View.ListView(
                 horizontalOptions = LayoutOptions.FillAndExpand,
                 verticalOptions = LayoutOptions.FillAndExpand,
                 separatorVisibility = SeparatorVisibility.None,
                 rowHeight=80,
                 itemTapped=(fun idx -> SelectedHero (characters.[idx]) |> dispatch),
                 items = [
                     for character in characters do
                         yield Character.view character
                 ])
    | None ->
        View.Label(
            text="Elmish Marvel Heroes",
            horizontalOptions= LayoutOptions.Center,
            verticalOptions = LayoutOptions.Center
        )

// View 
let view model dispatch = 
    dependsOn (model) (fun _ characters -> charactersView characters dispatch)

         