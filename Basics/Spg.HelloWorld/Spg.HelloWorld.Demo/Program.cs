// See https://aka.ms/new-console-template for more information
using Spg.HelloWorld.Demo.Model;
using System.Reflection;

Console.WriteLine("Hello, World!");

Student student = new Student();
student.FirstName = null;
student.LastName = "Schrutek";
student.Gender = Genders.Female;
student.Save();

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

Console.WriteLine("*****************************************");

int n = 5;
Increment(ref n);

static void Increment(ref int p)
{
    p++;
}

Console.WriteLine(n);


string s5 = "4711a";
try
{
    double n5 = double.Parse(s5);
    Console.WriteLine(n5);
}
catch (FormatException ex)
{
    Console.WriteLine("Keine Nummer!");
}
catch (ArgumentNullException ex)
{
    Console.WriteLine("Wert war NULL!");
}

double result;
Halabulu h1 = new Halabulu();
if (!double.TryParse(s5, out result))
{
    Console.WriteLine("Parse konnte nicht durchgeführt werden!");
}
Console.WriteLine($"{result}");
h1.Result = result;


string myStr = null;
int len = 0;
//try
//{
    len = myStr?.Length ?? 0;
//}
//catch (NullReferenceException)
//{
//    Console.Error.WriteLine("OOPS.");
//}


string _dateString = "08 07 2021";

(int day, int month, int year) SplitDateAsString()
{
    string dayText = _dateString.Substring(0, 2);
    string monthText = _dateString.Substring(3, 2);
    string yearText = _dateString.Substring(6, 4);
    var day = int.Parse(dayText);
    var month = int.Parse(monthText);
    var year = int.Parse(yearText);

    return (day, month, year);
}

//int day = SplitDateAsString();
(int xy, int month, int year) = SplitDateAsString();
Console.WriteLine(xy);


SchoolClass schoolClass = new SchoolClass("3BHIF");
//schoolClass.Name = "";
schoolClass.MaxStudents = 30;

Console.WriteLine(schoolClass.MaxStudents);





static Halabulu MyParse(string p)
{
    double r = 0;
    bool d = double.TryParse(p, out r);

    double.Parse(r.ToString());

    Halabulu result = new Halabulu();
    result.Done = d;
    result.Result = r;

    return result;
}


public class Halabulu
{
    public double Result { get; set; }
    public bool Done { get; set; }
}