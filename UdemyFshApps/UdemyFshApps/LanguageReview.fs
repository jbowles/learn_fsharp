namespace LanguageReview

//tuples
module TupleTime =

   let tupleFunc (x,y) =
        (x + y, x *y )


// records
module RecordRecs =

    [<Struct>]
    type PersonRecord =
        {
            FirstName : string
            LastName : string
            Age : int
        }
    let richard = 
         {
             FirstName = "Rick"
             LastName = "Broaid"
             Age = 349
         }
    let fun1 person =
         (person.FirstName, person.Age)

 
// discriminated union / choices
module DisUnion = 
    type TrafficSignals =
        | Red 
        | Yellow  
        | Green 

    type Shape =
        | Circle of float
        | Rectangle of float * float
        | Square of float

    open System

    type MessageReceiverState =
        | Off
        | Activating of WhenActivated : DateTime
        | Idle of IdleDuration : TimeSpan
        | MessageReceived of Message : string * WhenReceived : DateTime
        | Deactivating of WhenDeactivated : DateTime

module OptionOh =
    let safeDivide (x,y) =
        if y = 0.0
            then None 
            else Some (x/y)

module CollectionCo =
    let array1 = [|1..10|]
    let list1 = [1..10]
    let seq1 = seq {1..10}
    let set1  = set {1..10}
    let map1 = Map.empty
                    .Add(1,"One").Add(2,"Two").Add(3,"three")
                    .Add(4,"four").Add(5,"five").Add(5,"six")
open CollectionCo
                    .Add(6,"six").Add(7,"seven").Add(8,"eight")
                    .Add(9,"nine").Add(10,"ten")

// MUTABLE equi-type items
module ArrayAs =
    let array11 = [|1; 2; 3;|]
    let array12 = [|1 .. 3|]
    let array13 = [|for i in 1 ..300 -> i|]
    let array14 =  Array.init 3 (fun id -> id + 1)
    let array15 = Array.create 3 0

    array11.[1] <- 5
    array11

//immutable container of equi-type items; head :: tail; pattern matching; fast to add head item
module ListLs =
    let list1 = [1;2;3] 
    let list2 = [1..3]
    let list3 = [for i in 1..300 -> i]
    let list4 = List.init 3 (fun id -> id + 1)
    let list5 : int list = []
    let list6 = 0 :: list1

    let rec printTheList l =
        match l with
        | []
            -> ()
        | head :: tail  
            ->  printfn "%i" head
                printTheList tail
    
    list6 |> printTheList
    list5 |> printTheList

//interface to IEnumerable algebraic type; equi-type container
module Seqseq =
    let seqArray1 = seq [|1;2;3|] 
    let seqArray2 = [|1..3|]
    let seqList1 = seq [1;2;3] 
    let seqList2 = [1..3]
    let seq1 = seq {1..3}
    seq1 |> Seq.take 1 |> printfn "%A"
    let seq2 = seq {for i in 1..300 -> i}
    let seq3 = Seq.init 3 (fun id -> id + 1)
    let seq4 = Seq.initInfinite (fun id -> id + 1)

    seq2 |> Seq.take 3 |> printfn "seq2: %A"
    seq3 |> Seq.take 3 |> printfn "seq3: %A"
    seq4 |> Seq.take 3 |> printfn "seq4: %A"

    seq1
    seq2
    seq3
    seq4

//immutable unique list of equi-type items
module Setset =
    let set1 = set [1;2;3]
    let set2 = set1.Add 8
    set1
    set1.IsProperSubsetOf set1

//immutable dictionary
module Mapmaps =
    let map1 = Map  .empty //use empty to create
                    .Add(1,"one")
                    .Add(2,"two")
                    .Add(3,"three")
    map1
    map1.[2]

module FunkyFuncs =
    // looks like it accepts 2 args; instead function accepts first arg returns a function that accepts 2 arg returns and int.

    let func3 x y =
        x * y

    let func4 = func3 11
    func4 8

    //use tuple if you want to avoid partial application
    let func5 (x,y) =
        x * y

    let func6 () =
        (fun x -> x * x)

    let func7 f x =
        f x
    
    func7 (fun x -> x * x) 6

    