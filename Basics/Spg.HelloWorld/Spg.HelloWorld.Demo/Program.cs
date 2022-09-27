// See https://aka.ms/new-console-template for more information
using Spg.HelloWorld.Demo.Model;
using System.Reflection;

Console.WriteLine("Hello, World!");

Student student = new Student();
student.FirstName = null;
student.LastName = "Schrutek";
student.Gender = Genders.Female;

PropertyInfo[] properties = student.GetType().GetProperties();

//string input = Console.ReadLine();

int i = new int();
i = 5;

Nullable<int> j = 3;
int? k = null;
//if (j.HasValue)
//{
Console.WriteLine(j ?? k ?? -1);
//}

//if (student != null)
//{
//    if (student.FirstName != null)
//    {
        Console.WriteLine(student?.FirstName?.ToLower() ?? "none");
//    }
//}

string s = "Hello World!";
Console.WriteLine(s);

// COALESCE(a, b, c, d, ...) // SQL