using System;
using static LanguageExt.Prelude;

static class PartialApplication
{
    // (int, int) -> int
    static Func<int, int, int> Add2Numbers =>
        (x, y) => x + y;

    // int -> int -> int
    static Func<int, Func<int, int>> ManuallyCurriedAdd2Numbers =>
        x => y => x + y;

    public static void Example()
    {
        var curriedAdd2Numbers = curry(Add2Numbers); // returns a function x => y => x + y
        var add10 = curriedAdd2Numbers(10);
        add10(5); // returns 15

        var add30 = ManuallyCurriedAdd2Numbers(30);
        add30(100); // returns 130
    }

    enum Priority
    {
        Info,
        Warn,
        Critical
    }

    // Start thinking of every function as curriable / partially applicable
    // (string -> void) -> Priority -> string -> void
    static Action<Action<string>, Priority, string> LoggerMaker =>
        (logger, priority, message) => logger($"{priority} {message}");

    static Action<Priority, string> CLogger =>
        (priority, message) => LoggerMaker(Console.WriteLine, priority, message);

    static Action<string> LogInfo =>
        message => CLogger(Priority.Info, message);

    public static void Example2()
    {
        var cLogger = par(LoggerMaker, Console.WriteLine);
        var logInfo = par(cLogger, Priority.Info);
        var logCritical = par(cLogger, Priority.Critical);

        logInfo("Starting server...");
        logCritical("Oh shit something broke!");
    }

}