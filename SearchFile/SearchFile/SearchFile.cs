namespace SearchFile
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;

    /// <summary>
    /// SearchFile class.
    /// </summary>
    public class SearchFile
    {
        /// <summary>
        /// Types of commands
        /// </summary>
        private enum Command 
        { 
            /// <summary>
            /// Represents exit in console window
            /// </summary>
            exit, 

            /// <summary>
            /// Represents search-file
            /// </summary>
            searchfile
        }

        /// <summary>
        /// Main function
        /// </summary>
        /// <param name="args">args is a command line arguments</param>
        public static void Main(string[] args)
        {
            SearchFile objSearchFile = new SearchFile();
            objSearchFile.Show_information();
            objSearchFile.Validations();
            objSearchFile.Control();
        }

        /// <summary>
        /// This function used to display the information about user
        /// </summary>
        public void Show_information()
        {
            Console.WriteLine("\n\n\tSearches for a text string in a file or files\n");
            Console.WriteLine("searchfile [-o] [-f] 'string' ['string']\n");
            Console.WriteLine(" searchfile   - Is a command(SYNTAX), search file or files contains configure file");
            Console.WriteLine(" -o           - Displays list all files that contains either string1 OR string2");
            Console.WriteLine(" -f           - Displays list all files that contains matching full string(group of words)");
            Console.WriteLine(" whitespace   - Displays list all files that contains both string1 AND string2");
            Console.WriteLine("\n\nExamples:\n");
            Console.WriteLine(" 1. Matching One Single Word:\n\t :>searchfile 'string'");
            Console.WriteLine("\n 2. OR Conditions apply:\n\t :>searchfile -o 'string' 'string'");
            Console.WriteLine("\n 3. AND Conditions apply:\n\t :>searchfile 'string' 'string'");
            Console.WriteLine("\n 4. -f apply:\n\t :>searchfile -f 'group of words'");
            Console.WriteLine("\nIf find searches the text typed at the prompt\n");            
        }

        /// <summary>
        /// This function is used to validate a user commands
        /// </summary>
        public void Validations()
        {
            try
            {
                Console.Write(":>");
                string cmdLineValue = Console.ReadLine();
                string[] words = cmdLineValue.Split(' ');
                string files = string.Empty;
                if (words[0] == Command.searchfile.ToString())
                {
                    if (words.Length >= 2)
                    {
                        Console.WriteLine("\n");
                        string allfile = string.Empty;
                        string initialpath = Directory.GetCurrentDirectory() + "\\Config_file.txt";
                        var configurefileinfo = File.ReadAllLines(initialpath);
                        foreach (string file in configurefileinfo)
                        {
                            files = file + "\n" + files;
                        }

                        var filepath = Regex.Split(files, "\r\n|\r|\n");
                        for (int path = 0; path < filepath.Length - 1; path++)
                        {
                            foreach (string file in Directory.EnumerateFiles(Path.GetDirectoryName(filepath[path]), Path.GetFileName(filepath[path])))
                            {
                                allfile = file + "\n" + allfile;
                            }
                        }

                        var filepaths = Regex.Split(allfile, "\r\n|\r|\n");
                        SearchEngine objSearchEngine = new SearchEngine();
                        objSearchEngine.Searchfile(filepaths, words);
                    }
                    else
                    {
                        Console.WriteLine("\nRequired 2 or more than 2 arguments\n");
                        this.Validations();
                    }
                }
                else if (words[0] == Command.exit.ToString())
                {
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("\n'{0}' is not an valid command\n", words[0]);
                    this.Validations();
                }
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("\nFile not Exist or Not Match in File Type");
            }
        }

        /// <summary>
        /// This function is used to till waiting for console window in customer command 
        /// </summary>
        public void Control()
        {
            bool on = true;
            do
            {
                Console.WriteLine("\n");
                this.Validations();
                on = true;
            }
            while (on);
        }
    }
}