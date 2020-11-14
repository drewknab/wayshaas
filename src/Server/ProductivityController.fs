module Productivity

open Saturn
open Shared
open DataStorage
open Microsoft.AspNetCore.Http

let storage = Storage()

let filterMessages (message : Message) =
    match message.Category with
    | "Productivity" -> true
    | _ -> false

let productivityNotes context =
    storage.GetMessages()
    |> List.filter filterMessages
    |> Controller.json context

let productivityNote (context : HttpContext) (id : string) =
    storage.GetMessage (id) ("Productivity")
    |> Controller.json context

let productivityController = controller {
    index productivityNotes
    show productivityNote
}