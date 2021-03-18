using System;
using System.Collections.Generic;

public static class Fn
{
    public static TU Pipe<T, TU>(this T input, Func<T, TU> fun) => fun(input);
    public static (TP1, TP2) Pipe<T, TP1, TP2>(this T input, Func<T, (TP1, TP2)> fun) => fun(input);
    public static T Pipe<TP1, TP2, T>(this (TP1, TP2) input, Func<TP1, TP2, T> fun) => fun(input.Item1, input.Item2);
    public static (TP3, TP4) Pipe<TP1, TP2, TP3, TP4>(this (TP1, TP2) input, Func<TP1, TP2, (TP3, TP4)> fun) => fun(input.Item1, input.Item2);
    public static void Pipe<T>(this T input, Action<T> fun) => fun(input);
    public static void Pipe<TP1, TP2>(this (TP1, TP2) input, Action<TP1, TP2> fun) => fun(input.Item1, input.Item2);

    public static void ForEach<T>(this IEnumerable<T> ts, Action<T> fun)
    {
        foreach (var t in ts)
        {
            fun(t);
        }
    }
}