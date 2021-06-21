module Random

open System
open DataStorage
open Shared
open Saturn
open Microsoft.AspNetCore.Http

let random = Random()
let storage = Storage()
let messageType = ["Waysh" ; "Productivity"]

let messageIds messageType (messages : Message List) =
    messages
    |> List.filter (fun message -> message.Category = messageType)
    |> List.map (fun message -> message.Id)

let randomId (list : string List) =
    List.item (random.Next(List.length list)) list

let randomNote (context : HttpContext) =
    let messages = storage.GetMessages()

    let id =
        messages
        |> messageIds (randomId messageType)
        |> randomId

    messages
    |> List.filter (fun message -> message.Id = id)
    |> Controller.json context

let randomController = controller {
    index randomNote
}
