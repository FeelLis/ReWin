namespace ReWin
{
    class Program
    {
        static public TextReader reader = Console.In;

        static private void PrintMenu()
        {
            Writer.Output("\nReWin", color: ConsoleColor.Blue);
            Writer.Output("!help for help");
            Writer.Output("1. Install programs");
            Writer.Output("exit for exit");
        }

        static void Main(string[] args)
        {
            PrintMenu();

            string input = "";
            Writer.Output("> ", endl: false);
            input = Program.reader.ReadLine() ?? "";
            string[] commands = input.Split(' ');
            
            while(commands[0] != "exit")
            {
                switch (commands[0])
                {
                    case "1":
                        Choco choco = new Choco();
                        choco.Menu();
                        break;
                    default:
                        Writer.Error("Incorrect choise");
                        break;  
                }

                PrintMenu();
                Writer.Output("> ", endl: false);

                input = Program.reader.ReadLine() ?? "";
                commands = input.Split(' ');
            }
        }        
    }
}