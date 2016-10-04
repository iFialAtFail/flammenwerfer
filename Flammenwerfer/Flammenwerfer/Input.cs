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
            Console.WriteLine("ENTER COMMAND: ");
            sInputCommand = Console.ReadLine();
            parser();
        }

        private void parser()
        {
            string[] stemparray = sInputCommand.Split(' ');
            foreach (string i in stemparray)
            {
                sSeperatedCMD.Add(i);
            }
            ParseGetSetTest();
        }

        #endregion

        #region Cleaning Methods

        private void ParseGetSetTest()
        {
            if (sSeperatedCMD[0] == "get")
            {
                QueryParsing();
                InputReader();
                query.StartQuery(sParsedInCommand);
            }
            else if (sSeperatedCMD[0] == "set")
            {
                creation.FileTest();
            }
            else if (sSeperatedCMD[0] == "edit")
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
                Console.WriteLine(m);
                sRegexParser = Convert.ToString(m);
            }
            foreach (Match m in mFNTypeParse)
            {
                Console.WriteLine(m);
                sRegexParser = Convert.ToString(m);
            }
            foreach (Match m in mLNTypeParse)
            {
                Console.WriteLine(m);
                sRegexParser = Convert.ToString(m);
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
