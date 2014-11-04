# Upgrading to V3
Angela Smith is a new girl in V3.  Here's the survival guide to understanding the changes and why we made them.

To be honest, we're not really giving you many motivators to upgrade an existing system that uses Angie. The most common use case is to use the library on the head-end of a project or while templating new views/services, however there are a few things you should know.

## Naming
We wanted to make the syntax less wordy, and so we spent some time thinking about what that might mean. As such, we're happy to have gone from this:


    var person = Angie.FastMake<Person>();

...to a more concise:

    var person = A.New<Person>();

We also think it reads better, i.e., "I'm getting '`A.New`' `Person`;



