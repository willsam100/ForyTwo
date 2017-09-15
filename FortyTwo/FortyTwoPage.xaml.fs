namespace FortyTwo

open Xamarin.Forms
open Xamarin.Forms.Xaml

// Alias for int. To help make it clear where the model is used
type Model = int

// Interface
type IDataLoaderService = 
    abstract member LoadData: unit -> Model

// Implementation of interface
type DataLoaderService() = 
    interface IDataLoaderService with 
        member this.LoadData() = 42

// View model with service as a constructor argument
type MainViewModel(_dataLoader: IDataLoaderService) = 
    member this.Data = _dataLoader.LoadData().ToString()

type FortyTwoPage() as this =
    inherit ContentPage()
    let _ = base.LoadFromXaml(typeof<FortyTwoPage>)
    do this.BindingContext <- MainViewModel(DataLoaderService())
