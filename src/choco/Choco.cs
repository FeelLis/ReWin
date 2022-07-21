namespace ReWin
{
    class Choco
    {
        public Choco()
        {
            Terminal.Run(
                message: "Running choco script",
                command: System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location)
                    + "\\scripts\\choco.bat"
            );

            Terminal.Run(
                message: "Enabling global confirmation for choco",
                command: "choco feature enable -n=allowGlobalConfirmation"
            );
        }

        static private void PrintMenu()
        {
            Writer.Output("\nChoco", color: ConsoleColor.Blue);
            Writer.Output("!help for help");
            Writer.Output("1. Essential Programs");
            Writer.Output("2. Developer Programs");
            Writer.Output("3. Useful Programs");
            Writer.Output("Or, if u know package name, just write 'install {name}'");
            Writer.Output("Example: install firefox -> this command will install firefox");
            Writer.Output("4. Back (or exit)");
        }

        public void Menu()
        {
            PrintMenu();

            string input = "";
            Writer.Output("> ", endl: false);
            input = Program.reader.ReadLine() ?? "";
            string[] commands = input.Split(' ');

            while(commands[0] != "exit")
            {
                if(commands[0] == "install")
                {
                    if(commands.Length == 1)
                        Writer.Error("Enter program name");
                    else
                        Install(commands[1]);
                }
                else if(commands[0] == "uninstall")
                {
                    if(commands.Length == 1)
                        Writer.Error("Enter program name");
                    else
                        Uninstall(commands[1]);
                }
                else if (commands[0] == "1")
                {
                    new EssentialPrograms(this);
                }
                else if (commands[0] == "2")
                {
                    new DeveloperPrograms(this);
                }
                else
                {
                    Writer.Error("Incorrect choise, press enter and try again");
                    Program.reader.ReadLine();
                }

                PrintMenu();
                Writer.Output("> ", endl: false);

                input = Program.reader.ReadLine() ?? "";
                commands = input.Split(' ');
            }
            
        }

        public void Install(string name)
        {
            Terminal.Run(
                message: $"Installing {name}",
                command: $"choco install {name} -y"
            );
        }

        public void Uninstall(string name)
        {
            Terminal.Run(
                message: $"Uninstalling {name}",
                command: $"choco uninstall {name} -y"
            );
        }

        ~Choco()
        {
            Terminal.Run(
                message: "Disabling global confirmation for choco",
                command: "choco feature disable -n=allowGlobalConfirmation"
            );
        }
    }
}