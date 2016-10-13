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
            List<string> lFoundStudent = new List<string>();//this array will be used to send the found information to the next class
            lFoundStudent.Add("");
            string sArchiveID;//used to hold IDs found in the xml file
            string sArchiveUID = "";
            string sSearchedUID = "";
            bool bStudentFound = false;//will be set to true if student is found
            int iCourseCounter = 0;

            XmlDocument xmlArchive = new XmlDocument();
            XMLPATH path = new XMLPATH();
            string spath=path.Path;
            xmlArchive.Load(spath);//loads the precreated xml doc,takes the path string from the XML_Creator class
            XmlNodeList XNList = xmlArchive.SelectNodes("/Students/Student");
            XmlNodeList XNListCourses = xmlArchive.SelectNodes("/Students/Student/Courses/Course");



            foreach (XmlNode Node in XNList)
            {
                sArchiveID = Node["SID"].InnerText.ToLower();
                if (sArchiveID == sSearchedID)//if the searched name equal and achieved name then sFoundStudent is filled with the the information from the archieve
                {
                    bStudentFound = true;
                    lFoundStudent.Add(Node["SID"].InnerText);
                    lFoundStudent.Add(Node["FName"].InnerText);
                    lFoundStudent.Add(Node["LName"].InnerText);
                    foreach (XmlNode xNode in XNListCourses)
                    {
                        sArchiveUID = xNode["UID"].InnerText;
                        if (sArchiveUID == sSearchedUID)
                        {
                            iCourseCounter++;
                            lFoundStudent.Add(xNode["CourseID"].InnerText);
                            lFoundStudent.Add(xNode["CourseNumber"].InnerText);
                            lFoundStudent.Add(xNode["CourseName"].InnerText);
                            lFoundStudent.Add(xNode["Credits"].InnerText);
                            lFoundStudent.Add(xNode["Year"].InnerText);
                            lFoundStudent.Add(xNode["Semester"].InnerText);
                            lFoundStudent.Add(xNode["CourseType"].InnerText);
                            lFoundStudent.Add(xNode["CourseGrade"].InnerText);
                        }
                        lFoundStudent[0] = Convert.ToString(iCourseCounter);
                    }
                }
            }
            if (bStudentFound == true)
            {
                Output Displayer = new Output();
                Displayer.InfoDisplay(lFoundStudent);
            }
            else
            {
                Console.WriteLine("Search Failed");
                Console.ReadKey();
                Console.Clear();
                CommandInput input = new CommandInput();
                input.InputReader();
            }
        }
    }
}
