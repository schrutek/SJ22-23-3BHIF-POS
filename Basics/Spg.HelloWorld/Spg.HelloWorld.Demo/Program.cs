// See https://aka.ms/new-console-template for more information
using Spg.HelloWorld.Demo;
using Spg.HelloWorld.Demo.Delegates;
using Spg.HelloWorld.Demo.Model;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;

Console.WriteLine("Hello, World!");

Student student = new Student("");
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


SchoolClass schoolClass = new SchoolClass() { Name = "3BHIF", MaxStudents = 30 };
//schoolClass.Name = "12BHIF";

List<SchoolClass> schoolClasses = new List<SchoolClass>()
{
    new SchoolClass() { Name = "3BHIF", MaxStudents = 28 },
    new SchoolClass() { Name = "4BHIF", MaxStudents=15 },
    new SchoolClass() 
    { 
        Name = "5BHIF", 
        MaxStudents=15,
        Students = new List<Student>()
        {
            new Student("") { FirstName="Student01", LastName="StudentLastName01", Gender=Genders.Female },
            new Student("") { FirstName="Student02", LastName="StudentLastName02", Gender=Genders.Female },
            new Student("") { FirstName="Student03", LastName="StudentLastName03", Gender=Genders.Female },
            new Student("") { FirstName="Student04", LastName="StudentLastName04", Gender=Genders.Female },
            new Student("") { FirstName="Student05", LastName="StudentLastName05", Gender=Genders.Female },
            new Student("") { FirstName="Student06", LastName="StudentLastName06", Gender=Genders.Female },
        }
    },
    new SchoolClass() { Name = "6BHIF", MaxStudents=15 },
    new SchoolClass() { Name = "7BHIF", MaxStudents=15 }
};

foreach (SchoolClass item in schoolClasses)
{
    Console.WriteLine($"Name: {item.Name}, Studierende: {item.Students.ToList().Count}");
}

SchoolClass schoolClass1 = new SchoolClass() { Name = "8BHIF", MaxStudents = 30 };
SchoolClass schoolClass2 = new SchoolClass() { Name = "9BHIF", MaxStudents = 30 };





IDictionary<string, Student> personDict = new Dictionary<string, Student>();
personDict.Add("One", new Student("") { Id = 1, FirstName = "Zuname1", LastName = "Vorname1" });
personDict.Add("Two", new Student("") { Id = 2, FirstName = "Zuname2", LastName = "Vorname2" });
personDict.Add("Three", new Student("") { Id = 3, FirstName = "Zuname3", LastName = "Vorname3" });

Student s6 = personDict["Two"];





schoolClasses.Add(schoolClass1);
schoolClasses.Add(schoolClass1);
schoolClasses.Add(schoolClass1);

schoolClasses.Remove(schoolClass1);

PhilipList<Student> philipList = new PhilipList<Student>()
{
     new Student("") { FirstName="Student06", LastName="StudentLastName06", Gender=Genders.Female },
};

Console.WriteLine(schoolClass.MaxStudents);

int[] intArray = new int[] { 1, 2, 3, 4, 5, 6 };

string s2 = "Hello World and whatever!";
string[] s3 = s2.Split(' ');
Console.WriteLine(s3[2]);


string s8 = "HelLo World!"[..];


//MyStudentList<Student> myStudentList = new MyStudentList<Student>()
//{
//    new Student("") { FirstName="Student10", LastName="StudentLastName10", Gender=Genders.Female },
//    new Student("") { FirstName="Student11", LastName="StudentLastName11", Gender=Genders.Female },
//    new Student("") { FirstName="Student12", LastName="StudentLastName12", Gender=Genders.Female },
//};

//Student foundStudent = myStudentList["Student11"];

Console.WriteLine("----------------------------------");
OldSchool p = new();
p.DoSomeWork();

StudentList myStudentList = new StudentList()
{
    new Student("") { FirstName="AStudent01", LastName="AStudentLastName01", Gender=Genders.Female },
    new Student("") { FirstName="AStudent02", LastName="AStudentLastName02", Gender=Genders.Female },
    new Student("") { FirstName="BStudent03", LastName="BStudentLastName03", Gender=Genders.Female },
    new Student("") { FirstName="BStudent04", LastName="BStudentLastName04", Gender=Genders.Female },
    new Student("") { FirstName="BStudent10", LastName="BStudentLastName10", Gender=Genders.Female },
    new Student("") { FirstName="AStudent11", LastName="AStudentLastName11", Gender=Genders.Female },
    new Student("") { FirstName="CStudent12", LastName="CStudentLastName12", Gender=Genders.Female },
};

List<Student> resultList = myStudentList.Filter(s => s.LastName.StartsWith("A"));







foreach (Student item in resultList)
{
    Console.WriteLine(item.ToString());
}
bool FirstNameStratsWith(Student s)
{
    return s.LastName.StartsWith("A");
}

bool LastNameEndsWith(Student s)
{
    return s.LastName.EndsWith("2");
}

bool LastNameContains(Student s)
{
    return s.LastName.Contains("0");
}

Console.ReadLine();

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