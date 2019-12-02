using System;

using System.Linq;

namespace ExamAnexinet
{
    public class TestAnexinet : IExercises
    {
        static void Main(string[] args)
        {
            TestAnexinet testAnexinet = new TestAnexinet();
            string result = String.Empty;
            bool isProperlyClosedBrackets = false;

            #region First Exercise
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("First Exercise");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(result = testAnexinet.StringToDate("02/02/2021"));
            Console.ResetColor();

            Console.WriteLine(String.Empty);
            Console.WriteLine(String.Empty);
            Console.WriteLine(String.Empty);
            #endregion

            #region Second Exercise
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Second Exercise");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(result = testAnexinet.CharactersRepeated("First String", "Second String"));
            Console.ResetColor();

            Console.WriteLine(String.Empty);
            Console.WriteLine(String.Empty);
            Console.WriteLine(String.Empty);
            #endregion

            #region Third Exercise
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Third Exercise");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(result = testAnexinet.CompressedString("aabbcccaaa"));
            Console.ResetColor();

            Console.WriteLine("");
            Console.WriteLine(String.Empty);
            Console.WriteLine(String.Empty);
            #endregion

            #region Fourth Exercise
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Fourth Exercise");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(isProperlyClosedBrackets = testAnexinet.ProperlyClosedBrackets("([][])((]]"));
            Console.ResetColor();

            Console.WriteLine(String.Empty);
            Console.WriteLine(String.Empty);
            Console.WriteLine(String.Empty);
            #endregion

            #region Fifth Exercise
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Fifth Exercise");
            Console.ResetColor();
            Point[] pts = new Point[5];
            pts[0] = new Point()
            {
                X = 0,
                Y = 0
            };
            pts[1] = new Point()
            {
                X = -1,
                Y = 1
            };
            pts[2] = new Point()
            {
                X = 1,
                Y = -1
            };
            pts[3] = new Point()
            {
                X = 1,
                Y = 1
            };
            pts[4] = new Point()
            {
                X = -1,
                Y = -1
            };
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(result = testAnexinet.SmallestBoundingBox(pts));
            Console.ResetColor();

            Console.WriteLine(String.Empty);
            Console.WriteLine(String.Empty);
            Console.WriteLine(String.Empty);
            #endregion
        }


        // Fisrt Exercise
        public string StringToDate(string posibleDate)
        {
            try
            {
                DateTime date = Convert.ToDateTime(posibleDate);

                // This works too
                //return (DateTime.IsLeapYear(date.Year) ? "Leap Year" : "Not a Leap Year");

                if (date.Year % 400 == 0)
                    return($"{date.Year} is a Leap Year");
                else if (date.Year % 100 == 0)
                    return($"{date.Year} is not a Leap Year");
                else if (date.Year % 4 == 0)
                    return($"{date.Year} is a Leap Year");
                else
                    return ($"{date.Year} is not a Leap Year");
            }
            catch (Exception)
            {
                return $"Datetime.IsLeapYear() can't be used";
            }            
        }
        
        // Second Exercise
        public string CharactersRepeated(string _firstString, string _secondString)
        {
            // This works too
            //var _repeatCharacters = _firstString.Replace(" ", String.Empty).ToLower();

            var fullString = String.Empty;
            var repeatedCharactersFirst = new string(_firstString.ToLower().ToCharArray().Where(X => !char.IsWhiteSpace(X)).ToArray());
            var repeatedCharactersSecond = new string(_secondString.ToLower().ToCharArray().Where(Y => !char.IsWhiteSpace(Y)).ToArray());

            string uniqueCharactersFirst = String.Empty;
            string uniqueCharactersSecond = String.Empty;

            for (int i = 0; i < repeatedCharactersFirst.Length; i++)
            {            
                if (!uniqueCharactersFirst.Contains(repeatedCharactersFirst[i]))
                    uniqueCharactersFirst += repeatedCharactersFirst[i];
            }

            for (int i = 0; i < repeatedCharactersSecond.Length; i++)
            {
                if (!uniqueCharactersSecond.Contains(repeatedCharactersSecond[i]))
                    uniqueCharactersSecond += repeatedCharactersSecond[i];
            }

            if (uniqueCharactersFirst.Length < uniqueCharactersSecond.Length)
            {
                for (int i = 0; i < uniqueCharactersFirst.Length; i++)
                {
                    var result = uniqueCharactersSecond.SingleOrDefault(R => R == uniqueCharactersFirst[i]);
                    if (result.ToString() != "\0")
                        fullString += uniqueCharactersFirst[i];
                }
            }
            else
            {
                for (int i = 0; i < uniqueCharactersSecond.Length; i++)
                {
                    var result = uniqueCharactersFirst.SingleOrDefault(R => R == uniqueCharactersSecond[i]);
                    if (result != 0)
                        fullString += uniqueCharactersSecond[i];
                }
            }

            Console.WriteLine($"Original String: |{_firstString}| and |{_secondString}|");
            Console.WriteLine($"Without repeated char: |{uniqueCharactersFirst}| and |{uniqueCharactersSecond}|");

            return ($"Char repeated in both strings |{fullString}|");
        }
        
        // Third Exercise
        public string CompressedString(string uncompressedString)
        {
            string compressedString = String.Empty;

            var currentCharacter = uncompressedString[0].ToString();
            var counter = 1;
            
            for(int i = 1; i<uncompressedString.Length; i++)
            {
                if(uncompressedString[i].ToString() == currentCharacter)
                    counter++;
                else
                {
                    compressedString += currentCharacter + counter;
                    currentCharacter = uncompressedString[i].ToString();
                    counter = 1;
                }
            }

            compressedString += currentCharacter + counter;

            if (compressedString.Length >= uncompressedString.Length)
                return uncompressedString;
            else
            {
                Console.WriteLine(uncompressedString);
                return compressedString;
            }
        }

        // Fourth Exercise
        public bool ProperlyClosedBrackets(string bracketsString)
        {
            if (bracketsString.Length % 2 == 0)
            {
                Console.WriteLine($"Initial String |- {bracketsString} -|");
                int length = bracketsString.Length;

                while (length > 0 && bracketsString.Length > 0)
                {
                    for (int i = 0; i < bracketsString.Length; i++)
                    {
                        switch(bracketsString[i])
                        {
                            case '[':
                                if(bracketsString[i + 1] == ']')
                                    bracketsString = bracketsString.Remove(i, 2);
                                break;
                            case '(':
                                if (bracketsString[i + 1] == ')')
                                    bracketsString = bracketsString.Remove(i, 2);
                                break;
                        }
                        //Console.WriteLine(bracketsString);
                        length--;
                    }
                }

                if (bracketsString.Length > 0)
                    return false;
                else
                    return true;
            }
            else
                return false;
        }
        
        // Fifth Exercise
        public string SmallestBoundingBox(Point[] pts)
        {
            int Xmin = 0;
            int Xmax = 0;
            int Ymin = 0;
            int Ymax = 0;

            foreach (var pt in pts)
            {
                if (pt.X > Xmax)
                    Xmax = pt.X;
                else if (pt.X < Xmin)
                    Xmin = pt.X;

                if (pt.Y > Ymax)
                    Ymax = pt.Y;
                else if (pt.Y < Ymin)
                    Ymin = pt.Y;
            }

            var upperLeftCorner = new Point() { X = Xmin, Y = Ymax };
            var lowerLeftCorner = new Point() { X = Xmin, Y = Ymin };
            var upperRightCorner = new Point() { X = Xmax, Y = Ymax };
            var lowerRightCorner = new Point() { X = Xmax, Y = Ymin };

            var height = Ymax - Ymin;
            var width = Xmax - Xmin;

            var result = height * width;

            return $"The bounding box's area of points [(0,0), (-1,1), (1, -1), (1, 1), (-1, -1)] is {result}. ";
        }
    }

    public sealed class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
}
