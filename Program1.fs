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

// Get user input for operation and numbers
let getUserInput () =
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

  numbers (* Return the numbers list or empty list for invalid input *)
// Function to check input and get numbers (implemented)
let InputChecker (operation: int) (numbers: int list): int list = (*int list is the return type*)
  if operation > 0 && operation < 5 then
    printfn "Enter the numbers separated by spaces:"
    let input = Console.ReadLine()
    let numbers = input.Split([|' '|], System.StringSplitOptions.RemoveEmptyEntries) |> Array.map int |> Array.toList
    numbers
  else
    [] (* Return empty list on invalid operation *)

// Main function to perform calculations based on user input
let interactiveCalculator () =
  let numbers = getUserInput()  (* Get user input and numbers *)

  if numbers <> [] then  (* Check if numbers list is not empty *)
    let sum = addList numbers
    let difference = subtractList numbers
    let product = multiplyList numbers
    let quotient = divideList numbers
    printfn "Sum: %d" sum
    printfn "Difference: %d" difference
    printfn "Product: %d" product
    printfn "Quotient: %d" quotient
  else
    printfn "No numbers provided"

// Call all functions (simplified)
getUserInput ()
interactiveCalculator ()
