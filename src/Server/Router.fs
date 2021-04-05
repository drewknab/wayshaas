module Router

open Saturn
open Productivity
open Waysh
open Random

let webApp = router {
    // Some Error in this route
    forward "/api/random" randomController
    forward "/api/productivity" productivityController
    forward "/api/waysh" wayshController
}