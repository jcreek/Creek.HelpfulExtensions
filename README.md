[![Nuget](https://img.shields.io/nuget/v/Creek.HelpfulExtensions)](https://nuget.org/packages/Creek.HelpfulExtensions)
[![Nuget](https://img.shields.io/nuget/dt/Creek.HelpfulExtensions)](https://nuget.org/packages/Creek.HelpfulExtensions)


# Creek.HelpfulExtensions

 A package containing helpful extensions to either save time or cognitive load.

 This is available on NuGet - just click one of the buttons above, or search for `Creek.HelpfulExtensions` in Visual Studio.

## String Extensions

### SubstringBetween

This method allows you to return a substring from the first occurrence of the start string to the end string. Normally with `Substring` you have to put the start string and the length from there, but with this you can more naturally select between two strings, with the option to use either the first or last match for the end string.

For example, this code will result in the string `"fishman"`.

```csharp
string s = "bigfishmandogcatdoghat";
s = s.SubstringBetween("fish", "dog");
```

Whereas, this will result in the string `"fishmandogcat"` as the boolean passed in confirms you wish to use the last match of the end string.

```csharp
string s = "bigfishmandogcatdoghat";
s = s.SubstringBetween("fish", "dog", true);
```

## IEnumerable Extensions

### WithIndex

This method allows you to use a foreach loop and easily access the index of each item.

```csharp
foreach (var (item, index) in list.WithIndex())
{
    // ...
}
```
