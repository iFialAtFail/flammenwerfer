using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flammenwerfer
{
    public class CourseItem
    {
        public string sCurrentSemester;
        public byte byCurrentSemester;
        public byte byCourseSemester;
        public void CourseComplete()
        {
            if (sCourseYear == DateTime.Now.ToString("YYYY"))
            {

                if (Convert.ToInt32(DateTime.Now.ToString("MM")) <= 5)
                {
                    sCurrentSemester = "Spring";
                    byCurrentSemester = 0;
                }
                else if (Convert.ToInt32(DateTime.Now.ToString("MM")) > 5 && Convert.ToInt32(DateTime.Now.ToString("MM")) < 9)
                {
                    sCurrentSemester = "Summer";
                    byCurrentSemester = 1;
                }
                else if (Convert.ToInt32(DateTime.Now.ToString("MM")) >= 9)
                {
                    sCurrentSemester = "Fall";
                    byCurrentSemester = 3;
                }

                if (sSemester.ToUpper() == "SPRING")
                {
                    byCourseSemester = 0;
                }
                else if (sSemester.ToUpper() == "SUMMER")
                {
                    byCourseSemester = 1;
                }
                else if (sSemester.ToUpper() == "FALL")
                {
                    byCourseSemester = 3;
                }

                if (byCourseSemester < byCurrentSemester)
                {
                    bCompleted = true;
                }
                else if (byCourseSemester >= byCurrentSemester)
                {
                    bCompleted = false;
                }
            }
            else if (Convert.ToInt32(sCourseYear) < Convert.ToInt32(DateTime.Now.ToString("YYYY")))
            {
                bCompleted = true;
            }

        }
        public String sStudentID;
        public String sFirstName;
        public String sLastName;
        public String sCourseID;
        public String sCourseNbr;
        public String sCourseName;
        public String sCredits;
        public String sSemester;
        public String sCourseYear;
        public String sCourseType;
        public String sCourseGrade;
        public bool bCompleted;

        public void CourseWrite()
        {
            Console.WriteLine("Student ID: " + sStudentID);
            Console.WriteLine("Student Name: " + sLastName + ", " + sFirstName);
            Console.WriteLine("Course ID: " + sCourseID);
            Console.WriteLine("    Course Number: " + sCourseNbr);
            Console.WriteLine("    Course Name: " + sCourseName);
            Console.WriteLine("    Course Credits: " + sCredits);
            Console.WriteLine("    Semester: " + sSemester);
            Console.WriteLine("    Year: " + sCourseYear);
            Console.WriteLine("    Course Type: " + sCourseType);
            Console.WriteLine("    Course Grade: " + sCourseGrade);
            Console.WriteLine("========================================================================");
            //Console.ReadLine();
        }
    }

    class Output
    {

        public List<string> TestOutput = new List<string>();

        //public List<CourseItem> CourseResults = new List<CourseItem>();

        //display student info from arbitrary array input
        public void InfoDisplay(List<string> sFoundStudent)
        {
            Console.WriteLine("Number of entries found: " + sFoundStudent[0]);
            CourseItem ciTempCourse = new CourseItem();

            for (int i = 4; i < sFoundStudent.Count - 1; i += 8)
            {
                ciTempCourse.sStudentID = sFoundStudent[1];
                ciTempCourse.sFirstName = sFoundStudent[2];
                ciTempCourse.sLastName = sFoundStudent[3];
                ciTempCourse.sCourseID = sFoundStudent[i];
                ciTempCourse.sCourseNbr = sFoundStudent[i + 1];
                ciTempCourse.sCourseName = sFoundStudent[i + 2];
                ciTempCourse.sCredits = sFoundStudent[i + 3];
                ciTempCourse.sCourseYear = sFoundStudent[i + 4];
                ciTempCourse.sSemester = sFoundStudent[i + 5];
                ciTempCourse.sCourseType = sFoundStudent[i + 6];
                ciTempCourse.sCourseGrade = sFoundStudent[i + 7];
                //CourseResults.Add(ciTempCourse);
                ciTempCourse.CourseWrite();
            }

            //CourseResults.ForEach(Item => Item.CourseWrite());

            //for (int j = 0; j < CourseResults.Count(); j++)
            //{
            //    CourseResults[j].CourseWrite();
                
            //}
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
