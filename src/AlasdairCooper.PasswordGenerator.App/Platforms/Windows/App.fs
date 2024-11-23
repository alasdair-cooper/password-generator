namespace AlasdairCooper.PasswordGenerator.App.WinUI

open AlasdairCooper.PasswordGenerator.App

/// <summary>
/// Provides application-specific behavior to supplement the default Application class.
/// </summary>
type App() =
    inherit FSharp.Maui.WinUICompat.App()

    override this.CreateMauiApp() = MauiProgram.CreateMauiApp()
