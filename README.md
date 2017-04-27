Using the [ini file parser](https://github.com/rickyah/ini-parser), this project creates a code layer abstraction which parses input values to their desired format. 

# Usage
## Installation
Install the package from [NuGet](https://www.nuget.org/packages/IniGenerator/1.0.0).

## Ini with code generation
Using a text-template we automatically create a code layer abstraction. 
Create a new text-template using the desired name for your ini file.

The text-template will have to include the IniTemplate.tt, an example:

```csharp
<#@ include file="$(ProjectDir)IniTemplate.tt" #>
<#
    // All properties in the ini file
    // Name, default value and category
    CreateProperty("Width", 1280, "Video");
    CreateProperty("Height", 720, "Video");
    CreateProperty("Fullscreen", false, "Video");

    // Generate the code layer
    GenerateIniClass();
#>
```

If you use this package from source, you will have to change the path for the IniTemplate.tt.

## Using the ini values in code
After transforming the above template, we have a code layer for the ini file. Use as follows:

```csharp
// Use the namespace where you placed the template
using IniGenerator.Content.Generated;

// Name of ini file
var config = new Config();
// Can be used directly in code without parsing
var size = new Size(config.Width, config.Height);
var fullscreen = config.Fullscreen;
```
