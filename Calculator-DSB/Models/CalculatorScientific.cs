using Calculator_DSB.Models.Interfaces;

namespace Calculator_DSB.Models
{


    public class CalculatorScientific : IScientificCalculator 
    {
        //make calculate method use base if it is not a scientific symbol
        IBasicCalculator basicCalculator;

        public CalculatorScientific(IBasicCalculator basicCalculator)
        {
            this.basicCalculator = basicCalculator;
        }


        public double Calculate(double a, string symbol, double b)
        {
            switch (symbol)
            {
                case "sin":
                    return Sin(a);
                case "cos":
                    return Cos(a);
                case "tan":
                    return Tan(a);
                case "log":
                    return Log(a);
                case "sqrt":
                    return Sqrt(a);
                default:
                    return basicCalculator.Calculate(a, symbol, b);
            }
        }

        public double Sqrt(double a)
        {
            throw new NotImplementedException();
        }

        public double Log(double a)
        {
            throw new NotImplementedException();
        }

        public double Tan(double a)
        {
            throw new NotImplementedException();
        }

        public double Cos(double a)
        {
            throw new NotImplementedException();
        }

        public double Sin(double a)
        {
            throw new NotImplementedException();
        }
    }
}
