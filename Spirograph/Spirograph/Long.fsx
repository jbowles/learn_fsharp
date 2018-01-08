(*
#load "Plotting.fsx"
open Plotting
open System.Drawing
open System.IO

let pathAndFileName = Path.Combine(__SOURCE_DIRECTORY__, "longGen.png")
let bitmap = new Bitmap(400,400)

let initialPlotter = {
    position    = (200,200)
    color       = Color.DarkGreen
    direction   = 90.0
    bitmap      = bitmap }

let cmdStripe = 
    [ move 15
      turn 15.0
      polygon 3 10
    ]

let cmdsGen = seq {while true do yield! cmdStripe}
let imageCommands = cmdsGen |> Seq.take 75 //this generates an image with some overlapping because only taking a raw number of commands from cmdStripe list NOT the full set of functions (move, turn, polygon)... we want to execute ONE cycle of commands, not guess the multiple of 3 we need... Plotting has this updated

// NOTE on the Seq.fold from the linter:  
//      |> Seq.fold (fun plot cmds -> plot |> cmds ) initialPlotter //Lint: If `( |> )` has no mutable arguments partially applied then the lambda can be removed.
let image = 
    imageCommands
    |> Seq.fold (fun plot cmds -> plot |> cmds) initialPlotter
    //|> Seq.fold (fun plot cmds -> cmds plot ) initialPlotter //better way!

image.bitmap.Save(pathAndFileName)
*)