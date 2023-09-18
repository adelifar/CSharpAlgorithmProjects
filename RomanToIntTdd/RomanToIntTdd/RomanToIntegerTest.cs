using Xunit;
using static Xunit.Assert;
namespace RomanToIntTdd;

public class RomanToIntegerTest
{
    private RomanToInteger converter;

//setup
    public RomanToIntegerTest()
    {
        converter = new RomanToInteger();
    }

    [Fact]
    public void Nothing()
    {
        var result = converter.RomanToInt("");
    }

    [Theory]
    [InlineData("I", 1)]
    [InlineData("V", 5)]
    [InlineData("X", 10)]
    [InlineData("L", 50)]
    [InlineData("C", 100)]
    [InlineData("D", 500)]
    [InlineData("M", 1000)]
    public void ShouldReturnIntValueForSingleCharacter(string input, int expected)
    {
        //"I" =>1  "V"=>5
        AssertResult(input, expected);
    }

    [Theory]
    [InlineData("II", 2)]
    [InlineData("III", 3)]
    [InlineData("VI", 6)]
    public void MultipleCharactersShouldReturnSumOfThatCharacter(string input, int expected)
    {
        AssertResult(input, expected);
    }

    [Theory]
    [InlineData("IV", 4)]
    [InlineData("IX", 9)]
    [InlineData("IVX", 14)]
    public void IBeforeVOrXSubtractFromRightCharacter(string input, int expected)
    {
        AssertResult(input, expected);
    }

    [Theory]
    [InlineData("XL",40)]
    [InlineData( "XC",90)]
    public void XBeforeLAndCSubtract10(string input,int expected)
    {
        AssertResult(input,expected);
    }

    [Theory]
    [InlineData("CD", 400)]
    [InlineData("CM", 900)]
    public void CBeforeDAndMSubtract100(string input, int expected)
    {
        AssertResult(input,expected);
    }

    [Theory]
    [InlineData("LVIII", 58)]
    [InlineData("MCMXCIV", 1994)]
    public void AcceptanceTest(string input, int expected)
    {
        AssertResult(input,expected);
    }
    
    
    
    private void AssertResult(string input, int expected)
    {
        var result = converter.RomanToInt(input);
        Equal(expected, result);
    }
}