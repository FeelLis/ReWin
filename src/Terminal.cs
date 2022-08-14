namespace ReWin
{
    class Terminal
    {
        public static string Run(object command, string message = "", bool output = true)
        {
            if (message != "") 
                Writer.Log(message);

            string result = "";
            var processInfo = new System.Diagnostics.ProcessStartInfo(
                "powershell.exe", "/c " + command);
            processInfo.CreateNoWindow = true;
            processInfo.UseShellExecute = false;
            processInfo.RedirectStandardError = true;
            processInfo.RedirectStandardOutput = true;

            var process = System.Diagnostics.Process.Start(processInfo);
            if (process == null) return result;

            process.OutputDataReceived += (object sender, System.Diagnostics.DataReceivedEventArgs e) =>
            {
                if(e.Data != null)
                {
                    Writer.Output("" + e.Data);
                    result = e.Data;
                }
            };
            process.BeginOutputReadLine();

            process.ErrorDataReceived += (object sender, System.Diagnostics.DataReceivedEventArgs e) =>
            {
                if(e.Data != null) 
                {
                    Writer.Error("" + e.Data);
                    result = e.Data;
                }
            };
            process.BeginErrorReadLine();

            process.WaitForExit();
            process.Close();
            
            return result;  
        }
    }
}