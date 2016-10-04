using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Flammenwerfer
{
    #region Input Parsing System

    class Input
    {
        #region Variable Declaration

        string sRegexParser = "";
        string sParsedInCommand = "";
        string sInputCommand = "";
        string sCommand = ""
        List<string> sSeperatedCMD = new List<string>();
        List<string> sPartiallyParsedCMD = new List<string>();
        XML_Creator creation = new XML_Creator();
        XML_Changer editor = new XML_Changer();
        Query query = new Query();

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
            if (sCommand == "get")
            {
                QueryParsing();
                InputReader();
                query.StartQuery(sParsedInCommand);
            }
            else if (sCommand == "set")
            {
                creation.FileTest();
            }
            else if (sCommand == "edit")
            {
                editor.FileTest();
            }
            else
            {
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
            MatchCollection mCommandGet = Regex.Matches(sSeperatedCMD[0], "(?i)g|(?i)p|(?i)r", RegexOptions.Singleline);
            MatchCollection mCommandSet = Regex.Matches(sSeperatedCMD[0], "(?i)s|(?i)cr|(?i)ad|(?i)n", RegexOptions.Singleline);
            MatchCollection mCommandEdit = Regex.Matches(sSeperatedCMD[0], "(?i)e|(?i)ch|(?i)al", RegexOptions.Singleline);
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
                sRegexParser = "ln");
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
