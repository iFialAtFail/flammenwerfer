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
            int iCourseCounter = Convert.ToInt32(sFoundStudent[0]);
            int iCourseSlot = 4;
            Console.WriteLine("Student ID: " + sFoundStudent[1]);
            Console.WriteLine("Student Name: " + sFoundStudent[2] + ", " + sFoundStudent[3]);
            for (int i = 0; i < iCourseCounter; i++)
            {
                Console.WriteLine("Course ID: " + sFoundStudent[iCourseSlot]);
                iCourseSlot++;
                Console.WriteLine("Course Name: " + sFoundStudent[iCourseSlot]);
                iCourseSlot++;
                Console.WriteLine("Semester: " + sFoundStudent[iCourseSlot]);
                iCourseSlot++;
                Console.WriteLine("Course Type: " + sFoundStudent[iCourseSlot]);
                iCourseSlot++;
                Console.WriteLine("Course Grade: " + sFoundStudent[iCourseSlot]);
                iCourseSlot++;
            }

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
