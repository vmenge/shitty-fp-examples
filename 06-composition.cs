using System;
using static LanguageExt.Prelude;

static class Composition
{
    // Regular way
    // () -> string
    static Func<string> GetName =>
       () => Console.ReadLine();

    // string -> string -> string
    static Func<string, string, string> AddGreeting =>
        (greeting, name) => $"{greeting} {name}!";

    // int -> string
    static Action<int, string> PrintXTimes =>
        (times, message) => Range(0, times).ForEach(Console.WriteLine);

    public static void Example()
    {
        var name = GetName();
        var message = AddGreeting("Hey", name);
        PrintXTimes(3, message);
    }


    // Composing
    // string -> string
    static Func<string, string> AddGangstaGreeting =>
        name => AddGreeting("Yo", name);

    // string -> void
    static Action<string> Print10Times =>
        message => PrintXTimes(10, message);

    public static void Example2() =>
        GetName()
            .Pipe(AddGangstaGreeting)
            .Pipe(Print10Times);
}