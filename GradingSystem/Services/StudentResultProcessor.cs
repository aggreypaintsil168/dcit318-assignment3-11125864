using System;
using System.Collections.Generic;
using System.IO;
using GradingSystem.Models;
using GradingSystem.Exceptions;

namespace GradingSystem.Services
{
    public class StudentResultProcessor
    {
        public List<Student> ReadStudentsFromFile(string inputFilePath)
        {
            var students = new List<Student>();

            using var reader = new StreamReader(inputFilePath);
            string? line;
            int lineNumber = 1;

            while ((line = reader.ReadLine()) != null)
            {
                var parts = line.Split(',');

                if (parts.Length != 3)
                    throw new System.MissingFieldException($"Line {lineNumber}: Expected 3 fields but found {parts.Length}.");

                if (!int.TryParse(parts[0], out int id))
                    throw new FormatException($"Line {lineNumber}: Student ID is not a valid integer.");

                string fullName = parts[1].Trim();

                if (!int.TryParse(parts[2], out int score))
                    throw new InvalidScoreFormatException($"Line {lineNumber}: Score '{parts[2]}' is invalid.");

                students.Add(new Student(id, fullName, score));
                lineNumber++;
            }

            return students;
        }

        public void WriteReportToFile(List<Student> students, string outputFilePath)
        {
            using var writer = new StreamWriter(outputFilePath, false);

            foreach (var student in students)
            {
                writer.WriteLine($"{student.FullName} (ID: {student.Id}): Score = {student.Score}, Grade = {student.GetGrade()}");
            }
        }
    }
}
