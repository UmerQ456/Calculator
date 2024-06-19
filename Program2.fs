open System

// Define a class to manage calculator functionalities
type Calculator () =
    member this.GetUserInput () : int list =
        let mutable operation = 0
        let mutable numbers = []
        while operation < 1 || operation > 4 do
            printfn "------Pick your operation------"
            printfn "1. Add, press 1"
            printfn "2. Subtract, press 2"
            printfn "3. Multiply, press 3"
            printfn "4. Divide, press 4"
            printfn "Press 'e' to exit program."

            let input = Console.ReadKey().KeyChar
            match input with
            | '1' -> operation <- 1
            | '2' -> operation <- 2
            | '3' -> operation <- 3
            | '4' -> operation <- 4
            | 'e' ->
                printfn ".Exiting the program..."
                Environment.Exit(0)
            | _ ->
                printfn "Invalid input. Please enter a digit from 1 to 4 or 'e' to exit."

        // Call InputChecker to get numbers if valid operation
        if operation > 0 && operation < 5 then
            numbers <- this.InputChecker operation numbers
        numbers

    member this.InputChecker (operation: int) (numbers: int list) : int list =
        if operation > 0 && operation < 5 then
            printfn "Enter the numbers separated by spaces:"
            let input = Console.ReadLine()
            let numbers = input.Split([|' '|], System.StringSplitOptions.RemoveEmptyEntries) |> Array.map int |> Array.toList
            numbers
        else
            []

    member this.PerformCalculation (numbers: int list) =
        match numbers with
        | [] -> printfn "No numbers provided"
        | _ ->
            let sum = List.sum numbers
            let difference = List.fold (-) (List.head numbers) (List.tail numbers)
            let product = List.fold (*) 1 numbers
            let quotient = List.fold (/) (List.head numbers) (List.tail numbers)
            printfn "Sum: %d" sum
            printfn "Difference: %d" difference
            printfn "Product: %d" product
            printfn "Quotient: %d" quotient

// Main program for user interaction
let interactiveCalculator =
    let calculator = new Calculator()
    let numbers = calculator.GetUserInput()
    calculator.PerformCalculation numbers

// Call main program
interactiveCalculator
