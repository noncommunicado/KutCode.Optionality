# <img src="./icon/icon.png" style="width: 30px" /> KutCode.Optionality

.NET library that provides a type-safe way to handle nullable values in C#. It helps prevent null reference exceptions and makes null handling more explicit and safer.

## ⚙️ Features

- 🛡️ Type-safe handling of nullable values for both reference and value types
- 🎯 Two main types: `Optional<T>` for reference types and `OptionalValue<T>` for value types
- 🔄 Built-in JSON serialization support using `System.Text.Json`
- 🎨 Clean and fluent API for working with optional values
- 🚀 Zero dependencies on external packages

## 📦 Installation

KutCode.Optionality is designed to work with `net7.0` and higher.

Install via NuGet Package Manager:

```powershell
Install-Package KutCode.Optionality
```

Or via the .NET CLI:

```shell
dotnet add package KutCode.Optionality
```

All versions can be found [here](https://www.nuget.org/packages/KutCode.Optional.Core/).

## 🚀 Basic Usage

### Creating Optional Values

```csharp
// For reference types
Optional<Person> person = Optional.From(new Person());
Optional<Person> emptyPerson = Optional.None<Person>();

// For value types
OptionalValue<int> number = new OptionalValue<int>(42);
OptionalValue<int> emptyNumber = OptionalValue<int>.None;
```

### Checking for Values

```csharp
var person = GetPerson();
if (person.HasValue)
{
    Console.WriteLine(person.Value.Name);
}
else
{
    Console.WriteLine("Person is not found");
}
```

### Functional Approach with IfHasValue and IfEmpty

```csharp
var person = GetPerson();

// Execute code only if value exists
person.IfHasValue(p => Console.WriteLine(p.Name));

// Execute code only if value is missing
person.IfEmpty(() => Console.WriteLine("Person not found"));

// Chain methods together
person
    .IfHasValue(p => ProcessPerson(p))
    .IfEmpty(() => LogMissingPerson());
```

### Pattern Matching with TryGetValue

```csharp
// Using pattern matching style with out parameter
if (person.TryGetValue(out var p))
{
    Console.WriteLine(p.Name);
}
```

### Safe Value Access with Fallback

```csharp
var person = GetPerson();

// Get value or fallback to default
var name = person.Fallback(new Person { Name = "Unknown" }).Name;

// Try multiple fallback values
var personWithFallback = person.FallbackCoalesce(
    GetPersonFromCache(),
    GetPersonFromBackup(),
    new Person { Name = "Unknown" }
);
```

### Implicit Conversions

```csharp
Optional<Person> person = Optional.From(new Person());
HandlePerson(person); // Implicitly converts to Person

void HandlePerson(Person person)
{
    // Work with non-null person
}
```

## 🔄 LINQ Extensions

The library provides LINQ extension methods for working with collections of Optional objects:

```csharp
// Filter out None values and get the actual values
var people = GetPeople(); // Returns IEnumerable<Optional<Person>>
var validPeople = people.WhereHasValue(); // Returns IEnumerable<Person>

// Transform values that exist
var names = people.SelectIfHasValue(p => p.Name); // Returns IEnumerable<string>

// Works with OptionalValue too
var ages = GetAges(); // Returns IEnumerable<OptionalValue<int>>
var validAges = ages.WhereHasValue(); // Returns IEnumerable<int>
```

## 📝 JSON Serialization

The library provides built-in JSON serialization support:

```csharp
public class Person
{
    public string Name { get; init; }
    public Optional<int> Age { get; init; }
    public OptionalValue<DateTime> BirthDate { get; init; }
}

var person = new Person 
{
    Name = "John",
    Age = Optional.From(30),
    BirthDate = new OptionalValue<DateTime>(new DateTime(1990, 1, 1))
};

var json = JsonSerializer.Serialize(person);
// Result: {"Name":"John","Age":30,"BirthDate":"1990-01-01T00:00:00"}
```

### Null Handling in JSON

```csharp
var person = new Person 
{
    Name = "John",
    Age = Optional.None<int>(),
    BirthDate = OptionalValue<DateTime>.None
};

var json = JsonSerializer.Serialize(person);
// Result: {"Name":"John","Age":null,"BirthDate":null}
```

## ⚠️ Best Practices

1. Use `Optional<T>` for reference types and `OptionalValue<T>` for value types
2. Prefer `HasValue` checks before accessing `Value`
3. Use `TryGetValue` for pattern matching style access
4. Use `IfHasValue` and `IfEmpty` for functional programming style
5. Use `WhereHasValue` and `SelectIfHasValue` for LINQ operations
6. Use `Fallback` and `FallbackCoalesce` for safe value access with defaults
7. Use JSON serialization attributes when needed:
   ```csharp
   [JsonConverter(typeof(OptionalJsonConverterFactory))]
   public Optional<Person> Person { get; init; }
   ```

## 🤝 Contributing

Feel free to contribute to this project by:
- 🐛 Reporting bugs
- 💡 Suggesting features
- 🔧 Submitting pull requests

## 📞 Support

For questions and support:
- 📱 [Telegram](https://t.me/noncommunicado)
- 📧 Create an issue in the repository
  
If you wanna to buy me a coffee 😃, I will be grateful for any tokens in TON network:  
💎 `noncommunicado.ton`  
💎 `UQD0zFgp0p-eFnbL4cPA6DYqoeWzGbCA81KuU6BKwdFmf8jv`