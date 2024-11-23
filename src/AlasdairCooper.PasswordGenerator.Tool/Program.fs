open System
open AlasdairCooper.PasswordGenerator.Core
open CommandLine

type IPasswordRequirementsOptions =
    abstract member CopyToClipboard: bool with get
    abstract member ToRequirements: Requirements

[<Verb("quick", HelpText = "Generate a password with the default options.")>]
type GenerateQuick =
    { [<Value(0, MetaName = "Length", HelpText = "Password length.")>]
      length: int option

      [<Option("copy", HelpText = "Copy the output to the clipboard.")>]
      copyToClipboard: bool }

    interface IPasswordRequirementsOptions with
        member this.CopyToClipboard = this.copyToClipboard

        member this.ToRequirements =
            Requirements.Default.WithLength(
                match this.length with
                | Some length -> length
                | None -> Requirements.Default.Length
            )

[<Verb("full", HelpText = "Generate a password with configurable options.")>]
type GenerateFull =
    { [<Value(0, MetaName = "Length", HelpText = "Password length.")>]
      length: int

      [<Option('u', "with-upper", HelpText = "Include uppercase characters.")>]
      hasUppercase: bool

      [<Option('l', "with-lower", HelpText = "Include lowercase characters.")>]
      hasLowercase: bool

      [<Option('n', "with-numeric", HelpText = "Include numerical characters.")>]
      hasNumerical: bool

      [<Option('s', "with-special", HelpText = "Include special characters.")>]
      hasSpecial: bool

      [<Option("copy", HelpText = "Copy the output to the clipboard.")>]
      copyToClipboard: bool }

    interface IPasswordRequirementsOptions with
        member this.CopyToClipboard = this.copyToClipboard

        member this.ToRequirements =
            Requirements.Default
                .WithLength(this.length)
                .WithHasUppercase(this.hasUppercase)
                .WithHasLowercase(this.hasLowercase)
                .WithHasNumeric(this.hasNumerical)
                .WithHasSpecial(this.hasSpecial)

[<EntryPoint>]
let main args =
    let result = Parser.Default.ParseArguments<GenerateQuick, GenerateFull> args

    let generatePassword (opts: IPasswordRequirementsOptions) =
        let pwd = opts.ToRequirements |> PasswordGenerator.Generate
        pwd |> Console.WriteLine

        if opts.CopyToClipboard then
            TextCopy.ClipboardService.SetText(pwd)

        0

    match result with
    | :? Parsed<obj> as command ->
        match command.Value with
        | :? GenerateQuick as opts -> generatePassword opts
        | :? GenerateFull as opts -> generatePassword opts
        | _ -> 1
    | :? NotParsed<obj>
    | _ -> 1
