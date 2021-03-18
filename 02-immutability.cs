static class Immutability
{
    record Person(string Name, int Age);

    public static void Example()
    {
        var person = new Person(
            Name: "Victor",
            Age: 29
        );

        var updatedPerson = person with { Age = 30 };
    }
}