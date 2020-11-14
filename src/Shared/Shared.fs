module Shared

open System

// type MessageCategory = Productivity | Waysh | Holiday
type HolidayCategory = Full | Half

[<CLIMutable>]
type Message =
    {
        Id: string
        Message: string
        Image: string
        Category: string
    }

[<CLIMutable>]
type Holidays =
    {
        Month: int
        Day: int
        Category: HolidayCategory
        Title: string
    }
