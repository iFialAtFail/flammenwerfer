using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Flammenwerfer
{
    #region Input Parsing System

    class CommandInput
    {
            /*setup of required materials*/
        #region Variable Declaration
        /*Variables used in Input logic. calls out required strings and classes to connect logic together*/
        string sRegexParser; //Regular Expression Placeholder string
        string sParsedInCommand = ""; //Parsed string file to hand off for query
        string sInputCommand = ""; //Input String
        string sCommand = ""; //Command string to compare
        List<string> sSeperatedCMD = new List<string>(); // split string 
        XML_Creator creation = new XML_Creator(); //Callout to XML User Creation
        XML_Changer editor = new XML_Changer(); //Callout to XML Editing
        Query query = new Query(); // initiating callout for user search
        Output display = new Output(); //Visual display logic class callout

        #endregion
            /*entry point of system*/
        #region Input Handler

        public void InputReader()
        { //Entry point of Input, sets up logic structure of input system
            sSeperatedCMD.Clear(); //ensures command entry is cleared out before new commands are entered
            sInputCommand = display.ReadInfoDisplay("<action> *(<Search Type> <Search Data>)* \n *Only needed if searching \n \n ENTER COMMAND: "); //takes in command to match prompt
            InputLayoutParser(); //Parses the layout text for passthrough to the query
            QueryParsing(); //Parses the query command and paramater into the passthrough string
            CommandParser(); //Parses the command into testable logic
            ParseGetSetTest(); //Actual command test logic
        }

        #endregion
            /*Comparison system to match to proper action command*/
        #region Testing Methods
        /*Start action command comparison test*/
        private void ParseGetSetTest()
        { //tests for command parsing setup
            switch (sCommand)
            {
                case "get": //if 'get' command is matched, go to query system
                    query.StartQuery(sParsedInCommand);
                    break;

                case "set": //if 'set' command is matched, go to user creation
                    creation.instantiator();
                    break;

                case "edit": //if 'edit' command is matched, go to user editor
                    editor.FileTest();
                    break;

                default: //if all other commands fail, flag as unmatched
                    ResetWrongValue();
                    break;
            }
        }

        private void ResetWrongValue()
        { //Action flagged for when command entered does not match given types
            display.DumbInfoDisplay("Invalid entry \n Press any key to continue... \n");
            Console.ReadKey();
            InputReader();
        }
        /*End action command comparison test*/
        #endregion
            /*Parsing systems to format text into easily testable formats*/
        #region regex methods

        /*Seperate input command string into editable chunks*/
        private void InputLayoutParser()
        { //Input string partially parsed out to be sorted by other parsing systems
            string[] stemparray = sInputCommand.Split(' ');
            foreach (string i in stemparray)
            {
                sSeperatedCMD.Add(i);
            }
            for (int i = 0; i < 3; i++)
            {
                if (sSeperatedCMD[i] == null)
                {
                    sSeperatedCMD.Add("NULL");
                }
            }
        }

        /*Start of action command checking parser*/
        private void CommandParser()
        {/*Regular Expressions testing of inputted action command*/
            MatchCollection mCommandGet = Regex.Matches(sSeperatedCMD[0], "(?i)get|(?i)f|(?i)r", RegexOptions.Singleline);
            MatchCollection mCommandSet = Regex.Matches(sSeperatedCMD[0], "(?i)set|(?i)cr|(?i)add", RegexOptions.Singleline);
            MatchCollection mCommandEdit = Regex.Matches(sSeperatedCMD[0], "(?i)edit|(?i)ch|(?i)al", RegexOptions.Singleline);
            CommandMatchTest(mCommandGet, mCommandSet, mCommandEdit);
        }

        private void CommandMatchTest(MatchCollection mCommandGet, MatchCollection mCommandSet, MatchCollection mCommandEdit)
        { //Match testing from command regular expressions testing
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
        /*end of action command checking parser*/

        /* start of Parsing for Query command passthrough */
        private void QueryParsing() 
        { /*Regular Expressions testing of inputted Query command*/
            MatchCollection mSIDTypeParse = Regex.Matches(sSeperatedCMD[1], "(?i)id", RegexOptions.Singleline);
            MatchCollection mFNTypeParse = Regex.Matches(sSeperatedCMD[1], "(?i)^f.+?n.+|(?i)f", RegexOptions.Singleline);
            MatchCollection mLNTypeParse = Regex.Matches(sSeperatedCMD[1], "(?i)^l.+?n.+|(?i)l", RegexOptions.Singleline);
            RegexMatchTest(mSIDTypeParse, mFNTypeParse, mLNTypeParse);
            ParseMerger();
        }

        private void RegexMatchTest(MatchCollection mSIDTypeParse, MatchCollection mFNTypeParse, MatchCollection mLNTypeParse)
        { //Match testing from query regular expressions testing
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
        { //Parsing merger for query. layed out as: [Matched search type] [search paramater]
            sParsedInCommand = sRegexParser + " " + sSeperatedCMD[2];
        }
        /*End of Query command passthrough parsing*/
        #endregion
    }
}

    #endregion

