namespace SearchFile
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class SearchFileInformation
    {
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
            Console.WriteLine("\n 4. -f apply:\n\t :>searchfile -f 'group of words'\n\n");
        }
    }
}
