open System

// Define a function to add an arbitrary number of numbers
let addList (numbers: int list) =
    List.sum numbers

// Define a function to subtract an arbitrary number of numbers
let subtractList (numbers: int list) =
    List.fold (-) (List.head numbers) (List.tail numbers)

// Define a function to multiply an arbitrary number of numbers
let multiplyList (numbers: int list) =
    List.fold (*) 1 numbers

// Define a function to divide an arbitrary number of numbers
let divideList (numbers: int list) =
    List.fold (/) (List.head numbers) (List.tail numbers)

// Get user input for numbers to perform calculations

let getUserInput ()  =
  let mutable operation = 0
  let mutable numbers = []
  while operation < 1 || operation > 4 do
    printfn "------Pick your operation------"
    printfn "1. Add, press 1"
    printfn "2. Subtract, press 2"
    printfn "3. Multiply, press 3"
    printfn "4. Divide, press 4"
    printfn "Press 'e' to exit program."

    //Key matching
    // let input = Console.ReadKey().Key
    // match input with
    // | "1" | "2" | "3" | "4" ->  // Match digits 1-4
    //     let number = System.Int32.Parse(input)
    //     ignore(number)
    // | "e" ->  // Match "e" for exit
    //   printfn "Exiting the program..."
    //   Environment.Exit(0)  // Exit with code 0 (successful termination)
    // | _ ->  // Invalid input
    //   printfn "Invalid input. Please enter a digit from 1 to 4 or 'e' to exit."

    // Key matching
    let input = Console.ReadKey().KeyChar //Lookup reason to use this line
    match input with
    | '1' ->  // Match digit 1
        operation <- 1
    | '2' ->  // Match digit 2
        operation <- 2
    | '3' ->  // Match digit 3
        operation <- 3
    | '4' ->  // Match digit 4
        operation <- 4
    | 'e' ->  // Match 'e' for exit
      printfn " .Exiting the program..."
      Environment.Exit(0)  // Exit with code 0 (successful termination)
    | _ ->  // Invalid input
      printfn "Invalid input. Please enter a digit from 1 to 4 or 'e' to exit."  


  // ... rest of your program logic ...
  // operation will now contain the parsed number (if valid)
let InputChecker (operation: int) (numbers) =
    // Collect user input for parameters
    if operation > 0 && operation < 5 then
        printfn "Enter the numbers separated by spaces:"
        let input = Console.ReadLine()
        let numbers: int list = input.Split([|' '|], System.StringSplitOptions.RemoveEmptyEntries) |> Array.map int |> Array.toList
        numbers: int list //returns the numbers list as the function value
    else
        []
        





//Main function to perform calculations based on user input

let interactiveCalculator () =
    
    let numbers = getUserInput(numbers: int list)
    
    let sum = addList numbers
    let difference = subtractList numbers
    let product = multiplyList numbers
    let quotient = divideList numbers
    printfn "Sum: %d" sum
    printfn "Difference: %d" difference
    printfn "Product: %d" product
    printfn "Quotient: %d" quotient


//Call all functions

getUserInput ()
InputChecker
interactiveCalculator()

// [<EntryPoint>]
// let main _ = getUserInput ()// Directly call getUserInput from entry point