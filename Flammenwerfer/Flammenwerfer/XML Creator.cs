using System;
using System.Text;
using System.Xml;
using System.IO;
using System.Text.RegularExpressions;

namespace Flammenwerfer
{

    class XML_Creator
    {

        XML_Add_User useraddition = new XML_Add_User();
        
        public void FileTest()
        {
            useraddition.instantiator();
        }


        #region New User/Main Menu/Exit Prompts

        public static void Exit()
        {
            Console.WriteLine("Please press key to close program");
            Console.ReadKey();
            Environment.Exit(0);
        }

        #endregion
    }

    #region File Already Exists

    class XML_Add_User
    {

        #region variable declaration
        string path = "../../UserData.xml";
        string sFName = "";
        string sLName = "";
        string sSID = "";
        string sCourseID = "";
        string sCourseName = "";
        string sSem = "";
        string sCourseType = "";
        string sCourseGrade = "";

        #endregion

        #region Start User Creation

        public void instantiator()
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(path);
            CreateUser(xDoc);
        }

        public void CreateUser(XmlDocument xDoc)
        {
            XmlNode xStudent = xDoc.CreateElement("Student");
            // Start Node Filler Writer
            StudentIDNode(xDoc, xStudent);
            StudentFNNode(xDoc, xStudent);
            StudentLNNode(xDoc, xStudent);
            CourseIDNode(xDoc, xStudent);
            CourseNameNode(xDoc, xStudent);
            SemesterNode(xDoc, xStudent);
            CourseTypeNode(xDoc, xStudent);
            CourseGradeNode(xDoc, xStudent);
            //End Node Filler Writer
            xDoc.DocumentElement.AppendChild(xStudent);
            xDoc.Save(path);
            
        }

        #endregion

        #region Node Writer FIller

        private void StudentIDNode(XmlDocument xDoc, XmlNode xStudent)
        {
            XmlNode xSID = xDoc.CreateElement("SID"); //<SID>
            Console.Write("Student ID number: ");
            sSID = Console.ReadLine();
            xSID.InnerText = sSID; //Input SID data
            xStudent.AppendChild(xSID); //</SID>
        }

        private void StudentFNNode(XmlDocument xDoc, XmlNode xStudent)
        {
            XmlNode xFName = xDoc.CreateElement("FName"); //<FName>
            Console.Write("Student first name: ");
            sFName = Console.ReadLine();
            xFName.InnerText = sSID; //Input FName data
            xStudent.AppendChild(xFName); //</FName>
        }

        private void StudentLNNode(XmlDocument xDoc, XmlNode xStudent)
        {
            XmlNode xLName = xDoc.CreateElement("LName"); //<LName>
            Console.Write("Student last name: ");
            sLName = Console.ReadLine();
            xLName.InnerText = sSID; //Input LName data
            xStudent.AppendChild(xLName); //</LName>
        }

        private void CourseIDNode(XmlDocument xDoc, XmlNode xStudent)
        {
            XmlNode xCourseID = xDoc.CreateElement("CourseID"); //<CourseID>
            Console.Write("ID of course: ");
            sCourseID = Console.ReadLine();
            xCourseID.InnerText = sSID; //Input CourseID data
            xStudent.AppendChild(xCourseID); //</CourseID>
        }

        private void CourseNameNode(XmlDocument xDoc, XmlNode xStudent)
        {
            XmlNode xCourseName = xDoc.CreateElement("CourseName"); //<CourseName>
            Console.Write("Name of course: ");
            sCourseName = Console.ReadLine();
            xCourseName.InnerText = sSID; //Input CourseName data
            xStudent.AppendChild(xCourseName); //</CourseName>
        }

        private void SemesterNode(XmlDocument xDoc, XmlNode xStudent)
        {
            XmlNode xSem = xDoc.CreateElement("Semester"); //<Semester>
            Console.Write("Semester: ");
            sSem = Console.ReadLine();
            xSem.InnerText = sSID; //Input Semester data
            xStudent.AppendChild(xSem); //</Semester>
        }

        private void CourseTypeNode(XmlDocument xDoc, XmlNode xStudent)
        {
            XmlNode xCourseType = xDoc.CreateElement("CourseType"); //<CourseType>
            Console.Write("type of course: ");
            sCourseType = Console.ReadLine();
            xCourseType.InnerText = sSID; //Input CourseType data
            xStudent.AppendChild(xCourseType); //</CourseType>
        }

        private void CourseGradeNode(XmlDocument xDoc, XmlNode xStudent)
        {
            XmlNode xCourseGrade = xDoc.CreateElement("CourseGrade"); //<CourseGrade>
            Console.Write("Grade of course: ");
            sCourseGrade = Console.ReadLine();
            xCourseGrade.InnerText = sSID; //Input CourseGrade data
            xStudent.AppendChild(xCourseGrade); //</CourseGrade>
        }

        #endregion

    }

    #endregion

}
