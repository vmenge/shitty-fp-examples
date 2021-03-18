type Person = Readonly<{
    name: string;
    age: number
}>;

var person: Person = {
    name: 'Victor',
    age: 29
};

var updatedPerson =  {
    ...person,
    age: 30
};