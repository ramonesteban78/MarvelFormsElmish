module Character

open System
open Elmish.XamarinForms.DynamicViews
open Xamarin.Forms

// Model

type ImageUrl = {
    path : string
    extension : string
} 
type Model = {
    id : int
    name : string
    description : string
    thumbnail : ImageUrl
}

//type Msg = 
    //| Normal
    //| Selected of Model

let private getImageUrlUri imageUrl =
    Uri(imageUrl.path + "." + imageUrl.extension)



// Update

//let initModel model =
 //{ id = model.id; name = model.name; description = model.description; thumbnail = model.thumbnail }

// Initial state for the control
//let init (model) = initModel model, Cmd.none

// Just return the same input model
//let update msg model =
    //match msg with
    //| Normal -> model, Cmd.none
    //| Selected character -> character, Cmd.ofMsg(Selected(character))



// View

let private imageSourceFromUri uri = 
    ImageSource.FromUri(uri)

let private getImageSoure = 
    getImageUrlUri >> imageSourceFromUri 

let mkViewCell name imageSource =
    View.ViewCell(
       view = View.StackLayout(
           orientation = StackOrientation.Horizontal,
            children = [
                View.Image(source = imageSource, widthRequest = 60.0, heightRequest=60.0);
                View.Label(text = name)
            ]))

let view (model: Model) = 
    //dependsOn (model.name, getImageSoure model.thumbnail) (fun _ (name, imageSource) -> mkViewCell name imageSource)
    model.thumbnail 
    |> getImageSoure 
    |> mkViewCell model.name 
