module Router

open Giraffe
open Saturn
open Productivity
open Waysh
open Random

let webApp = router {
    // Some Error in this route
    get "/api/random" (json getRandom)
    forward "/api/productivity" productivityController
    forward "/api/waysh" wayshController
}