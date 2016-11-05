using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 This will take in the list (calculator) from output.cs and iterate through the length. 
 The amount of times it iterates through will be the number of classes completed
 */
namespace Flammenwerfer
{
     class CalculateTotalPercentage
    {
        public int progressCalculator(List<string>calculatorInput)
        {
            int counter = 0; 

            for (int i = 0; i < calculatorInput.Count; i++)
            {
                counter = counter + 1; 
            }
           
            return counter; 
        }
    }
}
