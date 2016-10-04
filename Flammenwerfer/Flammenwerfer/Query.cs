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
            string[] sQueryArray = sUserquery.Split(' ');//seperates sUserquery

            string sQueryType = sQueryArray[0];//seperates the search type
            sQueryType = sQueryType.ToLower();


            string sQueried = " ";//used if sQueryArray[1] is left blank
            sQueried = sQueryArray[1];//seperates the searched name/id
            sQueried = sQueried.ToLower();



            bool bIDcheck = sQueryType.Equals("sid");//will be used in determining the type of search
            bool bFNameCheck = sQueryType.Equals("fn");
            bool bLNameCheck = sQueryType.Equals("ln");




            if (bIDcheck == true)//here starts a check for each type of search(ID, First Name and Last Name)
            {
                Query_ID IDQ = new Query_ID();
                IDQ.SearchID(sQueried);
            }

            else if (bFNameCheck == true)
            {
                Query_FirstName FNQ = new Query_FirstName();
                FNQ.SearchFirstName(sQueried);
            }

            else if (bLNameCheck == true)
            {
                Query_LastName LNQ = new Query_LastName();
                LNQ.SearchLastName(sQueried);
            }
            else//If no type was properly selected
            {
                Console.WriteLine("search paramaters incorrect please see system analyst");
                Console.ReadKey();
            }


        }
    }
}
