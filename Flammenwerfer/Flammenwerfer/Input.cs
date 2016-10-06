using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Flammenwerfer
{
    #region Input Parsing System

    class CommandInput
    {
        #region Variable Declaration
        /**/
        string sRegexParser; //Regular Expression Placeholder string
        string sParsedInCommand = ""; //Parsed string file to hand off for query
        string sInputCommand = ""; //Input String
        string sCommand = ""; //Command string to compare
        List<string> sSeperatedCMD = new List<string>(); // split string 
        XML_Creator creation = new XML_Creator(); //Callout to XML User Creation
        XML_Changer editor = new XML_Changer(); //Callout to XML Editing
        Query query = new Query(); //

        #endregion

        #region Input Handler

        public void InputReader()
        {
            sSeperatedCMD.Clear();
            Console.WriteLine("<action> *(<Search Type> <Search Data>)*");
            Console.WriteLine("* Only needed if searching");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("ENTER COMMAND: ");
            sInputCommand = Console.ReadLine();
            InputLayputParser();
            CommandParser();
            ParseGetSetTest();
        }

        private void InputLayputParser()
        {
            int errorfixcounter = 0;
            string[] stemparray = sInputCommand.Split(' ');
            foreach (string i in stemparray)
            {
                sSeperatedCMD.Add(i);
                if (sSeperatedCMD[errorfixcounter] == "")
                {
                    sSeperatedCMD[errorfixcounter] = "NULL";
                }
                errorfixcounter++;
            }
        }

        #endregion

        #region Testing Methods

        private void ParseGetSetTest()
        {
            Console.WriteLine("testing for command");
            Console.ReadKey();
            switch (sCommand)
            {
                case "get":
                    Console.WriteLine("going to search system");
                    QueryParsing();
                    query.StartQuery(sParsedInCommand);
                    break;

                case "set":
                    Console.WriteLine("Going to User Creation");
                    Console.ReadLine();
                    creation.FileTest();
                    break;

                case "edit":
                    Console.WriteLine("going to user editor");
                    editor.FileTest();
                    break;

                default:
                    Console.WriteLine("failed");
                    Console.ReadKey();
                    ResetWrongValue();
                    break;
            }
        }



        private void ResetWrongValue()
        {
            Console.WriteLine("Invalid entry");
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
            InputReader();
        }

        #endregion

        #region regex methods

        private void CommandParser()
        {
            MatchCollection mCommandGet = Regex.Matches(sSeperatedCMD[0], "(?i)get|(?i)f|(?i)r", RegexOptions.Singleline);
            MatchCollection mCommandSet = Regex.Matches(sSeperatedCMD[0], "(?i)set|(?i)cr|(?i)add", RegexOptions.Singleline);
            MatchCollection mCommandEdit = Regex.Matches(sSeperatedCMD[0], "(?i)edit|(?i)ch|(?i)al", RegexOptions.Singleline);
            CommandMatchTest(mCommandGet, mCommandSet, mCommandEdit);
        }

        private void CommandMatchTest(MatchCollection mCommandGet, MatchCollection mCommandSet, MatchCollection mCommandEdit)
        {
            sCommand = "Fail";
            foreach (Match m in mCommandGet)
            {
                sCommand = "get";
            }
            foreach (Match m in mCommandSet)
            {
                sCommand = "set";
            }
            foreach (Match m in mCommandEdit)
            {
                sCommand = "edit";
            }
        }

        private void QueryParsing()
        {
            MatchCollection mSIDTypeParse = Regex.Matches(sSeperatedCMD[1], "(?i)id", RegexOptions.Singleline);
            MatchCollection mFNTypeParse = Regex.Matches(sSeperatedCMD[1], "(?i)^f.+?n.+|(?i)^fn|(?i)f", RegexOptions.Singleline);
            MatchCollection mLNTypeParse = Regex.Matches(sSeperatedCMD[1], "(?i)^l.+?n.+|(?i)^ln|(?i)n", RegexOptions.Singleline);
            RegexMatchTest(mSIDTypeParse, mFNTypeParse, mLNTypeParse);
            ParseMerger();
        }

        private void RegexMatchTest(MatchCollection mSIDTypeParse, MatchCollection mFNTypeParse, MatchCollection mLNTypeParse)
        {
            foreach (Match m in mSIDTypeParse)
            {
                sRegexParser = "sid";
            }
            foreach (Match m in mFNTypeParse)
            {
                sRegexParser = "fn";
            }
            foreach (Match m in mLNTypeParse)
            {
                sRegexParser = ("ln");
            }
        }

        private void ParseMerger()
        {
            sParsedInCommand = sRegexParser + " " + sSeperatedCMD[2];
        }

        #endregion
    }
}

    #endregion

