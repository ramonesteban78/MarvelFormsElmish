module SearchBar

open Elmish.XamarinForms
open Elmish.XamarinForms.DynamicViews

let view dispatch msg = 
      View.SearchBar(
          placeholder = "Find your hero",
          searchCommand = (fun text -> dispatch (msg text))
          )