AngelaSmith
===========

Angie is one of the brightest gals around.  Using her powers of insight and female comprehension, 
she can fill in all the details for you on anything you throw at her.  

Use Angie's static methods to new up new objects for testing, design-time data or seeding a database.
Watch how fast she is at learning new languages, dialects or themes, all the while making your test 
or sample data more realistic. 

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
"I don't need no stickin' person!" you say. "I need a whole list of them! And they have to be between the ages of 19 and 25!" 

Cool beans, my brother or sister.  Here's how AngelaSmith rolls:

```
    var people = Angie
        .Configure()
        .IntRange(19, 25)
        .FastList<Person>();
```

And you're off to the races!  Don't worry, I won't tell your boss how long that took.  ;)

More To Come
===========
I've been tinkering with this for a while