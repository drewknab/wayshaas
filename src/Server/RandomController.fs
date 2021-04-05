module Random

open System
open DataStorage
open Shared
open Saturn
open Microsoft.AspNetCore.Http

let random = Random()
let storage = Storage()

let messageIds messageType (messages : Message List) =
    messages
    |> List.filter (fun message -> message.Category = messageType)
    |> List.map (fun message -> message.Id)

let randomId (ids : string List) =
    List.item (random.Next(List.length ids)) ids

    //ids.[random.Next (ids.Length - 1)]

// Some error here
let randomNote (context : HttpContext) =
    let messages = storage.GetMessages()

    let id =
        messages
        |> messageIds "Waysh"
        |> randomId

    messages
    |> List.filter (fun message -> message.Id = id)
    |> Controller.json context

let randomController = controller {
    index randomNote
}