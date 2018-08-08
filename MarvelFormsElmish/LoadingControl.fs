module LoadingControl

open Elmish.XamarinForms
open Elmish.XamarinForms.DynamicViews
open Xamarin.Forms

// View
let view loading  = 
    View.ActivityIndicator(
        isRunning = loading,
        isVisible = loading,
        horizontalOptions = LayoutOptions.Center,
        verticalOptions = LayoutOptions.Center
        )