module Index

open Elmish
open Thoth.Fetch
open Shared

type Model =
    {
        Messages: Message list
        MessageType: string
    }

type Msg =
    | GotMessages of Message list
    | ProductivityMessages
    | WayshMessages
    | RandomMessage

let fetchMessages(category) = Fetch.get<unit, Message list> (sprintf "/api/%s" category)

let init () =
    let model : Model =
        {
            Messages =
                [
                    {
                        Message = "Loading"
                        Id = "0"
                        Image = ""
                        Category = "Productivity"
                    }
                ]
            MessageType = "productivity"
        }

    let getMessages() = fetchMessages "random"

    let cmd = Cmd.OfPromise.perform getMessages () GotMessages

    model, cmd

let testMessage model =
    model.Messages.[0].Category

let handleCommand messages =
    Cmd.OfPromise.perform messages () GotMessages

let update msg model =
    match msg with
    | GotMessages messages ->
        { model with Messages = messages ; MessageType = messages.[0].Category }, Cmd.none
    | WayshMessages ->
        let getMessages() = fetchMessages "waysh"
        let cmd = Cmd.OfPromise.perform getMessages () GotMessages
        { model with MessageType = "Waysh" },  cmd
    | ProductivityMessages ->
        let getMessages() = fetchMessages "productivity"
        let cmd = Cmd.OfPromise.perform getMessages () GotMessages
        { model with MessageType = "Productivity" },  cmd
    | RandomMessage ->
        let getMessages() = fetchMessages "random"
        let cmd = Cmd.OfPromise.perform getMessages () GotMessages
        { model with MessageType = testMessage model },  cmd

open Fable.React
open Fable.React.Props
open Fulma

let renderMessage (message : Message) =
    p [] [str message.Message]

let renderButton dispatch dispatchMessage text =
    Button.a
        [
            Button.Color IsPrimary
            Button.OnClick (fun _ -> dispatch dispatchMessage)
        ]
        [ str (sprintf "%s" text) ]

let view model dispatch =
    let sortedMessages =
        model.Messages
        |> List.sortBy (fun message -> message.Id)
        |> List.map renderMessage

    Container.container []
        [
            Content.content [Content.Option.Modifiers [Modifier.TextAlignment (Screen.All, TextAlignment.Centered)]]
                [
                    h1 [] [str "wayshaas"]
                    Columns.columns [ Columns.IsCentered ]
                        [
                            Column.column []
                                [
                                    yield renderButton dispatch ProductivityMessages "show all productivity"
                                ]
                            Column.column []
                                [
                                    yield renderButton dispatch RandomMessage "random"
                                ]
                            Column.column []
                                [
                                    yield renderButton dispatch WayshMessages "show all waysh"
                                ]

                        ]
                    h2 [][str model.MessageType]
                    Text.p [
                        Modifiers [
                            Modifier.TextAlignment (Screen.All, TextAlignment.Centered)
                        ]

                    ]
                        [yield! sortedMessages]

                ]
        ]
