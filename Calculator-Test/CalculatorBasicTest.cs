namespace Calculator_Test
{
    public class CalculatorBasicTest
    {
        [Fact]
        public void adding_1_and_1_should_return_2()
        {
            // Arrange
            var sut = new CalculatorBasic();

            // Act
            var result = sut.Add(1, 1);

            // Assert
            result.Should().Be(2); ;
        }

        [Fact]
        public void adding_Two_Negavtive_Numbers_Should_Return_Negative_Result()
        {
            // Arrange
            var sut = new CalculatorBasic();

            // Act
            var result = sut.Add(-1, -1);

            // Assert
            result.Should().Be(-2);
        }

        [Fact]
        public void subtracting_1_and_1_should_return_0()
        {
            // Arrange
            var sut = new CalculatorBasic();

            // Act
            var result = sut.Substract(1, 1);

            // Assert
            result.Should().Be(0);
        }

        [Fact]
        public void subtracting_Two_Negavtive_Numbers_Should_Return_Positive_Result()
        {
            // Arrange
            var sut = new CalculatorBasic();

            // Act
            var result = sut.Substract(-1, -1);

            // Assert
            result.Should().Be(0);
        }

        [Fact]
        public void multiplying_3_and_3_should_return_9()
        {
            // Arrange
            var sut = new CalculatorBasic();

            // Act
            var result = sut.Multiply(3, 3);

            // Assert
            result.Should().Be(9);
        }

        [Fact]
        public void multiplying_Two_Negavtive_Numbers_Should_Return_Positive_Result()
        {
            // Arrange
            var sut = new CalculatorBasic();

            // Act
            var result = sut.Multiply(-1, -1);

            // Assert
            result.Should().Be(1);
        }

        [Fact]
        public void dividing_4_and_2_should_return_2()
        {
            // Arrange
            var sut = new CalculatorBasic();

            // Act
            var result = sut.Divide(4, 2);

            // Assert
            result.Should().Be(2);
        }

        [Fact]
        public void dividing_4_and_0_should_throw_exception()
        {
            // Arrange
            var sut = new CalculatorBasic();

            // Act
            Action act = () => sut.Divide(4, 0);

            // Assert
            act.Should().Throw<DivideByZeroException>();
        }

        [Fact]
        public void calucating_without_symbol_should_throw_exception()
        {
            // Arrange
            var sut = new CalculatorBasic();

            // Act
            Action act = () => sut.Calculate(4, "", 0);

            // Assert
            act.Should().Throw<ArgumentException>();
        }

        [Theory]
        [InlineData(1.5, "+", 1.5, 3)]
        [InlineData(1.5, "-", 1.5, 0)]
        [InlineData(1.5, "*", 1.5, 2.25)]
        [InlineData(1.5, "/", 1.5, 1)]
        public void calculations_with_decimals_should_return_correct_results(
            double a,
            string symbol,
            double b,
            double expected)
        {
            // Arrange
            var sut = new CalculatorBasic();

            // Act
            var result = sut.Calculate(a, symbol, b);

            // Assert
            result.Should().Be(expected);
        }

        //with non decimals
        [Theory]
        [InlineData(1, "+", 1, 2)]
        [InlineData(1, "-", 1, 0)]
        [InlineData(1, "*", 1, 1)]
        [InlineData(1, "/", 1, 1)]
        public void calculations_without_decimals_should_return_correct_results(
            double a,
            string symbol,
            double b,
            double expected)
        {
            // Arrange
            var sut = new CalculatorBasic();

            // Act
            var result = sut.Calculate(a, symbol, b);

            // Assert
            result.Should().Be(expected);
        }
    }
}