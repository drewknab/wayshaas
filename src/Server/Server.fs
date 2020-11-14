module Server
open System
open Saturn
open Shared
open Giraffe
open DataStorage
open Router


let storage = Storage()

if storage.GetMessages() |> Seq.isEmpty then
    Migrations.messages |> List.iter (fun message -> storage.AddMessage(message) |> ignore)

let app =
    application {
        url "http://localhost:8085"
        use_router webApp
        memory_cache
        use_json_serializer (Thoth.Json.Giraffe.ThothSerializer())
        use_static "public"
        use_gzip
    }

run app
