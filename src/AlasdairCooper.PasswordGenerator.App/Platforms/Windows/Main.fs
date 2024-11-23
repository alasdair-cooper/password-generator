namespace AlasdairCooper.PasswordGenerator.App.WinUI

open System

module Program =
    [<EntryPoint; STAThread>]
    let main args =
        do FSharp.Maui.WinUICompat.Program.Main(args, typeof<AlasdairCooper.PasswordGenerator.App.WinUI.App>)
        0
