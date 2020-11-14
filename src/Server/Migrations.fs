module Migrations

open Shared

let messages =
    [
        {
            Message = "Salad is not a soup, please focus on work."
            Id = "1"
            Image = "lyindrei.png"
            Category = "Productivity"
        };
        {
            Message = "Please focus on actually working and not slacking."
            Id = "2"
            Image = "lyindrei.png"
            Category = "Productivity"
        };
        {
            Message = "slack <img src='/images/snowflake.png'>"
            Id = "3"
            Image = "lyindrei.png"
            Category = "Productivity"
        };
        {
            Message = "Slack === slacking"
            Id = "4"
            Image = "lyindrei.png"
            Category = "Productivity"
        };
        {
            Message = "Slack === slacking"
            Id = "5"
            Image = "lyindrei.png"
            Category = "Productivity"
        };
        {
            Message = "too much dank, not enough codez"
            Id = "6"
            Image = "teledrei.png"
            Category = "Productivity"
        };
        {
            Message = "stfu - Jan 3rd, 2019 10:39:48 AM"
            Id = "7"
            Image = "lyindrei.png"
            Category = "Productivity"
        };
        {
            Message = "You must be buffalo sports, because you’re constantly disappointing me"
            Id = "8"
            Image = "joef_face.png"
            Category = "Productivity"
        };
        {
            Message = "stop me if i’m git-splain’in… but"
            Id = "9"
            Image = "joef_official.PNG"
            Category = "Productivity"
        };
        {
            Message = "ha, so cool"
            Id = "10"
            Image = "teledrei.PNG"
            Category = "Productivity"
        };
        {
            Message = "What are you sleeping here?"
            Id = "11"
            Image = "casterdrei.jpg"
            Category = "Waysh"
        };
        {
            Message = "Did you bring a tent?"
            Id = "12"
            Image = "casterdrei.jpg"
            Category = "Waysh"
        };
        {
            Message = "You gonna take down the cot?"
            Id = "13"
            Image = "casterdrei.jpg"
            Category = "Waysh"
        };
        {
            Message = "Aren't you going to put away the sleeping bag?"
            Id = "14"
            Image = "casterdrei.jpg"
            Category = "Waysh"
        };
        {
            Message = "Working after 5 PM? Fake news."
            Id = "15"
            Image = "casterdrei.jpg"
            Category = "Waysh"
        };
        {
            Message = "What are you sleeping here?"
            Id = "16"
            Image = "joef_face.png"
            Category = "Waysh"
        };
        {
            Message = "Did you bring a tent?"
            Id = "17"
            Image = "joef_face.png"
            Category = "Waysh"
        };
        {
            Message = "Nice camping setup you got there."
            Id = "18"
            Image = "joef_face.png"
            Category = "Waysh"
        };
        {
            Message = "You got a sleeping bag under your desk?"
            Id = "19"
            Image = "joef_face.png"
            Category = "Waysh"
        };
        {
            Message = "WOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO"
            Id = "20"
            Image = "joef_face.png"
            Category = "Waysh"
        };
        {
            Message = "That B, Waysh"
            Id = "21"
            Image = "Waysh_biatch.png"
            Category = "Waysh"
        };
        {
            Message = "get off your puters people, get some sun"
            Id = "22"
            Image = "teledrei.png"
            Category = "Holiday"
        };
        {
            Message = "It's the weekend, mute Slack."
            Id = "23"
            Image = "casterdrei.png"
            Category = "Holiday"
        };
    ]

let holidays =
    [
        {
            Month = 1
            Day = 17
            Category = Full
            Title = "a half day for Martin Luther King Jr. Day"
        };
        {
            Month = 1
            Day = 20
            Category = Full
            Title = "Martin Luther King Jr. Day"
        };
        {
            Month = 2
            Day = 14
            Category = Half
            Title = "a half day for President's Day"
        };
        {
            Month = 2
            Day = 17
            Category = Full
            Title = "President's Day"
        };
        {
            Month = 4
            Day = 10
            Category = Full
            Title = "Good Friday"
        };
        {
            Month = 5
            Day = 22
            Category = Half
            Title = "a half day for Memorial Day"
        };
        {
            Month = 5
            Day = 25
            Category = Half
            Title= "Memorial Day"
        };
        {
            Month = 6
            Day = 3
            Category = Full
            Title = "Independance Day Observed"
        };
        {
            Month = 9
            Day = 7
            Category = Full
            Title = "Labor Day"
        };
        {
            Month = 11
            Day = 25
            Category = Half
            Title = "Thanksgiving"
        };
        {
            Month = 11
            Day = 26
            Category = Full
            Title = "Thanksgiving"
        };
        {
            Month = 11
            Day = 27
            Category = Full
            Title = "Thanksgiving"
        };
        {
            Month = 12
            Day = 23
            Category = Half
            Title = "Christmas"
        };
        {
            Month = 12
            Day = 24
            Category = Full
            Title = "Christmas"
        };
        {
            Month = 12
            Day = 25
            Category = Full
            Title = "Christmas"
        };
        {
            Month = 12
            Day = 30
            Category = Half
            Title = "New Year"
        };
        {
            Month = 12
            Day = 31
            Category = Full
            Title = "New Year"
        };
        {
            Month = 1
            Day = 1
            Category = Full
            Title = "New Year"
        }
    ]