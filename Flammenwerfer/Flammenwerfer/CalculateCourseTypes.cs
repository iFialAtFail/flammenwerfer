﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
  This will take in the list (calculator) and iterate through while checking the type of course.
  There will be a counter for each type of course which will be used to calculate the percentage of the courses completed. 
 */

namespace Flammenwerfer
{
    class CalculateCourseTypes
    {
        string core = "core";
        string genEd = "general education";
        string elective = "elective";
        int coreCounter = 0;
        int genEdCounter = 0;
        int electiveCounter = 0;
                
        public void courseChecker(List<string> courseCheckerInput)
        {            
            for (int k = 0; k < courseCheckerInput.Count; k++)
            {
                if (core.ToUpper().Equals(courseCheckerInput[k].ToUpper()))
                {
                    coreCounter = coreCounter + 1;
                }
                else if (genEd.ToUpper().Equals(courseCheckerInput[k].ToUpper()))
                {
                    genEdCounter = genEdCounter + 1;

                }
                else if (elective.ToUpper().Equals(courseCheckerInput[k].ToUpper()))
                {
                    electiveCounter = electiveCounter + 1;

                }
                
            }
            Console.WriteLine("Percentage of core courses completed: " + Math.Round(((double)coreCounter / 26) * 100, 3) + "%");
            Console.WriteLine("Percentage of general education classes completed: " + Math.Round(((double)genEdCounter / 8) * 100, 3) + "%");
            Console.WriteLine("Percentage of electives completed: " + Math.Round(((double)electiveCounter / 8) * 100, 3)  + "%");
            
        }

    }
}



           
       