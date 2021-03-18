const num = Promise.resolve(10);

// C<T> => (T -> R) -> C<R>
// Promise<number> => number -> string -> Promise<string>
// .then is .map!
num.then(n => n.toString());

// T -> C<R>
// number -> Promise<string>
const waitAndThenStringify = (n: number) => 
    new Promise(resolve => setTimeout(() => resolve(n.toString()), 500));


// C<T> => (T -> C<R>) -> C<R>
// Promise<number> => (number -> Promise<string>) -> Promise<string>
// .then is .flatMap! we don't get nested promises!
num.then(waitAndThenStringify);