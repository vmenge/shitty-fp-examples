// Regular Function, Tupled function
// (number, number) -> number
const add2 = (x: number, y: number) => x + y;

// Curried Function
// number -> number -> number
const add2_c = (x: number) => (y: number) => x + y;

// Partial Application
const add10 = add2_c(10);

add10(5); // returns 15



// Regular Pure Function
// (MessageLogger, Priority, string) -> void
const loggerMaker = (logger: Logger, priority: Priority, message: string) => {
    logger(`${priority} ${message}`);
}

// Curried Function
// Logger -> Priority -> string -> void
const customLog = (logger: Logger) => (priority: Priority) => (message: string) => {
    logger(`${priority} ${message}`);
}

// Partial Application
const clogger = customLog(console.log);
const criticalLog = clogger(Priority.Critical);
const infoLog = clogger(Priority.Info);

criticalLog("Oh no something broke!");
infoLog("Starting server...");


// Partial Application done by wrapping 
const warnLog = (message: string) => {
    return loggerMaker(console.log, Priority.Warn, message);
}