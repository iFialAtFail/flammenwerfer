using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flammenwerfer
{
    class Input
    {
        #region Variable Declaration
        string sParsedInCommand = "";
        string sInputCommand = "";
        string[] sSeperatedCMD = { "", "", "" };
        XML_Creator creation = new XML_Creator();
        XML_Changer editor = new XML_Changer();
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
            sParsedInCommand = sSeperatedCMD[1] + " " + sSeperatedCMD[2];
            sSeperatedCMD = sInputCommand.Split(' ');
            ParseGetSetTest();
        }
        #endregion

        #region Cleaning Methods
        private void ParseGetSetTest()
        {
            if (sSeperatedCMD[0] == "get")
            {
                //SEND TO NATE
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
                Console.WriteLine("Invalid entry");
                Console.WriteLine("Press any key to continue...");
                Console.ReadLine();
                InputReader();
            }
        }
        #endregion

    }
}
