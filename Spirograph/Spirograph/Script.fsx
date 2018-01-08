#load "Plotting.fsx"
#load "Spirograph.fs"
open System.Drawing
open System.Drawing.Imaging
open Spirograph
open Plotting

let initialPlotter = 
    {   
        Plotter.position    = 1000,1000
        Plotter.color       = Color.Orange
        Plotter.direction   = 0.0
        Plotter.bitmap      = new Bitmap(2000,2000) 
    }

let cmdStripe =
    [
        changeColor Color.Purple
        move 45
        turn 45.4
        move 100
        fifthCircle 45 45
        changeColor Color.Black
        turn 90.0
        move 45
        fifteenthCircle 45 45
        turn 45.8
        move 145
        turn 180.2
        move 50
        changeColor Color.Chocolate
        thirdCircle 50 50
        moveTo (1000,1000)
    ]

generate cmdStripe 2000 initialPlotter |> saveAs "Experiment.png"
