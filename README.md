AngelaSmith
===========

Angie is one of the brightest gals around.  Using her powers of insight and female comprehension, she can fill in all the details for you on anything you throw at her.  

Use Angie's static methods to new up new objects for testing, design-time data or seeding a database.Watch how fast she is at learning new languages, dialects or themes, all the while making your test or sample data more realistic. 

She even has a pretty good sense of humor!

Example Usage
===========
Let's say you have a Person class like so:

```
    class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public int Age { get; set; }
        public int NumberOfKids { get; set; }
    }
```

And you want a new instance of Person.  With AngelaSmith, you just do this:

```
    var person = Angie.FastMake<Person>();
```

Tada!  Your `person` is now filled with all the data you could ever dream of!

## But Wait!

>"I don't need no stickin' person! I need a whole list of them! 

Easy-peasy lemon squeezy, my friend!  Ask for a list instead of a single instance like so:

```
    var people = Angie.FastList<Person>();
```

There...you have 25 people, this is the default in a list.

>"Yeah, sure, fine, but they have to be between the ages of 19 and 25!" 

Cool beans, my brother or sister.  Here's how AngelaSmith rolls:

```
    var people = Angie
        .Configure<Person>()
        .Fill(p => p.Age)
        .WithinRange(19, 25)
        .MakeList<Person>();
```

And you're off to the races!  Don't worry, I won't tell your boss how long that took.  ;)

Custom Property Fillers
===========

If you want to control how the property is set, you can use your own function (anonymous or otherwise) to do so.

```
    var blogTitle = "Angie";

    var post = Angie
        .Configure<BlogPost>()
        .Fill(b => b.Title, () => { return blogTitle; })
        .Make<BlogPost>();
```

Or, you can use one of the built-in helper methods, to, for example, spin up 1000 comments that happened in the past.  There are a ton of helpers in "Jen", and you can use her to help "Jen"erate values for your objects.

```
    Angie.Default()
        .ListCount(1000);

    var comments = Angie
       .Configure<BlogPost>()
       .Fill(c => c.CreateDate, () => { return Jen.FillDate(DateRules.PastDate); })
       .MakeList<BlogComment>();
```


More To Come
===========
With David Paquette joining this project I'm pleased to say we're moving quite quickly.

Look for some upcoming posts on the fluent interfaces - there is some great stuff there that you can infer from this overview - as well as our 1.1 release which will have support for automatic discovery of many more properties.

We are also going to build in some "smarts", particularly around making properties aware of each other as they're being built (think of an email address lining up with a first name/last name or username).


