using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Flammenwerfer
{
    class Query_ID
    {
        public void SearchID(string sSearchedID)
        {
            string[] sFoundStudent = new string[8];//this array will be used to send the found information to the next class
            string sArchiveID;//used to hold IDs found in the xml file
            bool bStudentFound = false;//will be set to true if student is found


            XmlDocument xmlArchive = new XmlDocument();
            string spath=XML_Creator.path;
            xmlArchive.Load(spath);//loads the precreated xml doc,takes the path string from the XML_Creator class
            XmlNodeList XNList = xmlArchive.SelectNodes("/Students/ID");



            foreach (XmlNode Node in XNList)
            {
                sArchiveID = Node["SID"].InnerText;
                if (sArchiveID == sSearchedID)//if the searched ID equal and achieved ID then sFoundStudent is filled with the the information from the archieve
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
