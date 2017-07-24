namespace TestingSearchFile
{
    using System;
    using System.IO;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using SearchFile;   
    using System.Text.RegularExpressions;
    using System.Diagnostics; 

    /// <summary>
    /// This class is unit testing
    /// </summary>
    [TestClass]
    public class TestSearchFile
    {
        string[] filepath = { "C:/Users/thiyanithi/Desktop/Files/findfile.txt", "C:/Users/thiyanithi/Desktop/Files/computerinfo.txt", "C:/Users/thiyanithi/Desktop/Files/findfile.txt" };

        /// <summary>
        /// This method test the methods for one single word match catogories
        /// </summary>
        [TestMethod]
        public void TestSearchfilefunction_onewordoperations()
        {
            //Arrange
            SearchEngine objSearchEngine = new SearchEngine();

            //Act
            string[] word = "searchfile the".Split(' ');

            //Assert
            string matchingresults = objSearchEngine.Searchfile(filepath, word);
            string expected = "\nC:/Users/thiyanithi/Desktop/Files/findfile.txt\nC:/Users/thiyanithi/Desktop/Files/computerinfo.txt\n2";
            Assert.AreEqual(expected, matchingresults);
            System.Diagnostics.Debug.WriteLine("Test Finished!");
        }

        /// <summary>
        /// This method test the methods for OR catogories
        /// </summary>
        [TestMethod]
        public void TestSearchfilefunction_oroperations()
        {
            //Arrange
            SearchEngine objSearchEngine = new SearchEngine();

            //Act
            string[] word = "searchfile -o the and".Split(' ');

            //Assert
            string matchingresults = objSearchEngine.Searchfile(filepath, word);
            string expected = "\nC:/Users/thiyanithi/Desktop/Files/findfile.txt\nC:/Users/thiyanithi/Desktop/Files/computerinfo.txt\n2";
            Assert.AreEqual(expected, matchingresults);
        }

        /// <summary>
        /// This method test the methods for AND catogories
        /// </summary>
        [TestMethod]
        public void TestSearchfilefunction_andoperations()
        {
            //Arrange
            SearchEngine objSearchEngine = new SearchEngine();

            //Act
            string[] word = "searchfile the and".Split(' ');

            //Assert
            string matchingresults = objSearchEngine.Searchfile(filepath, word);
            string expected = "\nC:/Users/thiyanithi/Desktop/Files/findfile.txt\nC:/Users/thiyanithi/Desktop/Files/computerinfo.txt\n2";
            Assert.AreEqual(expected, matchingresults);
        }

        /// <summary>
        /// This method test the methods for santence matching catogories
        /// </summary>
        [TestMethod]
        public void TestSearchfilefunction_santencematchoperations()
        {
            //Arrange
            SearchEngine objSearchEngine = new SearchEngine();

            //Act
            string[] word = "searchfile -f the and".Split(' ');

            //Assert
            string matchingresults = objSearchEngine.Searchfile(filepath, word);
            string expected = "\n0";
            Assert.AreEqual(expected, matchingresults);
        }

        /// <summary>
        /// This method testing negative test searchfile method
        /// </summary>
        [TestMethod]
        public void TestSearchfilefunction_negativetest()
        {
            //Arrange
            SearchEngine objSearchEngine = new SearchEngine();

            //Act
            string[] word = "searchfile -o the".Split(' ');

            //Assert
            string matchingresults = objSearchEngine.Searchfile(filepath, word);
            string expected = "Syntax Error:\n\t Please Enter Valid Syntax\n";
            Assert.AreEqual(expected, matchingresults);
        }

        /// <summary>
        /// This method testing positive test on validation method
        /// </summary>
        [TestMethod]
        public void TestValidationsmethod()
        {
            //Arrange
            SearchFile objSearchFile = new SearchFile();

            //Act
            using (StringWriter stringwriter = new StringWriter())
            {
                Console.SetOut(stringwriter);
                using (StringReader stringreader = new StringReader(string.Format("searchfile the", Environment.NewLine)))
                {
                    try
                    {
                        //Assert
                        Console.SetIn(stringreader);
                        string resultsofvalidationsmethod = objSearchFile.Validations();
                        string expected = "";
                        Assert.AreEqual(expected, resultsofvalidationsmethod);
                    }
                    catch (AssertFailedException)
                    {
                        Console.WriteLine("\nAssert was failed");
                    }
                    catch (ArgumentNullException)
                    {
                        Console.WriteLine("\nArgument Null Exception was Raised");
                    }
                    catch (SystemException)
                    {
                        Console.WriteLine("\nSecurity Exception was Raised");
                    }
                }
            }
        }

        /// <summary>
        /// This method testing negative test on validation method
        /// </summary>
        [TestMethod]
        public void TestValidationsmethod_negativetest()
        {
            //Arrange
            SearchFile objSearchFile = new SearchFile();

            //Act
            using (StringWriter stringwriter = new StringWriter())
            {
                Console.SetOut(stringwriter);
                using (StringReader stringreader = new StringReader(string.Format("searchfile", Environment.NewLine)))
                {
                    try
                    {
                        //Assert
                        Console.SetIn(stringreader);
                        string resultsofvalidationsmethod = objSearchFile.Validations();
                        string expected = "\nRequired 2 or more than 2 arguments\n";
                        Assert.AreEqual(expected, resultsofvalidationsmethod);
                    }
                    catch (AssertFailedException)
                    {
                        Console.WriteLine("\nAssert was failed");
                    }
                    catch (ArgumentNullException)
                    {
                        Console.WriteLine("\nArgument Null Exception was Raised");
                    }
                    catch (SystemException)
                    {
                        Console.WriteLine("\nSecurity Exception was Raised");
                    }
                }
            }
        }
    }
}