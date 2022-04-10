// Learn more about F# at http://fsharp.org

open System
open System.IO
open Commons.Music.Midi

let midi_reader path =
    let access = MidiAccessManager.Default
    let midi = MidiMusic.Read(System.IO.File.OpenRead(path))
    let tracks = midi.Tracks
    
    printf "トラックを選択してください。"
    for i in 0 .. tracks.Count do
        printf $"[{i}]"

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
    printf "\n>> midiファイルをここに落とすか、midiファイルへのフルパスを入力してください。"
    0 // return an integer exit code