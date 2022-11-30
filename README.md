GenFu 
===========

http://genfu.io/ 

![Build status](https://github.com/MisterJames/GenFu/workflows/Continuous%20Integration/badge.svg) [![NuGet Badge](https://buildstats.info/nuget/GenFu)](https://www.nuget.org/packages/GenFu/)

> **GenFu** is a library you can use to generate realistic test data. It is composed of several *property fillers* that can populate commonly named properties through reflection using an internal database of values or randomly created data. You can override any of the fillers, give **GenFu** hints on how to fill them.

GenFu is all about _smartly_ building up objects to use for test and prototype data. It will walk your object graph and fill in the properties on your type with realistic looking data.  

Use GenFu's static methods to new up new objects for testing, design-time data or seeding a database. 

**GenFu** runs on AspNetCore50 and can run anywhere core can run.

Installation
===========
GenFu is on [NuGet](https://nuget.org/packages/GenFu) so you can easily add it to your project from the Package Manager Console:

```   
install-package GenFu 
```


Example Usage
===========
Let's say you have a Person class like so:

``` cs
class Person
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Title { get; set; }
    public int Age { get; set; }
    public int NumberOfKids { get; set; }
	
    private string _middleName;
    public void SetMiddleName(string name){ _middleName = name; }
}
```

And you want a new instance of Person.  With GenFu, you just do this:

``` cs
var person = A.New<Person>();
```

Tada!  Your `person` is now filled with all the data you could ever dream of!

## But Wait!

>"I don't need no stickin' person! I need a whole list of them! 

Easy-peasy lemon squeezy, my friend!  Ask for a list instead of a single instance like so:

``` cs
var people = A.ListOf<Person>();
```

There...you have 25 people, this is the default in a list.

>"Yeah, sure, fine, but they have to be between the ages of 19 and 25!" 

Cool beans, my brother or sister.  Here's how GenFu rolls:

``` cs
GenFu.Configure<Person>()
    .Fill(p => p.Age)
    .WithinRange(19, 25);
var people = A.ListOf<Person>();
```

And you're off to the races!  Don't worry, I won't tell your boss how long that took.  ;)

Custom Property Fillers
===========

If you want to control how the property is set, you can use your own function (anonymous or otherwise) to do so.

``` cs
var blogTitle = "GenFu";

GenFu.Configure<BlogPost>()
    .Fill(b => b.Title, () => { return blogTitle; })

var post = A.New<BlogPost>();
```


Method Fillers
===========

If your project uses one-parameter setter methods, you can use GenFu too!

``` cs
GenFu.Configure<Person>()
    .MethodFill<string>(x => x.SetMiddleName(null))
var post = A.New<Person>();
```

You can use any of the helper methods with setter methods, just like with properties.

**Note**: **Unlike** properties, GenFu will not automatically poke data into any methods found. That sounds a little too risky! So if you want GenFu to use your setter methods, specify each method you'd like filled.

More To Come
===========
**GenFu** was originally created by James Chambers, David Paquette and Simon Timms under the name **AngelaSmith**.  

We are continuing to add more features, such as:
 - Better support for object self-awareness (think of an email address lining up with a first name/last name or username)
 - Additional property fillers
