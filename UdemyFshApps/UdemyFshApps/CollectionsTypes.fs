namespace LanguageReview

module CollectionAPIs =

    let testList = List.init 100 (fun n -> n * 11)
    List.length testList |> printfn "%A"

    testList |> List.isEmpty |> printfn "%A" //val it : bool = false
    testList |> List.min |> printfn "%A" //val it : int = 0
    testList |> List.max |> printfn "%A" //val it : int = 1089
    testList |> List.exists (fun n -> n = 55) |> printfn "%A" //val it : bool = true
    testList |> List.find (fun n -> n = 55) |> printfn "%A" //val it : int = 55
    testList |> List.tryFind (fun n -> n = 55) |> printfn "%A" //val it : int option = Some 55

    testList |> List.tryFind (fun n -> n % 3 = 0) |> printfn "%A" //val it : int option = Some 55
    testList |> List.filter (fun n -> n % 3 = 0) |> printfn "%A" //val it : int option = Some 55


    //no hits
    testList |> List.exists (fun n -> n = 23) |> printfn "%A" //val it : bool = false
    testList |> List.find (fun n -> n = 23) |> printfn "%A" //Exception of type 'System.Collections.Generic.KeyNotFoundException' was thrown.
    testList |> List.tryFind (fun n -> n = 23) |> printfn "%A" //val it : int option = None


    //compisition
    testList
    |> List.filter (fun n -> n % 3 = 0)
    |> List.map (fun n -> n * n)
    |> List.rev                      //reverse
    |> printfn "%A"

    //iter used when you don't need a return value
    testList
    |> List.iter (fun n -> printfn "%i" n)
    
    //for iter here can remove the ceremony for anon function
    testList
    |> List.iter (printfn "%i")

    //fold: accumulator with element n, if modulo, use cons `::` to append n as head element to accumulator, which is a List []
    testList
    |> List.fold (fun acc n -> if n % 3 = 0 then acc else n :: acc) [] 
    |> printfn "%A"

    //reduce must use elements from the list, cannot introduce new T acc (like fold uses accumulator [] to stuff things into). Since element is integer then acc needs to be an integer
    testList
    |> List.reduce (fun acc n -> if n % 3 = 0 then acc else acc + n)
    |> printfn "%A"