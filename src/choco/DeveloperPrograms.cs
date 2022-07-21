namespace ReWin
{
    class DeveloperPrograms : Programs
    {
        public DeveloperPrograms(Choco ch) : base(ch)
        {    
            Menu();
        }

        override public void PrintMenu()
        {
            Writer.Output("\nEssential Programs", color: ConsoleColor.Blue);
            Writer.Output("The program is going to install applications from the following list:");

            Writer.Output("\ngithub-desktop", color: ConsoleColor.Yellow);
            Writer.Output(":: Nice git UI from GitHub.");
            Writer.Output(":: https://desktop.github.com/");

            Writer.Output("\nnotepadplusplus", color: ConsoleColor.Yellow);
            Writer.Output(":: Notepad++ is a text and source code editor for use.");
            Writer.Output(":: https://notepad-plus-plus.org/downloads/");
            
            Writer.Output("\nvscode", color: ConsoleColor.Yellow);
            Writer.Output(":: Visual Studio Code is a source-code editor made by Microsoft.");
            Writer.Output(":: https://docs.microsoft.com/en-us/windows/powertoys/");

            Writer.Output("\nprocexp", color: ConsoleColor.Yellow);
            Writer.Output(":: Process Explorer is a freeware task manager and system monitor.");
            Writer.Output(":: https://docs.microsoft.com/en-us/sysinternals/downloads/process-explorer");

            Writer.Output("\nprocmon", color: ConsoleColor.Yellow);
            Writer.Output(":: The tool monitors and displays in real-time all file system activity on a Microsoft Windows or Unix-like operating system.");
            Writer.Output(":: https://docs.microsoft.com/en-us/sysinternals/downloads/procmon");

            Writer.Output("\nautoruns", color: ConsoleColor.Yellow);
            Writer.Output(":: Autoruns shows you what programs are configured to run during system bootup or login.");
            Writer.Output(":: https://docs.microsoft.com/en-us/sysinternals/downloads/autoruns");

            Writer.Output("\nfiddler", color: ConsoleColor.Yellow);
            Writer.Output(":: Web debugging proxy tool.");
            Writer.Output(":: https://www.telerik.com/fiddler");

            Writer.Output("\nwireshark", color: ConsoleColor.Yellow);
            Writer.Output(":: Wireshark is a free and open-source packet analyzer.");
            Writer.Output(":: https://www.wireshark.org/");
            

            Writer.Output("\nYou can choose which applications NOT to install with the command -{name}");
            Writer.Output("For example: install -powertoys -7zip -sharex");
            Writer.Output("Exit to go back\n");
        }

        override protected void Installator(string[] commands)
        {
            string[] programs_list = {
                "github-desktop",
                "notepadplusplus",
                "vscode",
                "procexp",
                "procmon",
                "autoruns",
                "fiddler",
                "wireshark",
            };

            Terminal.Run(
                command: "choco install " + string.Join("; choco install ", programs_list.Where(program => commands.Any(c => program.Contains(c.Substring(1)))))
            );
        }

    }
}