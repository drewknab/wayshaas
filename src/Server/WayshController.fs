module Waysh

open Saturn
open Shared
open DataStorage
open Microsoft.AspNetCore.Http

let storage = Storage()

let wayshNotes context =
    storage.GetMessages()
    |> List.filter (fun message -> message.Category = "Waysh")
    |> Controller.json context

let wayshNote (context : HttpContext) (id : string) =
    storage.GetMessage (id) ("Waysh")
    |> Controller.json context

let wayshController = controller {
    index wayshNotes
    show wayshNote
}