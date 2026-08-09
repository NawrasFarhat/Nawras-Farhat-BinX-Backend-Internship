//value-type
int age=23;
double price=2.5;
bool isValid=true;

// reference-type
string name="Nawras";
int[] number={10,20,30,40};
string[] courses= {"c#","backend"};

//Print Types
Console.WriteLine(age.GetType());  
Console.WriteLine(price.GetType());  
Console.WriteLine(isValid.GetType());  
Console.WriteLine(name.GetType());  
Console.WriteLine(number.GetType());  
Console.WriteLine(courses.GetType());  

//demonstrates the value-vs-reference copy behavior
DemonstratesValueVSReference();

void DemonstratesValueVSReference()
{
//Value_Type
    int num1=10;
    int num2=num1;
    Console.WriteLine("Before");
    Console.Write(num1+" ");
    Console.WriteLine(num2);
    num2=20;
    Console.WriteLine();
    Console.WriteLine("After");
    Console.Write(num1+" ");
    Console.WriteLine(num2);
    Console.WriteLine();

//Reference_Type
    int[] arr1={1,2,3,4,5};
    int[] arr2= arr1;
    Console.WriteLine("Before");
    foreach(int num in arr1)
    {
        Console.Write(num+" ");
    }
    Console.WriteLine();
        foreach(int num in arr2)
    {
        Console.Write(num+" ");
    }
    Console.WriteLine();
    Console.WriteLine();

    Console.WriteLine("After");
    arr2[0]=100;
        foreach(int num in arr1)
    {
        Console.Write(num+" ");
    }
    Console.WriteLine();
        foreach(int num in arr2)
    {
        Console.Write(num+" ");
    }
    Console.WriteLine();
    Console.WriteLine();
}
Console.WriteLine(DescribeGrade(40));

//grade-classifier method
string DescribeGrade(int score)=> score switch
{
    >=90 => "Excellent",
    >=70 => "Proficient",
    >=50 => "Developing",
      _ => "Below Standard"

};

//reads user input
Console.Write("Enter Your Name: ");
string? yourName= Console.ReadLine();

if( yourName!= null)
{
    Console.WriteLine($"Hello, {yourName}");
}
else
{
    Console.WriteLine("No Input");
}