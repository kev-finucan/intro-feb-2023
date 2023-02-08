
namespace StringCalculator;

public class StringCalculatorTests
{
    [Fact]
    public void EmptyStringReturnsZero()
    {
        var calculator = new StringCalculator();

        var result = calculator.Add("");

        Assert.Equal(0, result);
    }

    [Fact]
    public void singleDigit()
    { 
        var calculator = new StringCalculator();

        var result = calculator.Add("1");

        Assert.Equal(1, result);
    }

    [Fact]
    public void doubleDigit() 
    {
        var calculator = new StringCalculator();

        var result = calculator.Add("1,2");

        Assert.Equal(3, result);
    }

    [Fact]
    public void moreThanTwoDigitsCommaDelimited()
    {
        var calculator = new StringCalculator();

        var result = calculator.Add("1,2,3,4,5,6");

        Assert.Equal(21, result);
    }

    [Fact]
    public void moreThanTwoDigitsNewLineDelimited()
    {
        var calculator = new StringCalculator();

        var result = calculator.Add("1 \n 2 \n 3 \n 4 \n 5 \n 6");

        Assert.Equal(21, result);
    }

}
