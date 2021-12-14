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

## DateTime Extensions

### SystemTime.Now

This is technically not an extension, but fits well in this package. It's taken from [this blog](https://lostechies.com/jimmybogard/2008/11/09/systemtime-versus-isystemclock-dependencies-revisited/). This method exposes DateTime.Now as an instance of a function, that can be replaced in tests.

If you want to replace SystemTime.Now in a test you can do it like this:

```csharp
[Test]
public void Should_test_something_here()
{
    var systemTimeDate = new DateTime(2021, 9, 2);
    SystemTime.Now = () => new DateTime(2021, 9, 2);

    DateTime dateTimeToBeTested = systemTimeDate;

    // ...
}
```

You can also set SystemTime.Now to any function that returns a DateTime:

```csharp
var startDate = new DateTime(2021, 9, 2);
SystemTime.Now = () => startDate.AddDays(2);
```

## Exception Extensions

### BaseExceptionMessage

Returns a string of the message of the first/root/base exception in an exception stack.

```csharp
try
{
    ...
}
catch (Exception ex)
{
    string baseExceptionMessage = ex.BaseExceptionMessage();
    ...
}
```

### BaseExceptionMessageAndStackTrace

Returns a single string of the message and stack trace of the first/root/base exception in an exception stack.

```csharp
try
{
    ...
}
catch (Exception ex)
{
    string baseExceptionMessageAndStackTrace = ex.BaseExceptionMessageAndStackTrace();
    ...
}
```

### AllInnerExceptionMessages

Returns a list of the exception messages of each nested exception in an exception stack.

```csharp
try
{
    ...
}
catch (Exception ex)
{
    List<string> allInnerExceptionMessages = ex.AllInnerExceptionMessages();
    ...
}
```

### AllInnerExceptionMessagesAndStackTraces

Returns a list of single strings of the message and stack trace of each nested exception in an exception stack.

```csharp
try
{
    ...
}
catch (Exception ex)
{
    List<string> allInnerExceptionMessagesAndStackTraces = ex.AllInnerExceptionMessagesAndStackTraces();
    ...
}
```

## Logging Extensions

### DisposableStopWatchExtension

This extends `ILogger` with a timer that can wrap code with a using statement. It was heavily inspired by James Curran's [blog post](https://honestillusion.com/2021/12/14/Simple-timings.html). With this extension you can quickly, easily and cleanly stick `StopWatch` objects around code that you wish to time.

```csharp
using (_logger.DisposableStopWatch())
{
    ...
}
```

It takes in additional parameters for a message and whether or not to also write to a Console for quick and dirty iterating.

```csharp
using (_logger.DisposableStopWatch("A message", true))
{
    ...
}
```

You get a `Start:` log, with the message appended if you've passed it, and once your code within the using block has run you get `Complete:` with the messaged appended if you've passed it, then on the same line `Elapsed:` and the time elapsed in HH:MM:SS:MS..... format.
