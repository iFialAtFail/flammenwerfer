﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flammenwerfer
{
    // Dedicated results sub-class that can be arbitrarily instantiated to take in many results as well as add an easy way to use include helper methods to sort/manipulate results with little additional coding
    // Presently the XML Creator presorts the data on data entry and so presently no sorting is needed.
    public class CourseItem
    {
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

        //method used to display each instance of CourseItem's course details to the screen
        public void CourseWrite()
        {
            //Uncomment to re-show student information along with each class rather than simply before query results
            //Console.WriteLine("Student ID: " + sStudentID);
            //Console.WriteLine("Student Name: " + sLastName + ", " + sFirstName);
            Console.WriteLine("Course ID: " + sCourseID);
            Console.WriteLine("    Course Number: " + sCourseNbr);
            Console.WriteLine("    Course Name: " + sCourseName);
            Console.WriteLine("    Course Credits: " + sCredits);
            Console.WriteLine("    Semester: " + sSemester);
            Console.WriteLine("    Year: " + sCourseYear);
            Console.WriteLine("    Course Type: " + sCourseType);
            Console.WriteLine("    Course Grade: " + sCourseGrade);
            Console.WriteLine("========================================================================");
        }
        /// <summary>
        /// Writes out all the course information in a formatted block of course information in one long string object.
        /// </summary>
        /// <returns>String of course information formatted properly.</returns>
        public string CourseWriteString()
        {

            string courseInfoString = Environment.NewLine +
                "Course ID: " + sCourseID + Environment.NewLine +
            "    Course Number: " + sCourseNbr + Environment.NewLine +
            "    Course Name: " + sCourseName + Environment.NewLine +
            "    Course Credits: " + sCredits + Environment.NewLine +
            "    Semester: " + sSemester + Environment.NewLine +
            "    Year: " + sCourseYear + Environment.NewLine +
            "    Course Type: " + sCourseType + Environment.NewLine +
            "    Course Grade: " + sCourseGrade + Environment.NewLine +
            "========================================================================";
            return courseInfoString;
        }
    }

    //main output class which displays the query results
    class Output
    {
        //used to know whether to do the GUI methods or command line methods.
        private bool usingGUI = false;
        private string studentInfoString;

        /// <summary>
        /// Constructor to let the class know it's for the GUI.
        /// </summary>
        /// <param name="usingGUI"></param>
        public Output(bool usingGUI)
        {
            this.usingGUI = (usingGUI) ? true : false;
        }

        /// <summary>
        /// Empty constructor to maintain legacy code.
        /// </summary>
        public Output() { }
        //display student info from arbitrary array input
        //incoming list is formatted such that...
        //slot 0 is hard-coded to list the number of incoming query results
        //slot 1 is hard-coded as the queried student ID
        //slots 2 and 3 are hard-coded as the queried student's first and last name respectively
        //slots 4 and onward list queried course data of arbitrary length
        public void InfoDisplay(List<string> sFoundStudent)
        {
            //display number of results passed in from query
            Console.WriteLine("Number of entries found: " + sFoundStudent[0]);

            //display student name and ID before listing courses
            Console.WriteLine("Student ID: " + sFoundStudent[1]);
            Console.WriteLine("Student Name: " + sFoundStudent[3] + ", " + sFoundStudent[2]);
            Console.WriteLine("------------------------------------------------------------------------");

            //iterate through incoming list of course results into a placeholder instance of CourseItem and then call the CourseWrite method to display the info of each returned class
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
                if (usingGUI)
                {
                    ciTempCourse.CourseWriteString();
                }
                else
                {
                    ciTempCourse.CourseWrite();
                }
                
            }
            //Pause for user
            Console.ReadLine();
        }

        /// <summary>
        /// InfoDisplay Method Override to work for GUI
        /// </summary>
        /// <param name="sFoundStudent">The student(s) found.</param>
        /// <param name="usingGUI">Indicated whether the GUI version of method should be used.</param>
        /// <returns>Returns all textual information from the found student.</returns>
        public string InfoDisplay(List<string> sFoundStudent, bool usingGUI)
        {
            if (usingGUI)
            {
                studentInfoString = "Number of entries found: " + sFoundStudent[0] + Environment.NewLine +
                    "Student ID: " + sFoundStudent[1] + Environment.NewLine +
                "Student Name: " + sFoundStudent[3] + ", " + sFoundStudent[2] + Environment.NewLine +
                "------------------------------------------------------------------------" + Environment.NewLine;
            }
            else
            {
                InfoDisplay(sFoundStudent);
            }


            //iterate through incoming list of course results into a placeholder instance of CourseItem and then call the CourseWrite method to display the info of each returned class
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
                studentInfoString += ciTempCourse.CourseWriteString();
                
            }
            return studentInfoString;
        }

        //dump any text output to console and return next command
        //USED BY INPUT - DO NOT DELETE
        public String ReadInfoDisplay(String sInString)
        {
            Console.Write(sInString);
            return Console.ReadLine();
        }

        //dump any text output to console without returning anything
        //USED BY INPUT - DO NOT DELETE
        public void DumbInfoDisplay(String sInString)
        {
            Console.WriteLine(sInString);
        }

    }
}
