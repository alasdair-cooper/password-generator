namespace AlasdairCooper.PasswordGenerator.App

open System
open AlasdairCooper.PasswordGenerator.Core
open Fabulous
open Fabulous.Maui

open type Fabulous.Maui.View
open Microsoft.Maui.ApplicationModel
open Microsoft.Maui.ApplicationModel.DataTransfer

module App =
    type Model =
        { Password: string
          Requirements: Requirements
          WasCopied: bool }

        static member New =
            { Password = PasswordGenerator.Generate Requirements.Default
              Requirements = Requirements.Default
              WasCopied = false }

    type Msg =
        | UpdateLength of int
        | UpdateHasLowercase of bool
        | UpdateHasUppercase of bool
        | UpdateHasNumeric of bool
        | UpdateHasSpecial of bool
        | GeneratePassword
        | CopyPasswordToClipboard
        | CopiedPasswordToClipboard

    let update msg (model: Model) =
        match msg with
        | UpdateLength length ->
            { model with
                Requirements = model.Requirements.WithLength(length) },
            Cmd.ofMsg GeneratePassword
        | UpdateHasLowercase hasLowercase ->
            { model with
                Model.Requirements = model.Requirements.WithHasLowercase(hasLowercase) },
            Cmd.ofMsg GeneratePassword
        | UpdateHasUppercase hasUppercase ->
            { model with
                Model.Requirements = model.Requirements.WithHasUppercase(hasUppercase) },
            Cmd.ofMsg GeneratePassword
        | UpdateHasNumeric hasNumeric ->
            { model with
                Model.Requirements = model.Requirements.WithHasNumeric(hasNumeric) },
            Cmd.ofMsg GeneratePassword
        | UpdateHasSpecial hasSpecial ->
            { model with
                Model.Requirements = model.Requirements.WithHasSpecial(hasSpecial) },
            Cmd.ofMsg GeneratePassword
        | GeneratePassword ->
            { model with
                Password = PasswordGenerator.Generate model.Requirements
                WasCopied = false },
            []
        | CopyPasswordToClipboard ->
            let copyToClipboard text =
                async {
                    MainThread.BeginInvokeOnMainThread(fun () -> Clipboard.Default.SetTextAsync text |> ignore)
                    return CopiedPasswordToClipboard
                }

            model, model.Password |> copyToClipboard |> Cmd.ofAsyncMsg
        | CopiedPasswordToClipboard -> { model with WasCopied = true }, Cmd.none


    let view model =
        let requirementCheckbox label isChecked onCheckedChanged =
            HStack(spacing = 10.) {
                CheckBox(isChecked, onCheckedChanged)
                Label(label).centerVertical ()
            }

        Application(
            ContentPage(
                ContentView(
                    (VStack(spacing = 25.) {
                        Button(model.Password, CopiedPasswordToClipboard)
                            .minimumWidth(200.)
                            .centerHorizontal ()

                        Label(
                            if model.WasCopied then
                                "Copied password to clipboard."
                            else
                                ""
                        )
                            .centerHorizontal ()

                        Slider(8, 32, model.Requirements.Length, (fun value -> value |> Math.Round |> int |> UpdateLength))
                            .minimumWidth(200.)
                            .centerHorizontal ()

                        (VStack(spacing = 25.) {
                            requirementCheckbox "Include lowercase characters" model.Requirements.HasLowercaseCharacters UpdateHasLowercase
                            requirementCheckbox "Include uppercase characters" model.Requirements.HasUppercaseCharacters UpdateHasUppercase
                            requirementCheckbox "Include numerical characters" model.Requirements.HasNumericCharacters UpdateHasNumeric
                            requirementCheckbox "Include special characters" model.Requirements.HasSpecialCharacters UpdateHasSpecial
                        })
                            .centerHorizontal ()
                    })
                        .padding(30., 0., 30., 0.)
                        .centerVertical ()

                )
            )
        )

    let program = Program.statefulWithCmd (fun () -> Model.New, []) update view
