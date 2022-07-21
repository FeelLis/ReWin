namespace ReWin
{
    class EssentialPrograms : Programs
    {
        public EssentialPrograms(Choco ch) : base(ch)
        {    
            Menu();
        }

        override public void PrintMenu()
        {
            Writer.Output("\nEssential Programs", color: ConsoleColor.Blue);
            Writer.Output("The program is going to install applications from the following list:");

            Writer.Output("\ngooglechrome", color: ConsoleColor.Yellow);
            Writer.Output(":: Chrome is a cross-platform web browser.");
            Writer.Output(":: https://www.google.com/intl/en/chrome/");

            Writer.Output("\nqbittorrent", color: ConsoleColor.Yellow);
            Writer.Output(":: QBitTorrent is a free and open-source BitTorrent client.");
            Writer.Output(":: https://www.qbittorrent.org/");
            Writer.Output(":: Like a popular uTorrent, but better.");
            
            Writer.Output("\npowertoys", color: ConsoleColor.Yellow);
            Writer.Output(":: PowerToys is a set of freeware system utilities");
            Writer.Output(":: https://docs.microsoft.com/en-us/windows/powertoys/");

            Writer.Output("\neverything", color: ConsoleColor.Yellow);
            Writer.Output(":: Everything is search engine that locates files and folders by filename instantly.");
            Writer.Output(":: https://www.voidtools.com/");
            Writer.Output(":: Very fast search, and also finds something that Windows does not show.");

            Writer.Output("\n7zip", color: ConsoleColor.Yellow);
            Writer.Output(":: 7zip is a free and open-source file archiver.");
            Writer.Output(":: https://www.7-zip.org/");

            Writer.Output("\nvlc", color: ConsoleColor.Yellow);
            Writer.Output(":: VLC is a free and open-source media player software and streaming media server.");
            Writer.Output(":: https://www.videolan.org/vlc/index.en.html");

            Writer.Output("\ntelegram", color: ConsoleColor.Yellow);
            Writer.Output(":: Telegram is a freemium, cross-platform, cloud-based instant messaging service.");
            Writer.Output(":: https://web.telegram.org/");

            Writer.Output("\ndiscord", color: ConsoleColor.Yellow);
            Writer.Output(":: Discord is a VoIP, instant messaging and digital distribution platform.");
            Writer.Output(":: https://discord.com/");

            Writer.Output("\nzoom", color: ConsoleColor.Yellow);
            Writer.Output(":: Zoom is a proprietary video teleconferencing software program.");
            Writer.Output(":: https://zoom.us/");

            Writer.Output("\nsharex", color: ConsoleColor.Yellow);
            Writer.Output(":: ShareX is a free and open source program that lets you capture or record any area of your screen and share it.");
            Writer.Output(":: https://getsharex.com/");
            

            Writer.Output("\nYou can choose which applications NOT to install with the command -{name}");
            Writer.Output("For example: install -powertoys -7zip -sharex");
            Writer.Output("Exit to go back\n");
        }

        override protected void Installator(string[] commands)
        {
            string[] programs_list = {
                "googlechrome",
                "qbittorrent",
                "powertoys",
                "everything",
                "7zip",
                "vlc",
                "telegram",
                "discord",
                "zoom",
                "sharex",
            };

            Terminal.Run(
                command: "choco install " + string.Join("; choco install ", programs_list.Where(program => commands.Any(c => program.Contains(c.Substring(1)))))
            );
        }

    }
}