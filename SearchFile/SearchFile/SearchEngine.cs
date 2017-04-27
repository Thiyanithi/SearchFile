namespace SearchFile
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;

    /// <summary>
    /// SearchEngine class.
    /// </summary>
    public class SearchEngine
    {
        /// <summary>
        /// files taken all file path in Config_file
        /// </summary>
        private string files = string.Empty;

        /// <summary>
        /// How many file or files to matched 
        /// </summary>
        private int count = 0;

        /// <summary>
        /// Group of words
        /// </summary>
        private string sentence = string.Empty;

        /// <summary>
        /// Search file method
        /// </summary>
        /// <param name="filepath">contain all file path</param>
        /// <param name="words">contains collections of words</param>
        public void Searchfile(string[] filepath, string[] words)
        {
            if (words.Length == 2)
            {
                Console.WriteLine("\tMatching One Single Word Conditions Apply\n");
                for (int i = 0; i < filepath.Length - 1; i++)
                {
                    var filewords = File.ReadAllText(filepath[i]).Split(new[] { ' ' });

                    foreach (string word in filewords)
                    {
                        if (word == words[1])
                        {
                            this.files = string.Empty;
                            this.files = this.files + " " + filepath[i];
                            Console.WriteLine("{0}", this.files);
                            this.count += 1;
                            break;
                        }
                        else
                        {
                            continue;
                        }
                    }
                }

                Console.WriteLine("\n\t\t {0} File(s) Match.", this.count);
            }
            else if (words[1] == "-o")
            {
                if (words.Length == 4)
                {
                    Console.WriteLine("\t OR Conditions Applied in Both Words\n");
                    for (int i = 0; i < filepath.Length - 1; i++)
                    {
                        var fileinformations = File.ReadAllText(filepath[i]).Split(new[] { ' ' });

                        foreach (string word in fileinformations)
                        {
                            if (word == words[2] || word == words[3])
                            {
                                this.files = string.Empty;
                                this.files = this.files + " " + filepath[i];
                                Console.WriteLine("{0}", this.files);
                                this.count += 1;
                                break;
                            }
                            else
                            {
                                continue;
                            }
                        }
                    }

                    Console.WriteLine("\n\t\t {0} File(s) Match.", this.count);
                }
                else
                {
                    Console.WriteLine("Syntax Error:\n\t Please Enter Valid Syntax\n\n");
                    SearchFile objSearchFile = new SearchFile();
                    objSearchFile.Validations();
                }
            }
            else if (words[1] == "-f")
            {
                Console.WriteLine("\t Matching group of words or sentence\n");
                for (int word = 2; word <= words.Length - 1; word++)
                {
                    this.sentence = this.sentence + " " + words[word];
                }

                for (int path = 0; path < filepath.Length - 1; path++)
                {
                    FileStream inFile = new FileStream(filepath[path], FileMode.Open, FileAccess.Read);
                    StreamReader reader = new StreamReader(inFile);
                    string record;
                    try
                    {
                        record = reader.ReadLine();
                        while (record != null)
                        {
                            if (record.Contains(this.sentence))
                            {
                                this.files = string.Empty;
                                this.files = this.files + " " + filepath[path];
                                Console.WriteLine("{0}", this.files);
                                this.count += 1;
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    finally
                    {
                        reader.Close();
                        inFile.Close();
                    }
                }

                Console.WriteLine("\n\t\t {0} File(s) Match.", this.count);
            }
            else
            {
                if (words.Length == 3)
                {
                    Console.WriteLine("\t AND Conditions Applied in Both Words\n");
                    for (int i = 0; i < filepath.Length - 1; i++)
                    {
                        var fileinformations = File.ReadAllText(filepath[i]).Split(new[] { ' ' });

                        foreach (string word1 in fileinformations)
                        {
                            if (word1 == words[1])
                            {
                                foreach (string word2 in fileinformations)
                                {
                                    if (word2 == words[2])
                                    {
                                        this.files = string.Empty;
                                        this.files = this.files + " " + filepath[i];
                                        Console.WriteLine("{0}", this.files);
                                        this.count += 1;
                                        break;
                                    }
                                    else
                                    {
                                        continue;
                                    }
                                }

                                break;
                            }
                            else
                            {
                                continue;
                            }
                        }
                    }

                    Console.WriteLine("\n\t\t {0} File(s) Match.", this.count);
                }
                else
                {
                    Console.WriteLine("Syntax Error:\n\t Please Enter Valid Syntax\n\n");
                    SearchFile objSearchFile = new SearchFile();
                    objSearchFile.Validations();
                }
            }   
        }
    }
}
