module DataStorage

open LiteDB
open LiteDB.FSharp
open LiteDB.FSharp.Extensions
open Shared

type Storage () =
    let database =
        let mapper = FSharpBsonMapper()
        let connStr = "Filename=Message.db;mode=Exclusive"
        new LiteDatabase (connStr, mapper)

    let messages = database.GetCollection<Message>("messages")

    member _.GetMessages () =
        let all =
            messages.FindAll () |> List.ofSeq
        database.Dispose()
        all

    member _.GetMessage (id : string) (category : string) =
        let matchCategory (message : Message) (category : string) =
            match message.Category with
            | category -> true
            | _ -> false

        let one = messages.FindOne (fun message -> message.Id = id && matchCategory message category)
        database.Dispose()
        one

    member _.AddMessage (message : Message) =
        messages.Insert message |> ignore
        database.Dispose()
        Ok ()

    member _.Migration (migration : Message list) =
        let initialize = messages.FindAll () |> List.ofSeq
        if initialize.IsEmpty then
            migration |> List.iter (fun message -> messages.Insert message |> ignore)
        database.Dispose()
        Ok ()
