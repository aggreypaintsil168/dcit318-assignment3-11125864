using System;
using System.Collections.Generic;
using System.IO;
using GradingSystem.Models;
using GradingSystem.Exceptions;
using GradingSystem.Services;

namespace GradingSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string inputFilePath = Path.Combine(AppContext.BaseDirectory, "Student.txt");
            string outputFilePath = Path.Combine(AppContext.BaseDirectory, "Report.txt");

            var processor = new StudentResultProcessor();

            try
            {
                List<Student> students = processor.ReadStudentsFromFile(inputFilePath);
                processor.WriteReportToFile(students, outputFilePath);

                Console.WriteLine($"Report successfully written to {outputFilePath}");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Error: The input file was not found.");
            }
            catch (InvalidScoreFormatException ex)
            {
                Console.WriteLine($"Invalid Score Format: {ex.Message}");
            }
            catch (System.MissingFieldException ex)
            {
                Console.WriteLine($"Missing Field: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
            }
        }
    }
}
