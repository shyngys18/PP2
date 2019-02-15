using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Task
{
    class Program
    {
        class window
        {
            public FileSystemInfo[] list; // a list of files in the current window
            public int cursor;  // index of a cursor
            public window(FileSystemInfo[] list2)
            { // initialize values
                list = list2;
                cursor = 0;
            }
            public void draw()
            {
                Console.BackgroundColor = ConsoleColor.DarkBlue; // set background color for a window
                Console.ForegroundColor = ConsoleColor.White; // set foreground color
                Console.Clear(); // clear previous window from console

                for (int i = 0; i < list.Length; i++)
                { // iterating through the list
                    if (i == cursor)
                        Console.BackgroundColor = ConsoleColor.DarkGray; // if cursor points to this file, then change background color to highlight
                    else
                        Console.BackgroundColor = ConsoleColor.DarkBlue; // reset backgournd color if it was changed
                    Console.WriteLine(list[i].Name); // print a name of the file
                }
            }
        }
        static void Main(string[] args)
        {
            //new
            string path = @"C:\Users\Shyngys\Desktop\test1"; // path of the root directory
            DirectoryInfo dir = new DirectoryInfo(path); // information about root directory

            Stack<window> windows = new Stack<window>(); // create a stack of windows to be able to restore previous windows
            windows.Push(new window(dir.GetFileSystemInfos())); // add a window for a root

            while (true)
            {
                window cur = windows.Peek(); // get current window from top of the stack
                cur.draw();                 // print this window
                ConsoleKeyInfo k = Console.ReadKey(); // read from keyboard
                if (k.Key == ConsoleKey.UpArrow)
                { // if key is upArrow
                    if (cur.cursor > 0) // if it will not go out of the bounderies
                        cur.cursor--; // move cursor up
                }
                if (k.Key == ConsoleKey.DownArrow)
                { // if key is downArrow
                    if (cur.cursor + 1 < cur.list.Length) // if it will not go out of the bounderies
                        cur.cursor++; // move cursor down
                }
                if (k.Key == ConsoleKey.Enter) // if key is enter
                {
                    string newpath = cur.list[cur.cursor].FullName; // created a path for a file under cursor
                    if (Directory.Exists(newpath)) // if it's directory, create new window in directory path
                        windows.Push(new window((new DirectoryInfo(newpath)).GetFileSystemInfos()));
                    else
                    {
                        var p = new Process(); // create a process
                        p.StartInfo = new ProcessStartInfo(newpath); // set path for the process
                        p.StartInfo.UseShellExecute = true; // make it executable
                        p.Start(); // open it promptly
                    }
                }
                if (k.Key == ConsoleKey.Backspace) // if key is backspace
                {
                    if (windows.Count > 1) // if the number of windows is larger than 1
                        // there must be always at least one window in the stack
                        windows.Pop(); // pop the current window, and return to the previous directory (from which we entered)
                }
                if (k.Key == ConsoleKey.F2) // if key is F2, rename the filename under the cursor
                {
                    Console.WriteLine("Enter new name:"); // ask an user to enter the new name
                    string name = Console.ReadLine(); // new name is red
                    string prev = cur.list[cur.cursor].FullName; // old name

                    string next = Path.Combine(Path.GetDirectoryName(prev), name); // path for the new name
                    Directory.Move(prev, next); // move from old name to the new name (ala rename)
                    cur.list = new DirectoryInfo(Path.GetDirectoryName(prev)).GetFileSystemInfos(); // update current list of files in the current window
                }
                if (k.Key == ConsoleKey.Delete) // if the key is delete, delete under the cursor
                {
                    FileSystemInfo x = cur.list[cur.cursor]; // get info about file under the cursor
                    string xpath = x.FullName; // get file path
                    Console.Clear(); // clear the console
                    Console.WriteLine("Do you want to delete {0} ?\nPress [Y/N]", x.Name); // Ask user to whether to proceed or not.
                    ConsoleKeyInfo res = Console.ReadKey(); // reading a key to obtain an answer for the question
                    while (res.Key != ConsoleKey.Y && res.Key != ConsoleKey.N) // if the pressed key isn't defined in the question then keep pressing the key until Y or N not pressed
                        res = Console.ReadKey(); // read the key

                    if (res.Key == ConsoleKey.Y)
                    {
                        string prDir = Path.GetDirectoryName(xpath); // parent directory of the file
                        if (Directory.Exists(xpath)) // if it's directory
                            Directory.Delete(xpath, true); // delete directory and all subfiles in it recusrively
                        else // if it's a file
                            File.Delete(xpath); // delete the file
                        cur.list = new DirectoryInfo(prDir).GetFileSystemInfos(); // update a list of files in the current window
                    }
                }
            }
            // ConsoleKeyInfo x;
            // x.Key = ConsoleKey.ctrl
            // // when the programm is over, return default color of the window
            // Console.BackgroundColor = ConsoleColor.Black;
        }
    }
}