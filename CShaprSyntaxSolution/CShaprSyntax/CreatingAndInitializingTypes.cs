using System.Text;

namespace CSharpSyntax;

public class CreatingAndInitializingTypes
{
    // Explicit variables can be defined at the class level
    // Var can only be used on local variables within methods
    string classLevelVariable = "IAmAccessibleByAllMethodsInClass";
    
    [Fact]
    public void UsingLiteralsToCreateInstancesOfTypes()
    {
        // Local variables; All C# code must be within a data type: class
        // All variables must be within a method, or property (execution context)
        string myName = "Kevin";
        int myAge = 32;
        bool isLegalToDrink = myAge >= 21;

        Assert.True(isLegalToDrink);
        Assert.Equal(32, myAge);
    }

    [Fact]
    public void ImplicitTypedLocalVariable()
    {
        // Var = local variables only & must be initialized when declared.
        var myAge = 32;

        decimal myPay = 70.0M; // twinsies
        var alsoMyPay = 70.0M; // twinsies

        // var use case
        var simplified = new AnnoyinglyLongAndSpecificClassName();

    }

    /* 
       String builder is a great tool for use cases where a string will be
       altered many times, or for alterations on very large strings.
       This is because it will be a consistent object on the heap
       vs standard, immutable strings which create copies and allocate 
       additional space on the heal when they are altered. String builder is
       more cumbersome to work with but more memory efficient then strings.
    */
    [Fact]
    public void MutableStringsWithStringBuilder()
    {
        var message = new StringBuilder();

        foreach(var num in Enumerable.Range(1, 10000))
        {
            message.Append(num.ToString() + ", ");
        }
    }

    [Fact]
    public void MoreAboutStrings()
    {
        var name = "Bob"; 
        var age = 33;
        var pay = 120_000.00M;

        var message = "The name is " + name + " and the age is " + age + ".";
        var message2 = string.Format("The name is {0} and the age is {1} (again, name: {0})", name, age);
        var m3 = $"{name} makes {pay:c} a year";
    }

    [Fact]
    public void DoingConversionsOnTypes()
    {
        string myPay = "70000.00";

        // decimal payAsNumber = decimal.Parse(myPay); -null pointer potential

        //parsing
        if(decimal.TryParse(myPay, out decimal payAsNumber))
        {
            Assert.Equal(70000.00M, payAsNumber);
        }
        else
        {
            Assert.True(false);
        }

        var birthdate = DateTime.Parse("11/10/1990");
        Assert.Equal(11, birthdate.Month);
        Assert.Equal(10, birthdate.Day);
        Assert.Equal(1990, birthdate.Year);

    }

    /* 
     * Use case example:
     *  while (true)
{
        Console.Write("How old are you?: ");
        var enteredAge = Console.ReadLine();     
        
        if (int.TryParse(enteredAge, out int age)) 
    {

        Console.WriteLine($"You are {age} years old!");
        break; 
    }
    else
    {
        System.Console.WriteLine("What are you, a moron! Enter a number, fool!");
    }
}
     */

    public class AnnoyinglyLongAndSpecificClassName { }
}
