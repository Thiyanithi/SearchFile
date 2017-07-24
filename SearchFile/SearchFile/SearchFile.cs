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
        /// Any query return to the validation function
        /// </summary>
        string query = string.Empty;

        /// <summary>
        /// Main function
        /// </summary>
        /// <param name="args">args is a command line arguments</param>
        public static void Main(string[] args)
        {
            SearchFile objSearchFile = new SearchFile();
            SearchFileInformation objSearchFileInformation = new SearchFileInformation();
            objSearchFileInformation.Show_information();
            string validationresult = string.Empty;
            do
            {
                validationresult = objSearchFile.Validations();
                Console.WriteLine(validationresult);
            }
            while (validationresult != string.Empty);
            
            objSearchFile.Control();
        }

        /// <summary>
        /// This function is used to validate a user commands
        /// </summary>
        public string Validations()
        {
            try
            {
                Console.Write(":>");
                string cmdLineValue = Console.ReadLine();
                string[] words = cmdLineValue.Split(' ');
                string files = string.Empty;
                query = string.Empty;
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
                        string matchingresults = objSearchEngine.Searchfile(filepaths, words);
                        if (matchingresults == "Syntax Error:\n\t Please Enter Valid Syntax\n")
                        {
                            Console.WriteLine(matchingresults.Remove(matchingresults.Length - 1, 1));
                        }
                        else
                        {
                            Console.WriteLine(matchingresults.Remove(matchingresults.Length - 1, 1));
                            var matchingnooffile = Regex.Split(matchingresults, "\r\n|\r|\n");
                            Console.WriteLine("\n\t\t {0} File(s) Match.", (matchingnooffile.Length - 2));
                        }
                    }
                    else
                    {
                        this.query = "\nRequired 2 or more than 2 arguments\n";
                    }
                }
                else if (words[0] == Command.exit.ToString())
                {
                    Environment.Exit(0);
                }
                else
                {
                    this.query = "\n'" + words[0] + "' is not an valid command\n";
                }
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("\nFile not Exist or Not Match in File Type");
            }
            catch(FileNotFoundException)
            {
                Console.WriteLine("\nFile not Found in a current Directory");
            }
            return this.query;
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