using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Flammenwerfer
{
    class Query_FirstName
    {
        public void SearchFirstName(string sSearchedFName)
        {
            List<string> lFoundStudent = new List<string>();//this array will be used to send the found information to the next class
            string sArchiveFName = "";//used to hold FirstNames found in the xml file
            bool bStudentFound = false;//will be set to true if student is found


            XmlDocument xmlArchive = new XmlDocument();
            XMLPATH path = new XMLPATH();
            string spath = path.Path;
            xmlArchive.Load(spath);//loads the precreated xml doc,takes the path string found in the XML_Creator class
            XmlNodeList XNList = xmlArchive.SelectNodes("/Students/Student");
            XmlNodeList XNListCourses = xmlArchive.SelectNodes("/Students/Student/Courses/Course");


            foreach (XmlNode Node in XNList)
            {
                sArchiveFName = Node["FName"].InnerText.ToLower();
                if (sArchiveFName == sSearchedFName)//if the searched name equal and achieved name then sFoundStudent is filled with the the information from the archieve
                {
                    bStudentFound = true;
                    lFoundStudent.Add(Node["SID"].InnerText);
                    lFoundStudent.Add(Node["FName"].InnerText);
                    lFoundStudent.Add(Node["LName"].InnerText);
                    foreach (XmlNode xNode in XNListCourses)
                    {
                        if (sArchiveFName == sSearchedFName)
                        {
                            lFoundStudent.Add(xNode["CourseID"].InnerText);
                            lFoundStudent.Add(xNode["CourseName"].InnerText);
                            lFoundStudent.Add(xNode["Semester"].InnerText);
                            lFoundStudent.Add(xNode["CourseType"].InnerText);
                            lFoundStudent.Add(xNode["CourseGrade"].InnerText);
                        }
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
