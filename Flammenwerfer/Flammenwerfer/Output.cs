using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flammenwerfer
{
    class Output
    {
        //declare dummy info containers
        public String sStudentID = "7-52-694";
        public String sFirstName = "John";
        public String sLastName = "Doe";
        public String sCourseID = "1024";
        public String sCourseNbr = "MXWB-8192";
        public String sCourseName = "Applied Bloodstone Ritual";
        public String sCredits = "03";
        public String sSemester = "Fall";
        public String sYear = "9999";
        public String sCourseType = "General Education";
        public String sCourseGrade = "B";
        public List<string> TestOutput = new List<string>();

        //test output method with embedded dummy info
        public void OutputTest()
        {
            TestOutput.Add(sStudentID);
            TestOutput.Add(sFirstName);
            TestOutput.Add(sLastName);
            TestOutput.Add(sCourseID);
            TestOutput.Add(sCourseName);
            TestOutput.Add(sSemester);
            TestOutput.Add(sCourseType);
            TestOutput.Add(sCourseGrade);
            InfoDisplay(TestOutput);
        }

        //display student info from arbitrary array input
        public void InfoDisplay(List<string> sFoundStudent)
        {
            Console.WriteLine("Student ID: " + sFoundStudent[0]);
            Console.WriteLine("Student Name: " + sFoundStudent[2] + ", " + sFoundStudent[1]);
            Console.WriteLine("Course ID: " + sFoundStudent[3]);
            Console.WriteLine("Course Name: " + sFoundStudent[4]);
            Console.WriteLine("Semester: " + sFoundStudent[5]);
            Console.WriteLine("Course Type: " + sFoundStudent[6]);
            Console.WriteLine("Course Grade: " + sFoundStudent[7]);
            Console.ReadLine();
        }
        
        //dump any text output to console and return next command
        public String ReadInfoDisplay(String sInString)
        {
            Console.Write(sInString);
            return Console.ReadLine();
        }

        //dump any text output to console
        public void DumbInfoDisplay(String sInString)
        {
            Console.WriteLine(sInString);
            Console.ReadLine();
        }

    }
}
