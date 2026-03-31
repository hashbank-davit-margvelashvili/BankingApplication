namespace BankingApplication.Common.Tests;

public class HspFunctionsTests
{
    [Theory]
    [InlineData("UserErrorClass60000", 60000)]
    [InlineData("SysErrorClass60001", 60001)]
    [InlineData("ARC_GeneralError101", 101)]
    [InlineData("SomethingElse", 60000)]
    [InlineData("", 60000)]
    [InlineData("unknown_type", 60000)]
    [InlineData(null, 60000)]
    public void GetErrorNumberConstant_ReturnsCorrectValue(string input, int expectedResult)
    {
        // Act
        var actualResult = HspFunctions.GetErrorNumberConstant(input);

        // Assert
        Assert.Equal(expectedResult, actualResult);
    }

    [Fact]
    public void GetErrorNumberConstant_ReturnsCorrectValue_IfParameterOmitted()
    {
        // Arrange
        var expectedResult = 60000;

        // Act
        var actualResult = HspFunctions.GetErrorNumberConstant();

        // Assert
        Assert.Equal(expectedResult, actualResult);
    }
}