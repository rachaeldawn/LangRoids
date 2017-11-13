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
| ContainsAll | Does collection A contain everything that collection B does |
| Nothing | A function that returns the default for a type |
| Nullify | Set a variable to its default |
| DoNothing | A function that does nothing. |


# The Manual

I built these functions to minimize linecount, and express a sense of order, without the extra keywords. As such, there's a styling that I use to avoid the code getting ugly, and when you start to understand what is going on, you will find this to be a much more elegant means through which you can express instructions. Most of the code is built around the lambda syntax indicating that something is going on, or tuples to imply options.


# Things that do stuff

## Perform

**NEEDS REWRITE**


## Assure and Assurances
An "assurance" is an object that contains a test condition, a failure function, and an exception. 3 forms of tuples implicitly convert to an Assurance. `(bool, Action, Exception)`, `(bool, Exception)`, and `(bool, Action)`, hence the black-magic code you saw in the Perform function. Without the usage of dependency injected functions, Assurances are useless. Just use the Perform function. Seriously. But, below is an example of the Assurance usage.
```
string Name = "Frank";

public bool IsFrank(string nam, Action onIsNotFrank = null) => Assure<IsNotFrankException>(name == "Frank", onIsNotFrank);
public bool YellIfNotFrank(string name) => IsFrank(nam, () => Console.WriteLine("GET OFF MY LAWN! YOU'RE NOT FRANK!"));
```

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
