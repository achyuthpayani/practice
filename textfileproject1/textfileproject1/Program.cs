using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace textfileproject
{
    class Program
    {
        String filename = "C:\\Users\\11036845\\Desktop\\textfile\\text.txt";

        static void Main(string[] args)
        {
            Program p = new Program();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\t\t\t\tWELCOME TO RAINBOW SCHOOL");
            Console.ForegroundColor = ConsoleColor.White;
          //  List<String> l = new List<string>();
            if (!File.Exists(p.filename))
            {
                var file = File.CreateText(p.filename);
                file.Close();
            }
        intro:
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("1.add teacher details\n" +
                "2.display details any teacher the teacher\n" +
                "3.Update the details of the teacher\n" +
                "4.display details of all teachers\n" +
                "5.Exit");
            String x = Console.ReadLine();
            switch (x)
            {
                case "1":

                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("enter the id of the teacher");
                    String id = Console.ReadLine();
                 //   l.Add(id);
                    Console.WriteLine("enter the name of the teacher");
                    String name = Console.ReadLine();
                    Console.WriteLine("enter the class of teacher");
                    String cls = Console.ReadLine();
                    Console.WriteLine("enter the section od teacher");
                    String sec = Console.ReadLine();
                    String k = $"the teacher id is {id} , teacher name is {name} , teacher class is {cls}, teacher section is {sec }";
                    Console.ForegroundColor = ConsoleColor.White;
                    p.addTeacher(k);
                    goto intro;
                    break;
                case "4":

                    p.displayDetails();
                    goto intro;
                    break;
                case "2":
                    p.diplayone();
                    goto intro;
                    break;
                case "3":
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("\tenter the id of teacher whose details to be updated");
                    id = Console.ReadLine();
                    var logFile = File.ReadAllLines(p.filename);
                    var logList = new List<string>(logFile);

                    bool f = true;
                    int i = 0;
                    foreach (String a in logList)
                    {
                        if (a.Contains(id))
                        {
                            f = false;
                            break;
                        }
                        i += 1;
                    }
                    if (f == true)
                    {

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\t\t\tTeacher Id not found. please enter the correct Id.");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        p.update(id);
                    }
                    goto intro;
                    break;
                case "5":
                    break;



            }
        }

        public void diplayone()
        {
            var logFile = File.ReadAllLines(filename);
            var logList = new List<string>(logFile);
            Console.WriteLine("enter the id of the teacher");
            String id = Console.ReadLine();
            Boolean b = true;
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            StreamReader sr = new StreamReader(filename);
            String s = sr.ReadLine();
            while (s != null)
            {
               // Console.WriteLine(s);
              
                if (s.Contains(id))
                {
                    b = false;
                    break;
                }
                s = sr.ReadLine();
            }
            Console.ForegroundColor = ConsoleColor.White;
            sr.Close();
            if (b == true)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Id not found");

            }
            else
            {

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(s);
            }
        }

        public void addTeacher(String k)
        {
            StreamWriter wrt = new StreamWriter(filename, append: true);
            wrt.WriteLine(k);
            wrt.Close();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("\t\t\t\tADDED THE DETAILS OF TEACHER SUCCESSFULLY.");
            Console.ForegroundColor = ConsoleColor.White;
        }
        public void displayDetails()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\t\t\t\tlist of teachers in file are");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            StreamReader sr = new StreamReader(filename);
            String s = sr.ReadLine();
            while (s != null)
            {
                Console.WriteLine(s);
                s = sr.ReadLine();
            }
            Console.ForegroundColor = ConsoleColor.White;
            sr.Close();
        }
        public void update(String id)
        {
            Console.WriteLine("Enter the updated id of the teacher");
            String i = Console.ReadLine();
            Console.WriteLine("Enter the updated name of the teacher");
            String name = Console.ReadLine();
            Console.WriteLine("Enter the updated class of the teacher");
            String cls = Console.ReadLine();
            Console.WriteLine("Enter the updated section of teacher");
            String sec = Console.ReadLine();
            String k = $"teacher id is {i},teacher name is {name},teacher class is {cls} section is  {sec}";
            var logFile = File.ReadAllLines(filename);
            var logList = new List<string>(logFile);
            logList.Add(k);
            File.Delete(filename);
            var file = File.CreateText(filename);
            file.Close();
            StreamWriter wrt = new StreamWriter(filename, append: true);
            int linenumber = 0;
            foreach (var l in logList)
            {
                if (l.Contains(id) && linenumber == 0)
                {
                    linenumber += 1;
                    continue;
                }
                wrt.WriteLine(l);
            }
            wrt.Close();
        }
         

        
    }
}

