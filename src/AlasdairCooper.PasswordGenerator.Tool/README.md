![Nuget](https://img.shields.io/nuget/v/AlasdairCooper.PasswordGenerator.Tool?color=eebb00&style=for-the-badge) ![Nuget](https://img.shields.io/nuget/dt/AlasdairCooper.PasswordGenerator.Tool?color=0033ee&style=for-the-badge)

# AlasdairCooper.PasswordGenerator.Tool

This is a basic tool for generating a password meeting several basic requirements. There are two commands available.

## Quick Start

The below commands produce the same result.

```shell
> password-generator quick 32 --copy
xgAa9#$fWJe&X47ZE1zyp2z5lLWIB9Rm
```

```shell
> password-generator full 32 -ulns --copy
Ewn!%x91$DczZ!£!!aO@!UBuZ8bwh164
```


## `quick`

Generate a password with default options (16 characters, all requirements enabled).

```
  --copy             Copy the output to the clipboard.

  --help             Display this help screen.

  --version          Display version information.

  Length (pos. 0)    Password length.
```

## `full`

Generate a password with configurable options.

```
  -u, --with-upper      Include uppercase characters.

  -l, --with-lower      Include lowercase characters.

  -n, --with-numeric    Include numerical characters.

  -s, --with-special    Include special characters.

  --copy                Copy the output to the clipboard.

  --help                Display this help screen.

  --version             Display version information.

  Length (pos. 0)       Password length.
```