// Impure
const greetWithDate = (greeting: string) => {
    return `Today is ${new Date()}. ${greeting}`;
}

greetWithDate("Hope you are doing okay!");

// Pure
const greetWithDatePure = (greeting: string, date: Date) => {
    return `Today is ${date}. ${greeting}`;
}

// Impure
enum Priority {
    Info = "[INFO]",
    Warn = "[WARN]",
    Critical = "[CRITICAL]"
}

const logMessage = (priority: Priority, message: string) => {
    console.log(`${priority} ${message}`);
}

// Pure
type Logger = (msg: string) => void;

const logMessagePure = (logger: Logger, priority: Priority, message: string) => {
    logger(`${priority} ${message}`);
}