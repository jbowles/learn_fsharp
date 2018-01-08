// Learn more about F# at http://fsharp.org. See the 'F# Tutorial' project
// for more guidance on F# programming.

#load "Component1.fs"
open UdemyFshApps

let tuple1 = (5,10)
let tuple2 = (4.4, "The quik brown fox jumpled over the lazy dog.")



tuple1 |> TupleTime.tupleFunc

let x, y = tuple1

let tuple3 = (5,10)
tuple1 = tuple3

tuple1 < (5,11)

let tuple4 = struct (1,1)
