module Behaviors
open System

let random = Random()

let messageIds messageType =
    Migrations.messages
    |> List.filter (fun message -> message.Category = messageType)
    |> List.map (fun message -> message.Id)

let randomId messageType =
    let ids = messageIds messageType
    ids.[random.Next (ids.Length - 1)]