using System;
using LanguageExt;
using static System.Console;
using static LanguageExt.Prelude;

static class OptionExample
{
    // Mapping abstract types
    public static void Example()
    {
        Option<string> example = None;
        Option<string> example2 = Some("thing");
        Option<string> example3 = "thing";

        // ReadLine: () -> string
        var input = ReadLine();

        // parseInt: string -> Option<int>

        // Option<int>
        var parsedInput = parseInt(input);

        // still Option<int>
        var doubledInput = parsedInput.Map(x => x * 2);
        var stringifiedInput = doubledInput.Map(x => x.ToString());

        var capitalize = fun((string x) => x.ToUpper());

        var actualValue = stringifiedInput.Match(
           Some: capitalize,
           None: () => "error somewhere"
        );
    }

    static Func<int, Option<int>> ValidateAge =>
        age => age is < 0 or > 120 ? None : age;

    // Flat Mapping abstract types, no multiple if statements
    public static void NestedExample()
    {
        var input = ReadLine();
        var parsedInput = parseInt(input);

        // Option<Option<int>> Oh no, a nested Option! 
        var nestedAge = parsedInput.Map(ValidateAge);

        // Bind is .flatMap!
        // C<T> => (T -> C<R>) -> C<R>
        // Option<int> => (int -> Option<int>) -> Option<int>
        var age = parsedInput.Bind(ValidateAge);

        var actualValue = age.Match(
            Some: age => age,
            None: () => 0
        );
    }

    static Func<int, int> DuplicateAge =>
        age => age * 2;

    public static void PipedExample() =>
        ReadLine()
            .Pipe(parseInt)
            .Bind(ValidateAge)
            .Map(DuplicateAge)
            .Match(
                Some: age => WriteLine($"You're age doubled is {age}"),
                None: () => WriteLine("Something went wrong!")
            );
}


