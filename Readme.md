
# <img src="./icon/icon.png" style="width: 30px" /> KutCode.Optionality

.NET library that allows you to easily handle null values in C#.

## ⚙️ Features
* Handle `nullable` value and reference types
* Easy *"from value"* creation or static `.None` stub
* Built-in Json support `System.Text.Json` as Serialization and Deserialization

## 📜 Install
KutCode.Optionality is designed to work with `net7.0` and higher.

Install KutCode.Optionality using NuGet Package Manager:
```powershell
Install-Package KutCode.Optionality
```

Or via the .NET CLI:
```shell
dotnet add package KutCode.Optionality
```


All versions can be found [here](https://www.nuget.org/packages/KutCode.Optional.Core/).

## ⌨️ Basic usage
* Wrap all types for easy nullabillity checks
```csharp
public Optional<Person> GetPerson() 
{
    Person? person = _context.GetPerson();
    return Optional.From<Person>(person);
}

public static void Main()
{
    var person = GetPerson();
    if (person.HasValue) Console.WriteLine(person.Name);
    else Console.WriteLine("Person is not presented");
}
```

* Stop use null return - prevent `NullReferenceException`
```csharp
public Optional<Person> GetAnyPerson()
{
    try {
        // anything wrong...
    }
    catch {
        return Optional<Person>.None; // .HasValue will return false
    }
}
```

* Cast Optional type to TValue implicitly if you need
```csharp
public void Main()
{
    Optional<Person> person = Optional.From(new Person());
    HandlePerson(person); // implicit casting
}

public void HandlePerson(Person person)
{
    // some actions
}
```

## 📦 JSON

KutCode.Optionality allows you to use `Optional<T>` in JSON-models.


## ℹ️ Additional info
### 🗨️ [Telegram](https://t.me/hamaronooo/)