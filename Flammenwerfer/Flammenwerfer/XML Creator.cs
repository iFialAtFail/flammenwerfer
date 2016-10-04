using System;
using System.Text;
using System.Xml;
using System.IO;
using System.Text.RegularExpressions;

namespace Flammenwerfer
{
    #region XML File Exists Test

    class XML_Creator
    {

        #region variable declaration

        Input start = new Input();
        XML_Path path = new XML_Path();
        XML_FILE_MISSING nofile = new XML_FILE_MISSING();
        XML_Add_User yesfile = new XML_Add_User();
        string sAnotherUserParser = "";
        string sAnotherUserParsed = "";
        string sMainMenuParser = "";
        string sMainMenuParsed = "";

        #endregion

        #region Test Method

        public void FileTest()
        {
            if (File.Exists(path.XMLPath))
            {
                yesfile.instantiator();
            }
            else
            {
                nofile.createfile();
            }

        }

        #endregion

        #region New User/Main Menu/Exit Prompts

        public void ReturnPrompt()
        {
            Console.WriteLine("Would you like to create another user?");
            sAnotherUserParser = Console.ReadLine();
            RegexAnotherUserParser();
            AnotherUserParsedTest();
        }

        private void MainMenuPrompt()
        {
            Console.WriteLine("Would you like to return to Menu Input?");
            sMainMenuParser = Console.ReadLine();
            RegexMainMenuParser();
            MainMenuParsedTest();
        }

        #region Regex Methods

        private void RegexMainMenuParser()
        {
            MatchCollection mMainMenuParsed = Regex.Matches(sMainMenuParser, "(?i)y", RegexOptions.Singleline);
            foreach (Match m in mMainMenuParsed)
            {
                Console.WriteLine(m);
                sMainMenuParsed = Convert.ToString(m);
            }
        }

        private void RegexAnotherUserParser()
        {
            MatchCollection mAnotherUserParsed = Regex.Matches(sAnotherUserParser, "(?i)y", RegexOptions.Singleline);
            foreach (Match m in mAnotherUserParsed)
            {
                Console.WriteLine(m);
                sAnotherUserParsed = Convert.ToString(m);
            }
        }

        #endregion

        private void AnotherUserParsedTest()
        {
            if (sAnotherUserParsed == "y")
            {
                FileTest();
            }
            else
            {
                MainMenuPrompt();
            }
        }

        private void MainMenuParsedTest()
        {
            if (sMainMenuParsed == "y")
            {
                start.InputReader();
            }
            else
            {
                Exit();
            }
        }

        private static void Exit()
        {
            Console.WriteLine("Please press key to close program");
            Console.ReadKey();
            Environment.Exit(0);
        }

        #endregion
    }

    #endregion

    #region File Already Exists

    class XML_Add_User
    {

        #region variable declaration

        XML_Path path = new XML_Path();
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
            xDoc.Load(path.XMLPath);
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
            xDoc.Save(path.XMLPath);
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

    #region No File Exists

    class XML_FILE_MISSING
    {

        #region variable declaration

        XML_Path path = new XML_Path();
        string sFName = "";
        string sLName = "";
        string sSID = "";
        string sCourseID = "";
        string sCourseName = "";
        string sSem = "";
        string sCourseType = "";
        string sCourseGrade = "";

        #endregion

        #region File Creation

        public void createfile()
        {
            XmlTextWriter xWriter = new XmlTextWriter(path.XMLPath, Encoding.UTF8);
            xWriter.Formatting = Formatting.Indented;
            NodeWriter(xWriter);
        }

        #endregion

        #region Node Writing

        private void NodeWriter(XmlTextWriter xWriter)
        {
            xWriter.WriteStartElement("Students"); //<Students>
            xWriter.WriteStartElement("Student"); //<Student>
            //start node filler
            StudentIDNode(xWriter);
            StudentFNNode(xWriter);
            StudentLNNode(xWriter);
            CourseIDNode(xWriter);
            CourseNameNode(xWriter);
            SemesterNode(xWriter);
            CourseTypeNode(xWriter);
            CourseGradeNode(xWriter);
            //end node filler
            xWriter.WriteEndElement(); //</Student>
            xWriter.WriteEndElement(); //</Students>
            xWriter.Close();
        }

        #endregion

        #region node filler

        private void StudentIDNode(XmlTextWriter xWriter)
        {
            xWriter.WriteStartElement("SID"); //<SID>
            Console.Write("Student ID number: ");
            sSID = Console.ReadLine();
            xWriter.WriteString(sSID); //SID Data
            xWriter.WriteEndElement(); //</SID>
        }

        private void StudentFNNode(XmlTextWriter xWriter)
        {
            xWriter.WriteStartElement("FName"); //<FName>
            Console.Write("Student first name: ");
            sFName = Console.ReadLine();
            xWriter.WriteString(sFName); //FName Data
            xWriter.WriteEndElement(); //</FName>
        }

        private void StudentLNNode(XmlTextWriter xWriter)
        {
            xWriter.WriteStartElement("LName"); //<LName>
            Console.Write("Student last name: ");
            sLName = Console.ReadLine();
            xWriter.WriteString(sLName); //LName Data
            xWriter.WriteEndElement(); //</LName>
        }

        private void CourseIDNode(XmlTextWriter xWriter)
        {
            xWriter.WriteStartElement("CourseID"); //<CourseID>
            Console.Write("Course ID Code: ");
            sCourseID = Console.ReadLine();
            xWriter.WriteString(sCourseID); //CourseID Data
            xWriter.WriteEndElement(); //</CourseID>
        }

        private void CourseNameNode(XmlTextWriter xWriter)
        {
            xWriter.WriteStartElement("CourseName"); //<CourseName>
            Console.Write("Course Name: ");
            sCourseName = Console.ReadLine();
            xWriter.WriteString(sCourseName); //CourseName Data
            xWriter.WriteEndElement(); //</CourseName>
        }

        private void SemesterNode(XmlTextWriter xWriter)
        {
            xWriter.WriteStartElement("Semester"); //<Semester>
            Console.Write("Semester: ");
            sSem = Console.ReadLine();
            xWriter.WriteString(sSem); //Semester Data
            xWriter.WriteEndElement(); //</Semester>
        }

        private void CourseTypeNode(XmlTextWriter xWriter)
        {
            xWriter.WriteStartElement("CourseType"); //<CourseType>
            Console.Write("Type of Course: ");
            sCourseType = Console.ReadLine();
            xWriter.WriteString(sCourseType); //CourseType Data
            xWriter.WriteEndElement(); //</CourseType>
        }

        private void CourseGradeNode(XmlTextWriter xWriter)
        {
            xWriter.WriteStartElement("CourseGrade"); //<CourseGrade>
            Console.Write("Gerade of Course: ");
            sCourseGrade = Console.ReadLine();
            xWriter.WriteString(sCourseGrade); //CourseGrade Data
            xWriter.WriteEndElement(); //</CourseGrade>
        }

        #endregion
    }

    #endregion

    #region public file path

    class XML_Path
    {
        public string XMLPath = "\\Student Data\\Data.xml";
    }

    #endregion
}
