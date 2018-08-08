module DetailCharacterView

open Elmish.XamarinForms
open Elmish.XamarinForms.DynamicViews
open Xamarin.Forms

type Model = {
    Character : Character.Model
}

type Msg = 
    | Nothing


let init model = 
    { Character = model }, Cmd.none


let update msg model = 
    model, Cmd.none


let view (model:Model) dispatch = 
    View.ContentPage(
        title = model.Character.name,
        content = View.StackLayout(
            orientation = StackOrientation.Vertical,
            children = [
                View.Image(source = Character.getImageSoure model.Character.thumbnail)
                View.Label(text = model.Character.description)
            ]
        ))