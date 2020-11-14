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
    | ChangeMessages
    | RandomMessage

let fetchMessages(category) = Fetch.get<unit, Message list> (sprintf "/api/%s" category)

let init () =
    let model : Model =
        {
            Messages =
                [
                    {
                        Message = "Salad is not a soup, please focus on work."
                        Id = "1"
                        Image = "lyindrei.png"
                        Category = "Productivity"
                    }
                ]
            MessageType = "productivity"
        }
    let getMessages() = fetchMessages "productivity"
    let cmd = Cmd.OfPromise.perform getMessages () GotMessages
    model, cmd

let testMessage model =
    if model.MessageType = "waysh" then "productivity"
    else "waysh"

let update msg model =
    match msg with
    | GotMessages messages ->
        { model with Messages = messages}, Cmd.none
    | ChangeMessages ->
        let getMessages() = fetchMessages (testMessage model)
        let cmd = Cmd.OfPromise.perform getMessages () GotMessages
        { model with MessageType = testMessage model },  cmd
    | RandomMessage ->
        let getMessages() = fetchMessages "/random"
        let cmd = Cmd.OfPromise.perform getMessages () GotMessages
        { model with MessageType = testMessage model },  cmd

open Fable.React
open Fable.React.Props
open Fulma

let renderMessage (message : Message) =
    p [] [str message.Message]

let view model dispatch =
    let sortedMessages =
        model.Messages
        |> List.sortBy (fun message -> message.Id)
        |> List.map renderMessage

    Container.container [Container.IsFluid]
        [
            Content.content []
                [
                    h1 [][str "wayshaas"]
                    h2 [][str model.MessageType]
                    yield! sortedMessages
                    Button.a
                        [
                            Button.Color IsPrimary
                            //Button.Disabled (Todo.isValid model.Input |> not)
                            Button.OnClick (fun _ -> dispatch ChangeMessages)
                        ]
                        [ str (sprintf "go %s" (testMessage model)) ]

                ]
        ]

// // type Msg =
// //     | GotTodos of Todo list
// //     | SetInput of string
// //     | AddTodo
// //     | AddedTodo of Todo

// // let todosApi =
// //     Remoting.createApi()
// //     |> Remoting.withRouteBuilder Route.builder
// //     |> Remoting.buildProxy<ITodosApi>

// // let init(): Model * Cmd<Msg> =
// //     let model =
// //         { Todos = []
// //           Input = "" }
// //     let cmd = Cmd.OfAsync.perform todosApi.getTodos () GotTodos
// //     model, cmd

// let update (msg: Msg) (model: Model): Model * Cmd<Msg> =
//     match msg with
//     | GotTodos todos ->
//         { model with Todos = todos }, Cmd.none
//     | SetInput value ->
//         { model with Input = value }, Cmd.none
//     | AddTodo ->
//         let todo = Todo.create model.Input
//         let cmd = Cmd.OfAsync.perform todosApi.addTodo todo AddedTodo
//         { model with Input = "" }, cmd
//     | AddedTodo todo ->
//         { model with Todos = model.Todos @ [ todo ] }, Cmd.none

// open Fable.React
// open Fable.React.Props
// open Fulma

// let navBrand =
//     Navbar.Brand.div [ ] [
//         Navbar.Item.a [
//             Navbar.Item.Props [ Href "https://safe-stack.github.io/" ]
//             Navbar.Item.IsActive true
//         ] [
//             img [
//                 Src "/favicon.png"
//                 Alt "Logo"
//             ]
//         ]
//     ]

// let containerBox (model : Model) (dispatch : Msg -> unit) =
//     Box.box' [ ] [
//         Content.content [ ] [
//             Content.Ol.ol [ ] [
//                 for todo in model.Todos do
//                     li [ ] [ str todo.Description ]
//             ]
//         ]
//         Field.div [ Field.IsGrouped ] [
//             Control.p [ Control.IsExpanded ] [
//                 Input.text [
//                   Input.Value model.Input
//                   Input.Placeholder "What needs to be done?"
//                   Input.OnChange (fun x -> SetInput x.Value |> dispatch) ]
//             ]
//             Control.p [ ] [
//                 Button.a [
//                     Button.Color IsPrimary
//                     Button.Disabled (Todo.isValid model.Input |> not)
//                     Button.OnClick (fun _ -> dispatch AddTodo)
//                 ] [
//                     str "Add"
//                 ]
//             ]
//         ]
//     ]

// let view (model : Model) (dispatch : Msg -> unit) =
//     Hero.hero [
//         Hero.Color IsPrimary
//         Hero.IsFullHeight
//         Hero.Props [
//             Style [
//                 Background """linear-gradient(rgba(0, 0, 0, 0.5), rgba(0, 0, 0, 0.5)), url("https://unsplash.it/1200/900?random") no-repeat center center fixed"""
//                 BackgroundSize "cover"
//             ]
//         ]
//     ] [
//         Hero.head [ ] [
//             Navbar.navbar [ ] [
//                 Container.container [ ] [ navBrand ]
//             ]
//         ]

//         Hero.body [ ] [
//             Container.container [ ] [
//                 Column.column [
//                     Column.Width (Screen.All, Column.Is6)
//                     Column.Offset (Screen.All, Column.Is3)
//                 ] [
//                     Heading.p [ Heading.Modifiers [ Modifier.TextAlignment (Screen.All, TextAlignment.Centered) ] ] [ str "wayshaas" ]
//                     containerBox model dispatch
//                 ]
//             ]
//         ]
//     ]
