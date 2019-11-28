namespace Project_WordGuesser
open System

module WordGuesser =
   let OutputInfo word tries =
       let wordArray =
           word
           |> Seq.toArray
           |> Array.map (fun x -> if Array.contains x tries then x else char "*" )
       let wordString = new String(wordArray)
       let lastTry = Array.last tries
       printfn "%s    Used [%A]. Guess: [%c]" wordString tries lastTry
       
   let OutputWinner (word: string) tries =
       OutputInfo word tries
       printfn "You guessed it! Using only %d guesses!" tries.Length
       
   let AllGuessed word tries =
       word
       |> Seq.toArray
       |> Array.filter (fun x -> not (Array.contains x tries))
       |> Array.length
       |> fun x -> x = 0