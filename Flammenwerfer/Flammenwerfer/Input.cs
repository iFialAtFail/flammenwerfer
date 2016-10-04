using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace Flammenwerfer
{
    class Input
    {
        #region Variable Declaration
        string sParsedInCommand = "";
        string sInputCommand = "";
        List<string> sSeperatedCMD = new List<string>();
        List<string> sPartiallyParsedCMD = new List<string>();
        XML_Creator creation = new XML_Creator();
        XML_Changer editor = new XML_Changer();
        //Query query = new Query();
        #endregion

        #region Input Handler
        public void InputReader()
        {
            Console.WriteLine("ENTER COMMAND: ");
            sInputCommand = Console.ReadLine();
            parser();
        }
        private void parser()
        {
            //sParsedInCommand = sSeperatedCMD[1] + " " + sSeperatedCMD[2];
            string[] stemparray = sInputCommand.Split(' ');
            foreach (string i in stemparray)
            {
                sSeperatedCMD.Add(i);
            }
            QueryParsing();
            Console.ReadKey();
            //ParseGetSetTest();
        }
        #endregion

        #region Cleaning Methods
        private void ParseGetSetTest()
        {
            if (sSeperatedCMD[0] == "get")
            {

                //query.StartQuery(sParsedInCommand);
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

        private void QueryParsing()
        {
            MatchCollection sSIDTypeParse = Regex.Matches(sSeperatedCMD[1], "ID", RegexOptions.Singleline);
            MatchCollection sFNTypeParse = Regex.Matches(sSeperatedCMD[1], "F.+?N.+", RegexOptions.Singleline);
            MatchCollection sLNTypeParse = Regex.Matches(sSeperatedCMD[1], "L.+?N.+", RegexOptions.Singleline);
            foreach (Match m in sSIDTypeParse)
            {
                Console.WriteLine(m);
            }
            foreach (Match m in sFNTypeParse)
            {
                Console.WriteLine(m);
            }
            foreach (Match m in sLNTypeParse)
            {
                Console.WriteLine(m);
            }
            Console.WriteLine("finished parsing");

        }
        #endregion

    }
}
