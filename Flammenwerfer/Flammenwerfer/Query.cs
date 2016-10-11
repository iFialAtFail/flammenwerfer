using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flammenwerfer
{
    class Query
    {
         public void StartQuery(string sUserquery)//this seperates the command and then begins the proper search type
        {
            sUserquery.ToLower();
            string[] sQueryArray = sUserquery.Split(' ');//seperates sUserquery

            string sQueryType = sQueryArray[0];//seperates the search type


            string sQueried = " ";//used if sQueryArray[1] is left blank
            sQueried = sQueryArray[1];//seperates the searched name/id
            sQueried = sQueried.ToLower();

            switch (sQueryType)//here starts a check for each type of search(ID, First Name and Last Name)
            {
                case "sid":
                    Query_ID IDQ = new Query_ID();
                    IDQ.SearchID(sQueried);
                    break;
                case "fname":
                    Query_FirstName FNQ = new Query_FirstName();
                    FNQ.SearchFirstName(sQueried);
                    break;
                case "lname":
                    Query_LastName LNQ = new Query_LastName();
                    LNQ.SearchLastName(sQueried);
                    break;
                default: //If no type was properly selected
                    Console.WriteLine("search paramaters incorrect please see system analyst");
                    Console.ReadKey();
                    break;
            }
        }
    }
}
