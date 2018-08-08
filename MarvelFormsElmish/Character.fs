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

let private getImageUrlUri imageUrl =
    Uri(imageUrl.path + "." + imageUrl.extension)


// View

let private imageSourceFromUri uri = 
    ImageSource.FromUri(uri)

let getImageSoure = 
    getImageUrlUri >> imageSourceFromUri 

let mkViewCell name imageSource =
    View.StackLayout(
           orientation = StackOrientation.Horizontal,
            children = [
                View.Image(source = imageSource, widthRequest = 80.0, heightRequest=80.0);
                View.Label(text = name, verticalOptions = LayoutOptions.Center)
            ])

let view (model: Model) = 
    dependsOn (model.name, getImageSoure model.thumbnail) (fun _ (name, imageSource) -> mkViewCell name imageSource)
    //model.thumbnail 
    //|> getImageSoure 
    //|> mkViewCell model.name 
