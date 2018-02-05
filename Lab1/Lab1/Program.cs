using System;

using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Lab1
{
    abstract class Program
    {
       static List<string> words;
        static void Main(string[] args)
        {
            
            bool loop = true;
            while (loop)
            {
                
                System.Console.WriteLine("1 - Import Words From File\n2 - Bubble Sort words\n3 - LINQ/Lambda sort words\n4 - Count the Distinct Words\n5 - Take the first 10 words\n6 - Get the number of words that start with 'j' and display the count\n7 - Get and display of words that end with 'd' and display the count\n8 - Get and display of words that are greater than 4 characters long, and display the count\n9 - Get and display of words that are less than 3 characters long and start with the letter 'a', and display the count\nx – Exit");
               string opt = System.Console.ReadLine();
                switch (opt)
                {
                    case "1":
                        readText();       
                        break;
                    case "2":
                        BubbleSort(words);
                        break;
                    case "3":
                        lambdaSort();
                        break;
                    case "4":
                        distinctWords();
                        break;
                    case "5":
                        first10Words();
                        break;
                    case "6":
                        startsWithJ();
                        break;
                    case "7":
                        endsWithD();
                        break;
                    case "8":
                        fourCharLong();
                        break;
                    case "9":
                        lessThan3Chars();
                        break;
                    case "x":
                        loop = false;
                        System.Console.WriteLine("x");
                        break;
                }
            }

        } 
        public static void readText()
        {
            string path = @"E:\Algonquin College\Semester 5\CST8359_300 .Net Enterprise Application\Labs\Lab 01\Lab 1 Demo\Words.txt";
            words = new List<string>();
            FileStream fs = new FileStream(path, FileMode.Open);
            StreamReader sr = new StreamReader(fs);
            while (sr.Peek() >= 0)
            {
                string wordByword = sr.ReadLine();
                words.Add(wordByword);
                 
            }
            System.Console.WriteLine(words.Count());
            
           
        }

        public static string[] BubbleSort(List<string> words)
        {
         
            int count = words.Count;
            
            string[] a = { };
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            for (int i = 0; i < count; i++)
            {
                for (int j = 0; j < count - 1; j++)
                {
                    if (words[j].CompareTo(words[j + 1]) > 0)
                    {
                        string temp = words[j];
                        words[j] = words[j + 1];
                        words[j + 1] = temp;
                    }
                }
                
            }
            stopWatch.Stop();
            /* Console.Write("\n\nAfter sorting the array appears like : \n");
             for (int i = 0; i < count; i++)
             {
                 Console.WriteLine(words[i] + " ");
             }*/
            Console.WriteLine(stopWatch.ElapsedMilliseconds.ToString() + "ms");
            return a;
        }
    
        public static void lambdaSort()
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            var sort = (from w in words orderby w select w).ToList();
            stopWatch.Stop();
            Console.WriteLine(stopWatch.ElapsedMilliseconds.ToString() + "ms");
            /*int numberOfWords = 0;

            foreach (var word in sort)
            {
                numberOfWords++;
                Console.Write(word + " ");
            }*/
        }

        public static void distinctWords()
        {
            var distinct = ((from w in words select w).Distinct().ToList());
            int numberOfWords = 0;
            foreach (var disWord in distinct)
            {
                numberOfWords++;
               /* Console.Write(disWord + " ");*/
               
            }
            Console.WriteLine(numberOfWords);
        }

        public static void first10Words()
        {
            var first10 = ((from w in words  select w).Take(10)) ;
            //int numberOfWords = 0;
            foreach (var first10word in first10)
            {
               /* numberOfWords++;*/
                Console.WriteLine(first10word + " ");

            }
            //Console.WriteLine(numberOfWords);
        }

        public static void startsWithJ()
        {
            var StartsWithJ = (from w in words where w.StartsWith("j") select w);
            int numberOfWords = 0;
            foreach (var StartswithJ in StartsWithJ)
            {
                 numberOfWords++;
                 Console.WriteLine(StartswithJ + " ");

            }
            Console.WriteLine(numberOfWords);
        }

        public static void endsWithD()
        {
            var EndsWithD = (from w in words where w.EndsWith("d") select w);
            int numberOfWords = 0;
            foreach (var EndswithD in EndsWithD)
            {
                numberOfWords++;
                Console.WriteLine(EndswithD + " ");

            }
            Console.WriteLine(numberOfWords);
        }
        public static void fourCharLong()
        {
            var FourCharLong = (from w in words where w.Length > 4 select w);
            int numberOfWords = 0;
            foreach (var fourcharLong in FourCharLong)
            {
                numberOfWords++;
                Console.WriteLine(fourcharLong + " ");

            }
            Console.WriteLine(numberOfWords);
        }
        public static void lessThan3Chars()
        {
            var LessThan3Chars = (from w in words where w.Length < 3 && w.StartsWith("a")  select w);
            int numberOfWords = 0;
            foreach (var Lessthan3Chars in LessThan3Chars)
            {
                numberOfWords++;
                Console.WriteLine(Lessthan3Chars + " ");

            }
            Console.WriteLine(numberOfWords);
        }
    }
    
}


