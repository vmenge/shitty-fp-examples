// Array<T> is an elevated type, an abstraction
const numbers: Array<number> = [1, 2, 3, 4];

// number -> number
const double = (x: number) => x * 2;

// Array<T> is a functor
numbers.map(double); // [2, 4, 6, 8]

// Functor is any structure that can be used with function:
// C<T> => (T -> R) -> C<R>

numbers.map(n => n.toString()); // ["1", "2", "3", "4"]

// T -> R
// number -> string
const stringify = (num: number): string => num.toString();

// Array<number> => (number -> string) -> Array<string>
numbers.map(stringify); // ["1", "2", "3", "4"]


const nums = [500, 666];

// Map holds true with nested values
// Array<number> => (number -> Array<string>) -> Array<Array<string>>
nums.map(n => n.toString().split('')); // [["5", "0", "0"], ["6", "6", "6"]]

// Monad is anything that can be used with function:
// C<T> => (T -> C<R>) -> C<R>
// Array<number> => (number -> Array<string>) -> Array<string>
nums.flatMap(n => n.toString().split('')); // ["5", "0", "0", "6", "6", "6"]

// T -> C<R>
// number -> Array<string>
const getChars = (n: number) => n.toString().split('');