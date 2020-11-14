module Random

open System
open DataStorage
open Shared

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
let getRandom _ =
    let messages = storage.GetMessages()

    let id =
        messages
        |> messageIds "Waysh"
        |> randomId

    messages
    |> List.filter (fun message -> message.Id = id)
