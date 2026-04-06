namespace BankingApplication.Common.Tests;

public class HspFunctionsTests
{
    #region GetErrorNumberConstant Tests

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
    public void GetErrorNumberConstant_ReturnsCorrectValue2()
    {
        // Arrange
        var input = "UserErrorClass60000";
        var expectedResult = 60000;

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

    #endregion GetErrorNumberConstant Tests

    [Theory]
    [InlineData(0, 0)]
    [InlineData(50, 0)]
    [InlineData(99, 0)]
    [InlineData(100, 100)]
    [InlineData(150, 100)]
    [InlineData(399, 100)]
    [InlineData(400, 400)]
    [InlineData(500, 400)]
    [InlineData(699, 400)]
    [InlineData(700, 700)]
    [InlineData(800, 700)]
    [InlineData(999, 700)]
    [InlineData(1000, 1000)]
    [InlineData(1500, 1000)]
    [InlineData(int.MaxValue, 1000)]
    [InlineData(-1, null)]
    [InlineData(int.MinValue, null)]
    public void GetARCClassConstant(int input, int? expectedResult)
    {
        // Act
        var actualResult = HspFunctions.GetARCClassConstant(input);

        // Assert
        Assert.Equal(expectedResult, actualResult);
    }
}