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
        public String[] TestOutput = new String[8];

        //test output method with embedded dummy info
        public void OutputTest()
        {
            TestOutput[0] = sStudentID;
            TestOutput[1] = sFirstName;
            TestOutput[2] = sLastName;
            TestOutput[3] = sCourseID;
            TestOutput[4] = sCourseName;
            TestOutput[5] = sSemester;
            TestOutput[6] = sCourseType;
            TestOutput[7] = sCourseGrade;
            InfoDisplay(TestOutput);
        }

        //display student info from arbitrary array input
        public void InfoDisplay(String[] sFoundStudent)
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
            Console.WriteLine(sInString);
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
