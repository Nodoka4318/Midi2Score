open System
open System.Collections.Generic;
open System.IO
open Commons.Music.Midi

let midi_reader (path : string) : MidiTrack =
    let access = MidiAccessManager.Default
    let midi = MidiMusic.Read(File.OpenRead(path))
    let tracks = midi.Tracks
    
    printf "対象のトラックを整数値で選択してください。\n"
    for i in 0 .. tracks.Count - 1 do
        printf $"[{i}]\n"

    let track_num = Console.ReadLine() |> int
    tracks[track_num]

let midi_parser (midi : MidiTrack) : string[] =
    let msgs = midi.Messages
    for m in msgs do
        Console.WriteLine(m.Event.Value)

    [|"hoge"|]

[<EntryPoint>]
let main argv =
    printf @"
┏━┓┏━┳━━┳━━━┳━━┳━━━┳━━━┳━━━┳━━━┳━━━┳━━━┓
┃┃┗┛┃┣┫┣┻┓┏┓┣┫┣┫┏━┓┃┏━┓┃┏━┓┃┏━┓┃┏━┓┃┏━━┛
┃┏┓┏┓┃┃┃╋┃┃┃┃┃┃┗┛┏┛┃┗━━┫┃╋┗┫┃╋┃┃┗━┛┃┗━━┓
┃┃┃┃┃┃┃┃╋┃┃┃┃┃┃┏━┛┏┻━━┓┃┃╋┏┫┃╋┃┃┏┓┏┫┏━━┛
┃┃┃┃┃┣┫┣┳┛┗┛┣┫┣┫┃┗━┫┗━┛┃┗━┛┃┗━┛┃┃┃┗┫┗━━┓
┗┛┗┛┗┻━━┻━━━┻━━┻━━━┻━━━┻━━━┻━━━┻┛┗━┻━━━┛  by Nodoka
        "
    printf "\n[Midi2Score] midiファイルをここに落とすか、midiファイルへのフルパスを入力してください。\n>> "

    let file = Console.ReadLine()
    Console.WriteLine(file)
    let midi = midi_reader file
    midi_parser midi |> ignore
    Console.ReadKey() |> ignore
    0 // return an integer exit code