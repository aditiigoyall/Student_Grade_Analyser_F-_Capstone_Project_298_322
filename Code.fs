
// Import the System namespace for console input and output
open System

// Define a Student record with Name and Marks fields
type Student = {
    Name: string
    Marks: float
}

// Function to assign grades based on student marks
let getGrade marks =
    // Pattern matching checks the marks against different conditions
    match marks with
    | m when m >= 90.0 -> "A+"
    | m when m >= 80.0 -> "A"
    | m when m >= 70.0 -> "B"
    | m when m >= 60.0 -> "C"
    | m when m >= 40.0 -> "D"
    | _ -> "F"  // Default grade if marks are below 40

// list containing student records
let students = [
    { Name = "Aditi"; Marks = 92.0 }
    { Name = "Rahul"; Marks = 76.0 }
    { Name = "Priya"; Marks = 85.0 }
    { Name = "Aman"; Marks = 32.0 }
    { Name = "Neha"; Marks = 68.0 }
]

// Function to display all students with their grades and results
let showStudents () =

    // Display table headings
    printfn "\nName       Marks   Grade  Result"
    printfn "--------------------------------"

    // List.iter processes and displays each student
    students
    |> List.iter (fun s ->

        // Check whether the student has passed or failed
        let result =
            if s.Marks >= 40.0 then "Pass"
            else "Fail"

        // Display student name, marks, grade and result
        printfn "%-10s %-7.1f %-6s %s"
            s.Name s.Marks (getGrade s.Marks) result
    )

let average =
    students |> List.averageBy (fun s -> s.Marks)


let topper =
    students |> List.maxBy (fun s -> s.Marks)


let passed =
    students |> List.filter (fun s -> s.Marks >= 40.0)


let failed =
    students |> List.filter (fun s -> s.Marks < 40.0)

// Variable to control the menu loop
let mutable running = true

// Continue displaying the menu until the user exits
while running do

    // Display the main menu
    printfn "\n===== STUDENT GRADE ANALYSER ====="
    printfn "1. Display all students"
    printfn "2. Show class average"
    printfn "3. Show topper"
    printfn "4. Show pass/fail count"
    printfn "5. Exit"

    // Accept user's menu choice
    printf "Enter choice: "

    // Match the user's choice and perform the selected operation
    match Console.ReadLine() with

    // Option 1: Display student details
    | "1" -> showStudents ()

    // Option 2: Display class average
    | "2" -> printfn "Class Average: %.2f" average

    // Option 3: Display topper's name and marks
    | "3" ->
        printfn "Topper: %s (%.1f marks)"
            topper.Name topper.Marks

    // Option 4: Display pass and fail counts
    | "4" ->
        printfn "Passed: %d" passed.Length
        printfn "Failed: %d" failed.Length

    // Option 5: Exit the application
    | "5" -> running <- false

    // Handle invalid menu choices
    | _ -> printfn "Invalid choice. Try again."

// Display a message after exiting the menu
printfn "Thank you for using the analyser!"
