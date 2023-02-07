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

    public class AnnoyinglyLongAndSpecificClassName { }
}
