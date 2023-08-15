using System.Diagnostics;

namespace MediaDownloader.Tools
{
    public static class Shell
    {
        public static void StartProcess(string processName, string arguments, string windowTitle, bool displayOutput, bool pauseOutput)
        {
            ProcessStartInfo processInfo = new ProcessStartInfo();
            processInfo.FileName = "cmd.exe";
            processInfo.Arguments = (pauseOutput ? "/k " : "/c ") + " title " + windowTitle + " & " + processName + " " + arguments;
            processInfo.CreateNoWindow = !displayOutput;
            processInfo.UseShellExecute = false;

            Process process = new Process();
            process.StartInfo = processInfo;
            process.Start();
            process.WaitForExit();
        }
    }
}