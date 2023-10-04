
# <img src="./icon/icon.png" style="width: 30px" /> KutCode.Optional

NuGet package which allow you to easely handle null values in C#

## Basic usage
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