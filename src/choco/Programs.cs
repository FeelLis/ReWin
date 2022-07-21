namespace ReWin
{
    abstract class Programs
    {
        protected Choco choco;
        protected Programs(Choco ch)
        {
            choco = ch;
        }

        abstract public void PrintMenu();
        virtual public void Menu()
        {
            PrintMenu();

            string input = "";
            Writer.Output("> ", endl: false);
            input = Program.reader.ReadLine() ?? "";
            string[] commands = input.Split(' ');
            
            while(commands[0].ToLower() != "exit")
            {
                if(commands[0].ToLower() == "install")
                    Installator(commands);
                else
                {
                    Writer.Error("Incorrect input, press enter and try again");
                    Program.reader.ReadLine();
                }

                PrintMenu();
                Writer.Output("> ", endl: false);

                input = Program.reader.ReadLine() ?? "";
                commands = input.Split(' ');
            }
        }
        abstract protected void Installator(string[] commands);
    }
}