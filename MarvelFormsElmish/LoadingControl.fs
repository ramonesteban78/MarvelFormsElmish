module LoadingControl

open Elmish.XamarinForms
open Elmish.XamarinForms.DynamicViews
open Xamarin.Forms

// Model

type Model = {
    loading : bool
}

type Msg = 
    | Loading
    | NotLoading


// Update

let init() = { loading = false }, Cmd.none


let update msg model =
    match msg with
    | Loading -> {model with loading = true}, Cmd.none
    | NotLoading -> {model with loading = false}, Cmd.none

// View
let view (model: Model) dispatch = 
    View.ActivityIndicator(
        isRunning = model.loading,
        isVisible = model.loading,
        horizontalOptions = LayoutOptions.Center,
        verticalOptions = LayoutOptions.Center
        )