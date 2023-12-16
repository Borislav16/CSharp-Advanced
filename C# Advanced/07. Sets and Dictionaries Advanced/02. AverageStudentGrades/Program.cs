using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._AverageStudentGrades
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numGrades = int.Parse(Console.ReadLine());

            Dictionary<string, List<decimal>> studentInfo = new Dictionary<string, List<decimal>>();

            for (int i = 0; i < numGrades; i++)
            {
                string[] gradeInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string name = gradeInfo[0];
                decimal grade = Convert.ToDecimal(gradeInfo[1]);

                if (!studentInfo.ContainsKey(name))
                {
                    studentInfo.Add(name, new List<decimal>() { grade });
                }
                else
                {
                    studentInfo[name].Add(grade);
                }
            }

            foreach (var student in studentInfo)
            {
                Console.WriteLine($"{student.Key} -> {string.Join(' ', student.Value.Select(grade => grade.ToString("F2")))} (avg: {student.Value.Average():f2})");
            }
        }

        
    }
}
