using System;
using System.Collections.Generic;
using System.Text;

namespace ExamAnexinet
{
    public interface IExercises
    {
        // Fisrt Exercise
        string StringToDate(string posibleDate);
        // Second Exercise
        string CharactersRepeated(string firstString, string secondString);
        // Third Exercise
        string CompressedString(string uncompressedString);
        // Fourth Exercise
        bool ProperlyClosedBrackets(string bracketsString);
        // Fifth Exercise
        string SmallestBoundingBox(Point[] pts);
    }
}
