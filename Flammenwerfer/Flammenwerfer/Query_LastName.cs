using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Flammenwerfer
{
    class Query_LastName
    {
        public void SearchLastName(string sSearchedLName)
        {
            string[] sFoundStudent = new string[8];//this array will be used to send the found information to the next class
            string sArchiveLName;//used to hold LastNames found in the xml file
            bool bStudentFound = false;//will be set to true if student is found


            XmlDocument xmlArchive = new XmlDocument();
            xmlArchive.Load("C:\\Users\\Nate\\Desktop\\test.xml");//loads the precreated xml doc,this is not final this final destination is used until the proper xml doc is done
            XmlNodeList XNList = xmlArchive.SelectNodes("/Students/ID");


            foreach (XmlNode Node in XNList)
            {
                sArchiveLName = Node["LName"].InnerText.ToLower();
                if (sArchiveLName == sSearchedLName)//if the searched name equal and achieved name then sFoundStudent is filled with the the information from the archieve
                {
                    bStudentFound = true;
                    sFoundStudent[0] = Node["SID"].InnerText;
                    sFoundStudent[1] = Node["FName"].InnerText;
                    sFoundStudent[2] = Node["LName"].InnerText;
                    sFoundStudent[3] = Node["CourseID"].InnerText;
                    sFoundStudent[4] = Node["CourseName"].InnerText;
                    sFoundStudent[5] = Node["Semester"].InnerText;
                    sFoundStudent[6] = Node["CourseType"].InnerText;
                    sFoundStudent[7] = Node["CourseGrade"].InnerText;
                }

            }



            if (bStudentFound == true)
            {
                for (int i = 0; i < 7; i++)//this is here for testing purposes
                {
                    Console.WriteLine(sFoundStudent[i]);
                }
                Console.ReadKey();//this would normaly activate the final set of classes
            }
            else
            {
                Console.WriteLine("Search Failed");
                Console.ReadKey();
            }
        }
    }
}
