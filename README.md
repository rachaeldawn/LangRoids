# LangRoids
A language enhancements package adding a more functional and minimalist feel to C# 7.1.


| Function | What it does |
| :------: | :------ |
| Assure | Allows for failures to be handled either through exception or dependency injection |
| Perform | Allows for conditional function execution. |
| Compose | Allows for multiple functions of a matching signature to be combined into a new function |
| Repeat | Allows for repeating an amount of times |
| ForEach | Allows iteration on any IEnumerable |
| Pipe | Allows a pipeline of functions to be made, where the next function receives the current function's results. |
| Smallest | Select the smallest of an array of numbers |
| DoOrThrow | Perform an action or throw an exception |
| ThrowIf | Throw an exception if something is true |
| ContainsAll | Does collection A contain everything that collection B does |
| Nothing | A function that returns the default for a type |
| Nullify | Set a variable to its default |
| DoNothing | A function that does nothing. |


# The Manual

I built these functions to minimize linecount, and express a sense of order, without the extra keywords. As such, there's a styling that I use to avoid the code getting ugly, and when you start to understand what is going on, you will find this to be a much more elegant means through which you can express instructions. Most of the code is built around the lambda syntax indicating that something is going on, or tuples to imply options.


# Things that do stuff

## Perform
Certainly my most used function, Perform is intended to "do" something conditionally. It is the basis of a conditional function.
```
public void Add3IfAbove6(ref int num) => Perform(num > 6, () => num + 3);
```
This is the most basic example of a conditional function. The first statement to a Perform is "Under what circumstance is this considered possible/successful?", followed by the function to actually perform. But that raises the question, what happens when it is not successful?
```
public void Add3IfAbove6(ref int num) => Perform(num > 6, 
    new ArgumentOutOfRangeException(), () => num += 3);
```
This usage says "Hey, if the number isn't something I can work with, throw this exception." Compare this to the following function that is effectively the same.
```
public void Add3IfAbove6(ref int num)
{
    if(num <= 6)
    {
        throw new ArgumentOutOfRangeException();
    }
    num += 3;
}
```
A lot shorter, isn't it? Even with Java-style brackets (my preference), you will notice it just looks nicer.
```
public void Add3IfAbove6(ref int num) {
    if (num <= 6) {
        throw new ArgumentOutOfRangeException();
    }
    num += 3;
}
```
2 lines vs 5, on even the most basic function is a drop worth mentioning. Standard C# style, you're dropping from 7 to 2. But what happens if you want dependency injection?
```
public void Add3IfAbove6(ref int num, Action isOutOfRange = null) {
    if(num <= 6) {
        if(isOutOfRange != null) {
            isOutOfRange();
            return;
        } else {
            throw new ArgumentOutOfRangeException();
        }
    }
    num +=3 
}
```
My goodness, doesn't that look like a head ache? I don't like repeating the curly braces, I don't like having to write an if statement at the top of every function, and I don't like repeating myself. Bad, bad, bad. But, good news! There's a better way.
```
public void Add3IfAbove6(ref int num, Action isOutOfRange = null) => Perform(num > 6, 
    (isOutOfRange, new ArgumentOutOfRangeException()), () => num += 3);
```
or 
```
public void Add3IfAbove6(ref int num, Action isOutOfRange = null) => Perform(num > 6, 
    (isOutOfRange, new ArgumentOutOfRangeException()), 
    () => num += 3);
```
Again, we have dropped from this ridiculously ugly, oft repeated code to a mere 2 lines. You may prefer the 3 line version in some cases, but either way, we've cut out 7 or 8 lines of code, and can express success-only code. Isn't that beautiful? You have full control over your failures, and you've added no extra lines. Both try-catch and dependency injection work at the same time! But what about more complicated functions?

What happens if we have a function that has 3 functions for injection, 3 different cases for failure, and 3 different test cases that are entirely separate?

Let's say we need to register a player for a game, and we need to know their name, age, and email (very common cases). But, we want to ensure that the player is not lying to us. They have to be above 14 to play, but not beyond 125. Their name can not be empty, and their email address has to be valid. 
```
void ValidateDetails(string name, uint age, string email, Action onInvalidName = null, Action onInvalidAge = null, Action onInvalidEmail = null) {
    if(name.Length == 0) {
        if(onInvalidName != null) {
            onInvalidName();
            return;
        } else {
            throw new InvalidNameException();
        }
    }
    if(age < 14 || age > 125) {
        if(onInvalidName != null) {
            onInvalidName();
            return;
        } else {
            throw new InvalidAgeException();
        }
    }
    // Let's assume ValidateEmail exists somewhere
    if(!ValidateEmail(email)) {
        if(onInvalidEmail != null) {
            onInvalidEmail();
            return;
        } else {
            throw new InvalidEmailException();
        }
    }
    // Function that pushes player details to the database
    AddNewPlayer(name, age, email);
}
```
Jiminy Christmas, that's some code we got there. Can you imagine having to write this without a framework for EVERY SINGLE function? That would drive me insane to the point where I'd call Dependency Injection stupid and useless. But, fear not, because I thought of this.
```
void ValidateDetails(string name, uint age, string email, Action onInvalidName = null, Action onInvalidAge = null, Action onInvalidEmail = null) => Perform(
    (name.Length > 0, onInvalidName, new InvalidNameException()),
    (age > 13, age < 126, onInvalidAge, new InvalidAgeException()),
    (ValidateEmail(email), onInvalidEmail, new InvalidEmailException()),
    () => AddNewPlayer(name, age, email));
```
Now, would ya look at that. Our 26 manually written lines of code have been shortened to a mere 5 lines of code. That's a 21 line reduction! But let me break down what's happening. Each of those 3 lines before the final is called an assurance.

Assurances ensure that a condition is true, and if it is not, it handles how it fails. You have up to 9 assurances on a Perform call, followed by the succcess code. But what happens if you only want to throw an exception? Well, just throw the exception.
```
void ValidateDetails(string name, uint age, string email) => Perform(
    (name.Length > 0, new InvalidNameException()),
    (age > 13, age < 126, new InvalidAgeException()),
    (ValidateEmail(email), new InvalidEmailException()),
    () => AddNewPlayer(name, age, email));
```
What happens if you don't want to throw an exception? Well. Don't give an exception. 
```
void ValidateDetails(string name, uint age, string email, Action onInvalidName = null, Action onInvalidAge = null, Action onInvalidEmail = null) => Perform(
    (name.Length > 0, onInvalidName),
    (age > 13, age < 126, onInvalidAge),
    (ValidateEmail(email), onInvalidEmail),
    () => AddNewPlayer(name, age, email));
```
Something important to know is that assurances are run in-order, and do not fall through to the others. The assurances are not checked, tested, ran, or even looked at once a single assurance has failed and the failure code has been executed.


## Assure and Assurances
An "assurance" is an object that contains a test condition, a failure function, and an exception. 3 forms of tuples implicitly convert to an Assurance. `(bool, Action, Exception)`, `(bool, Exception)`, and `(bool, Action)`, hence the black-magic code you saw in the Perform function. Without the usage of dependency injected functions, Assurances are useless. Just use the Perform function. Seriously. But, below is an example of the Assurance usage.
```
string Name = "Frank";

public bool IsFrank(string nam, Action onIsNotFrank = null) => Assure(name == "Frank", onIsNotFrank, new IsNotFrankException());
public bool YellIfNotFrank(string name) => IsFrank(nam, () => Console.WriteLine("GET OFF MY LAWN! YOU'RE NOT FRANK!"));
```

## DoOrThrow
Unfortunately, there are times where you want to return a value, instead of just having an action be performed with no return. A perform does not (yet) support this. But, do not worry, for I have thought of this too. 

```
public int Add3IfAbove6(int num, Action isBelow7 = null) {
    if(num <= 6) {
        DoOrThrow(isBelow7, new ArgumentOutOfRangeException());
        return num;
    }
    return num + 3;
}
```

## ThrowIf
I asked the question, what happens if you only want to throw an exception under a specific circumstance? Well. `ThrowIf`.
`ThrowIf(name != "Frank", new IsNotFrankException());`

## DoNothing
What happens if you're speccing out a class, and you have no idea what you want something to do, but you know what signature the function is supposed to have?
```
public void Add3(ref int num) => DoNothing();
public void Mult3(ref int num) => DoNothing();
```
I find this one really easy because if you autoformat, it'll always keep these to a single line (assuming you haven't gone ballistic with your formatting rules).

## Nothing
What happens if you want to have a function that returns the "null" or "default" value of anything?
```
public int Add3(int num) => Nothing<int>();
```


## Compose
If you have a bunch of functions with the same signature that you want to combine, you can do that. Just keep in mind that if you are executing a compose, objects are best to use in this case.
```
public void Read() => DoNothing();
public void Breathe() => DoNothing();
public void Exist() => Compose(Read, Breathe);
```
or
```
public static void Read(Player psn) => psn.Read();
public static void Breathe(Player psn) => psn.Breathe();
public static void Exist(Player psn) => Compose(psn, Read, Breath);
```
If you do a compose where you have an argument, the signature of every function must match. No function returns anything. That's what a pipeline is for.

## Pipe
Lets say you have you want to do many things to a single value. Generally, you'd do something like this.
```
int Add3(int num) => num + 3;
int Mult2(int num) => num * 2;
int Add3ThenMult2(int num) => Mult2(Add3(num)); // Result: 2(x + 3)
```
This is is extremely easy to mess up, mixing the orders, and just creates a huge head ache. Why not do this instead?
```
int Add3(int num) => num + 3;
int Mult2(int num) => num * 2;
int Add3ThenMult2(int num) => Pipe(num, Add3, Mult2);
```
As you can see, you are taking num, and in order, passing num to Add3 first, then to Mult2. This approach allows you to visualize the pipeline of functions in the order they are happening. Just remember 1 in 1 out, both of the same kind.

## Smallest
Does not really require much description. Just pass a bunch of numbers to Smallest, and the Smallest of all of them is chosen.
```
Smallest(2, 56, 8, 3, 1, -22, 7);
```
##
