using Calculator_DSB.Models.Interfaces;

namespace Calculator_DSB.Models
{
    public class CalculatorBasic : IBasicCalculator
    {
        public CalculatorBasic()
        {
        }

        //make a method that takes a string if it detect + - * / it will call the right method
        public double Calculate(double a, string symbol, double b)
        {
            switch (symbol)
            {
                case "+":
                    return Add(a, b);
                case "-":
                    return Substract(a, b);
                case "*":
                    return Multiply(a, b);
                case "/":
                    return Divide(a, b);
                default:
                    throw new System.ArgumentException("Parameter cannot be null", "symbol");
            }
        }

        public double Add(double a, double b)
        {
            return a + b;
        }

        public double Substract(double a, double b)
        {
            return a - b;
        }

        public double Multiply(double a, double b)
        {
            return a * b;
        }

        public double Divide(double a, double b)
        {
            if (b == 0)
            {
                throw new System.DivideByZeroException();
            }
            return a / b;
        }
    }
}
