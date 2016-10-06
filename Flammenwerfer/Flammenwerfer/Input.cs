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
            string[] stemparray = sInputCommand.Split(' ');
            foreach (string i in stemparray)
            {
                sSeperatedCMD.Add(i);
            }
        }

        #endregion

        #region Testing Methods

        private void ParseGetSetTest()
        {
            Console.WriteLine("testing for command");
            Console.ReadKey();
            if (sCommand == "get")
            {
                Console.WriteLine("going to search system");
                Console.ReadLine();
                QueryParsing();
                //InputReader();
                query.StartQuery(sParsedInCommand);
            }
            if (sCommand == "set")
            {
                Console.WriteLine("Going to User Creation");
                Console.ReadLine();
                creation.FileTest();
            }
            if (sCommand == "edit")
            {
                Console.WriteLine("going to user editor");
                editor.FileTest();
            }
            if (sCommand != "get" || sCommand != "set" || sCommand != "edit")
            {
                Console.WriteLine("failed");
                Console.ReadKey();
                ResetWrongValue();
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
            MatchCollection mCommandGet = Regex.Matches(sSeperatedCMD[0], "(?i)get|(?i)p|(?i)r", RegexOptions.Singleline);
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
            MatchCollection mFNTypeParse = Regex.Matches(sSeperatedCMD[1], "(?i)^f.+?n.+|(?i)^fn", RegexOptions.Singleline);
            MatchCollection mLNTypeParse = Regex.Matches(sSeperatedCMD[1], "(?i)^l.+?n.+|(?i)^ln", RegexOptions.Singleline);
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

    #endregion
}
