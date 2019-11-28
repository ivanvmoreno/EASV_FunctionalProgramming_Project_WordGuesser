namespace Project_WordGuesser
open System

module Program =
    [<EntryPoint>]
    let main argv = 
        let wordList = [|"tree"; "dog"; "cat"; "chinese"|]
        let randomWord = wordList.[System.Random().Next(wordList.Length)]
        let mutable tries = [||]
        let mutable guessed = false
        printfn "The length of the word is %d" randomWord.Length
        while not guessed do
            let input = Console.ReadLine() |> char
            tries <- Array.append tries [|input|]
            match WordGuesser.AllGuessed randomWord tries with
            | true ->
                WordGuesser.OutputWinner randomWord tries
                guessed <- true
            | false -> WordGuesser.OutputInfo randomWord tries
        0