namespace ReWin
{
    class Writer
    {
        static TextWriter writer = Console.Out;

        public Writer(TextWriter w)
        {
            writer = w;
        }
        
        static public void Output(string message, bool endl = true, ConsoleColor color = ConsoleColor.White)
        {
            System.Console.ForegroundColor = color;
            if (endl)
                writer.WriteLine(message);
            else
                writer.Write(message);
            System.Console.ResetColor();
        }

        static private void Write(string message, string level, ConsoleColor color)
        {
            System.Console.ForegroundColor = color;
            writer.Write($"[{level.ToUpper()}] ");
            System.Console.ResetColor();

            writer.WriteLine(message);
        }

        static public void Log(string message)
        {
            Writer.Write(message, "log", ConsoleColor.Magenta);
        }

        static public void Error(string message)
        {
            Writer.Write(message, "error", ConsoleColor.Red);
        }
        
        static public void Warning(string message)
        {
            Writer.Write(message, "warning", ConsoleColor.Yellow);
        }

        static public void Debug(string message)
        {
            Writer.Write(message, "debug", ConsoleColor.Cyan);
        }
    }
}